using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ZombieSlayer
{



    public partial class Form1 : Form
    {
        string dir = Directory.GetCurrentDirectory();

        Image[] map = { Image.FromFile("images\\map\\map1.png"), Image.FromFile("images\\map\\map1_1.png"), Image.FromFile("images\\map\\map2.png"), Image.FromFile("images\\map\\map2_1.png"), Image.FromFile("images\\map\\map3.png"), Image.FromFile("images\\map\\map3_1.png"), Image.FromFile("images\\map\\map3_2.png"), Image.FromFile("images\\map\\map3_3.png") };
        Image mageR = Image.FromFile("images\\mage_R\\idle_1.png");
        Image mageL = Image.FromFile("images\\mage_L\\idle_1.png");
        Image[] mage_R = { Image.FromFile("images\\mage_R\\walk_1.png"), Image.FromFile("images\\mage_R\\walk_2.png"), Image.FromFile("images\\mage_R\\walk_3.png"), Image.FromFile("images\\mage_R\\walk_4.png") };
        Image[] mage_L = { Image.FromFile("images\\mage_L\\walk_1.png"), Image.FromFile("images\\mage_L\\walk_2.png"), Image.FromFile("images\\mage_L\\walk_3.png"), Image.FromFile("images\\mage_L\\walk_4.png") };
        Image[] mage_run_L = { Image.FromFile("images\\mage_L\\run_1.png"), Image.FromFile("images\\mage_L\\run_2.png"), Image.FromFile("images\\mage_L\\run_3.png"), Image.FromFile("images\\mage_L\\run_4.png"), Image.FromFile("images\\mage_L\\run_5.png"), Image.FromFile("images\\mage_L\\run_6.png"), Image.FromFile("images\\mage_L\\run_7.png"), Image.FromFile("images\\mage_L\\run_8.png") };
        Image[] mage_run_R = { Image.FromFile("images\\mage_R\\run_1.png"), Image.FromFile("images\\mage_R\\run_2.png"), Image.FromFile("images\\mage_R\\run_3.png"), Image.FromFile("images\\mage_R\\run_4.png"), Image.FromFile("images\\mage_R\\run_5.png"), Image.FromFile("images\\mage_R\\run_6.png"), Image.FromFile("images\\mage_R\\run_7.png"), Image.FromFile("images\\mage_R\\run_8.png") };
        Image[] mage_atk_L = { Image.FromFile("images\\mage_L\\A-1.png"), Image.FromFile("images\\mage_L\\A-2.png"), Image.FromFile("images\\mage_L\\A-3.png"), Image.FromFile("images\\mage_L\\A-4.png"), Image.FromFile("images\\mage_L\\A-5.png"), Image.FromFile("images\\mage_L\\A-6.png"), Image.FromFile("images\\mage_L\\A-7.png"), Image.FromFile("images\\mage_L\\A-8.png") };
        Image[] mage_atk_R = { Image.FromFile("images\\mage_R\\A-1.png"), Image.FromFile("images\\mage_R\\A-2.png"), Image.FromFile("images\\mage_R\\A-3.png"), Image.FromFile("images\\mage_R\\A-4.png"), Image.FromFile("images\\mage_R\\A-5.png"), Image.FromFile("images\\mage_R\\A-6.png"), Image.FromFile("images\\mage_R\\A-7.png"), Image.FromFile("images\\mage_R\\A-8.png") };
        Image[] health = { Image.FromFile("images\\Health\\health1.png"), Image.FromFile("images\\Health\\health2.png"), Image.FromFile("images\\Health\\health3.png"), Image.FromFile("images\\Health\\health4.png"), Image.FromFile("images\\Health\\health5.png"), Image.FromFile("images\\Health\\health6.png"), Image.FromFile("images\\Health\\health7.png") };
        Image[] mage_die_R = { Image.FromFile("images\\mage_R\\die-1.png"), Image.FromFile("images\\mage_R\\die-2.png"), Image.FromFile("images\\mage_R\\die-3.png"), Image.FromFile("images\\mage_R\\die-4.png"), Image.FromFile("images\\mage_R\\die-5.png"), Image.FromFile("images\\mage_R\\die-6.png"), Image.FromFile("images\\mage_R\\die-7.png"), Image.FromFile("images\\mage_R\\die-8.png") };
        Image[] mage_die_L = { Image.FromFile("images\\mage_L\\die-1.png"), Image.FromFile("images\\mage_L\\die-2.png"), Image.FromFile("images\\mage_L\\die-3.png"), Image.FromFile("images\\mage_L\\die-4.png"), Image.FromFile("images\\mage_L\\die-5.png"), Image.FromFile("images\\mage_L\\die-6.png"), Image.FromFile("images\\mage_L\\die-7.png"), Image.FromFile("images\\mage_L\\die-8.png") };

        int mage_walk_counter = 0;
        int mage_run_counter = 0;
        int mage_atk_counter = 0;
        int mage_die_counter = 0;

        int mage_step;

        public int screen_w;
        public int screen_h;

        public int mage_x;
        public int mage_y;
        public int mage_h;
        public int mage_w;
        Random rx = new Random();
      
        int[] Health = new int[5]; 
        int map_x;
        int map_y;
        int map_w;
        int map_h;
        int mapI = 0;
        int Z_x;
        int Z_y;
        int health_counter_i = 0;
        bool moveup = false;
        bool movedown = false;
        bool moveleft = false;
        bool moveright = false;
        bool mage_die = false;
        bool L = false;
        bool R = false;
        bool run = false;
        bool attack = false;
        bool DR = false;
        bool Dl = false;
        bool health_counted = false;
        Zombie[] zombies;
        Zombie zombie;
        int zombie_counter;
        int zombie_time_counter ;
        int init_zombie_time_counter = 60;
        int health_counter = 0;
        int i;
        public Form1()
        {
            InitializeComponent();
            InitGfx();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;

            g.DrawImage(map[mapI], map_x, map_y, map_w, map_h);
            if (i > 5)
                i = 0;
            //g.DrawImage(zombie_R[i ++], map_x, map_y, mage_w, mage_h);
            if (!mage_die)
            {
                if (moveright == true && run == false&&!attack)  //walk
                {
                    g.DrawImage(mage_R[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                    R = true;
                    L = false;
                    DR = true;
                    Dl = false;
                }
                else if (moveleft == true && run == false && !attack)
                {
                    g.DrawImage(mage_L[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                    R = false;
                    L = true;
                    DR = false;
                    Dl = true;
                }
                else if (moveup == true && run == false && !attack)
                {
                    if (R == true)
                    {
                        g.DrawImage(mage_R[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = true;
                        Dl = false;
                    }
                    else
                    {
                        g.DrawImage(mage_L[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = false;
                        Dl = true;
                    }
                }
                else if (movedown == true && run == false && !attack)
                {
                    if (R == true)
                    {
                        g.DrawImage(mage_R[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = true;
                        Dl = false;
                    }
                    else
                    {
                        g.DrawImage(mage_L[mage_walk_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = false;
                        Dl = true;
                    }
                }


                if (moveright == true && run == true && !attack)  //run
                {
                    g.DrawImage(mage_run_R[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                    R = true;
                    L = false;
                    DR = true;
                    Dl = false;
                }
                else if (moveleft == true && run == true && !attack)
                {
                    g.DrawImage(mage_run_L[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                    R = false;
                    L = true;
                    DR = false;
                    Dl = true;
                }
                else if (moveup == true && run == true && !attack)
                {
                    if (R == true)
                    {
                        g.DrawImage(mage_run_R[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = true;
                        Dl = false;
                    }
                    else
                    {
                        g.DrawImage(mage_run_L[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = false;
                        Dl = true;
                    }
                }
                else if (movedown == true && run == true && !attack)
                {
                    if (R == true)
                    {
                        g.DrawImage(mage_run_R[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = true;
                        Dl = false;
                    }
                    else
                    {
                        g.DrawImage(mage_run_L[mage_run_counter], mage_x, mage_y, mage_w, mage_h);
                        DR = false;
                        Dl = true;
                    }
                }


                else if (R == true && moveright == false && moveup == false && movedown == false && attack == false) //idel
                {
                    g.DrawImage(mageR, mage_x, mage_y, mage_w, mage_h);
                    DR = true;
                    Dl = false;
                }
                else if (L == true && moveleft == false && moveup == false && movedown == false && attack == false)
                {
                    g.DrawImage(mageL, mage_x, mage_y, mage_w, mage_h);
                    DR = false;
                    Dl = true;
                }

                if (attack == true)                                                        //attack
                {   
                        if (R == true)
                        {
                            g.DrawImage(mage_atk_R[mage_atk_counter], mage_x, mage_y, mage_w, mage_h);
                            DR = true;
                            Dl = false;
                        }
                        else
                        {
                            DR = false;
                            Dl = true;
                            g.DrawImage(mage_atk_L[mage_atk_counter], mage_x, mage_y, mage_w, mage_h);
                        }
                    
     
                }
                g.DrawImage(map[mapI + 1], map_x, map_y, map_w, map_h);
                if (health_counter != health.Length - 1)
                    g.DrawImage(health[health_counter], screen_w / 100, screen_h / 100);
                for (i = 0; i < zombies.Length; i++)
                {
                    if (zombies[i].state != 0 && zombies[i].ready)
                    {
                        zombies[i].draw(g, zombies[i].GetX() , zombies[i].GetY() , mage_w, mage_h);

                    }

                }
            }
            if (mage_die && (mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
            {
                for (i = 0; i < zombies.Length; i++)
                {

                    if (zombies[i].state == 0 && health_counter == health.Length - 1d)
                    {
                        zombies[i].draw(g, Z_x, Z_y, mage_w, mage_h);
                    }
                }
                if (DR && !Dl)
                {
                    g.DrawImage(mage_die_R[mage_die_counter], mage_x, mage_y, mage_w, mage_h);
                }

                else if (Dl && !DR)
                {
                    g.DrawImage(mage_die_L[mage_die_counter], mage_x, mage_y, mage_w, mage_h);

                }
            }

        }
        private void InitGfx()
        {

            // screen_w = this.Size.Width;
            // screen_h = this.Size.Height;
            map_x = 0;
            map_y = 0;
            map_h = screen_h;
            map_w = screen_w;

            //mage_h = 32;
            //mage_w = 32;

            mage_x = 10;
            mage_y = 265;
            mage_walk_counter = 0;
            mage_run_counter = 0;
            mage_step = ((screen_h / 100)+ (screen_w / 100))/2;
           
            zombie = new Zombie(Z_x, Z_y,mage_w, mage_h);
            zombies = new Zombie[5];
            for(i = 0; i < zombies.Length; i++)
            {
                zombies[i]= new Zombie(Z_x, Z_y, mage_w, mage_h);
               
            }
            int[] Health = new int[5];
            
            zombie_time_counter = init_zombie_time_counter;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {   if (!mage_die)
            {
             
                if (mage_x > ((12 / 15) * screen_w) && mage_y < 20 && mapI == 0)
                {
                    mapI = 2;
                    mage_x = screen_w / 20;
                    mage_y = screen_h / 2;
                }
                if (mage_x > ((12 / 15) * screen_w) && mage_y < 20 && mapI == 2)
                {
                    mapI = 4;

                    mage_y = screen_h - mage_h;
                }
                if (((zombie_counter) < zombies.Length) && (zombie_time_counter == 0))
                {
                    zombies[zombie_counter].ready = true;
                    zombie_counter++;
                }
                zombie_time_counter = zombie_time_counter == 0 ? 60 : zombie_time_counter - 1;
                for (int i = 0; i < zombies.Length; i++)
                {
                  
                    if (!zombies[i].die)
                    {
                        if (!zombies[i].search)
                        {
                            zombies[i].SetX(screen_w / 6);
                            zombies[i].SetY(screen_h / 8);
                            zombies[i].Setstate(3);
                            if (zombies[i].GetSp() == zombies[i].GetLSp())
                            {
                                zombies[i].search = true;
                            }

                        }



                        if (zombies[i].search)
                        {
                            if (zombies[i].GetX() > mage_x)
                            {


                                if ((Math.Abs(zombies[i].GetX() - mage_x) < (mage_w / 2)) && Math.Abs(zombies[i].GetY() - mage_y) < mage_h / 2)
                                {
                                    zombies[i].Setstate(6);
                                    if (health_counter != health.Length - 1)
                                       health_counter_i = zombies[i].GetHits();
                                    Health[i] = health_counter_i;
                                   
                                }
                                else
                                {
                                    zombies[i].SetX(zombies[i].GetX() - mage_step - 1);
                                    zombies[i].Setstate(1);
                                }



                            }
                            if (zombies[i].GetX() < mage_x)
                            {


                                if (Math.Abs(zombies[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies[i].GetY() - mage_y) < mage_h / 2)
                                {
                                    zombies[i].Setstate(5);
                                    health_counter_i = zombies[i].GetHits();
                                    Health[i] = health_counter_i;


                                }
                                else
                                {
                                    zombies[i].SetX(zombies[i].GetX() + mage_step - 1);

                                    zombies[i].Setstate(2);
                                }
                            }
                            if (zombies[i].GetY() > mage_y)
                                zombies[i].SetY(zombies[i].GetY() - mage_step - 1);

                            if (zombies[i].GetY() < mage_y)
                                zombies[i].SetY(zombies[i].GetY() + mage_step - 1);
                        }
                    }
                   

                    if (health_counter == health.Length - 1)
                    {
                 
                        mage_die = true;

                    }
                    if (Math.Abs(zombies[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies[i].GetY() - mage_y) < mage_h / 2 && zombies[i] != null && attack)
                    {
                        zombies[i].die = true;
                        zombies[i].Setstate(4);
                        if (zombies[i].GetD() == zombies[i].GetLD())
                        {

                            zombies[i].Setstate(0);
                        }
                    }

                    }
                if (!health_counted)
                {
                    for (i = 0; i < Health.Length; i++)
                    {
                        health_counter += Health[i];
                       
                        if(i==Health.Length-1&&health_counter>0)
                            health_counted = true;
                    }
                   
                }
               


                if (attack == true)
                    {
                        moveright = false;
                        movedown = false;
                        moveleft = false;
                        moveup = false;
                        run = false;

                        mage_atk_counter++;

                       
                           
                    }

                    if (mage_atk_counter == mage_atk_R.Length)
                    {
                        mage_atk_counter = 0;
                        attack = false;
                    }

                


                if (moveright == true)
                {

                    if (mage_x < (screen_w - mage_w))
                        if (run == false)
                        {
                            mage_x += mage_step;

                        }
                        else
                        {
                            mage_x += mage_step + 2;

                        }
                    if (moveup == false && movedown == false)
                    {
                        mage_walk_counter++;
                        mage_run_counter++;
                        if (mage_run_counter == mage_run_L.Length)
                            mage_run_counter = 0;
                        if (mage_walk_counter == mage_L.Length)
                            mage_walk_counter = 0;
                    }




                }
                if (moveleft == true)
                {

                    if (mage_x > (mage_w - 40))
                        if (run == false)
                        {
                            mage_x -= mage_step;

                        }
                        else
                        {
                            mage_x -= mage_step + 2;

                        }
                    if (moveup == false && movedown == false)
                    {
                        mage_walk_counter++;
                        mage_run_counter++;
                        if (mage_run_counter == mage_run_L.Length)
                            mage_run_counter = 0;
                        if (mage_walk_counter == mage_L.Length)
                            mage_walk_counter = 0;
                    }



                }
                if (moveup == true)
                {

                    if (mage_y > 0)
                    {
                        if (run == false)
                        {
                            mage_y -= mage_step + 2;
                        }
                        else
                            mage_y -= mage_step + 4;
                    }
                    mage_walk_counter--;
                    mage_run_counter--;
                    if (mage_run_counter <= 0)
                        mage_run_counter = mage_run_L.Length - 1;
                    if (mage_walk_counter <= 0)
                        mage_walk_counter = mage_L.Length - 1;


                }
                if (movedown == true)
                {

                    if (mage_y < (screen_h + mage_h))
                    {
                        if (run == false)
                        {
                            mage_y += mage_step + 2;
                        }
                        else
                            mage_y += mage_step + 4;
                    }

                    mage_walk_counter++;
                    mage_run_counter++;
                    if (mage_run_counter == mage_run_L.Length)
                        mage_run_counter = 0;
                    if (mage_walk_counter == mage_L.Length)
                        mage_walk_counter = 0;
                }
            }
              
            
            if (mage_die)
            {   if((mage_die_counter!=mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
                mage_die_counter++;

            }
                Invalidate();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            health_counted = false;
            zombie_time_counter++;
           
            Invalidate();
          
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mage_die)
            {
                if (e.KeyCode == Keys.D)
                {
                    moveright = true;
                }
                if (e.KeyCode == Keys.W)
                {
                    moveup = true;
                }
                if (e.KeyCode == Keys.S)
                {
                    movedown = true;
                }
                if (e.KeyCode == Keys.A)
                {
                    moveleft = true;
                }
                if (e.KeyCode == Keys.ShiftKey)
                {
                    run = true;
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                moveright = false;
            }
            if (e.KeyCode == Keys.W)
            {
                moveup = false;
            }
            if (e.KeyCode == Keys.S)
            {
                movedown = false;
            }
            if (e.KeyCode == Keys.A)
            {
                moveleft = false;
            }
            if (e.KeyCode == Keys.ShiftKey)
            {
                run = false;
            }
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            screen_w = this.Size.Width;
            screen_h = this.Size.Height;

            map_h = screen_h;
            map_w = screen_w;
            
            mage_h = screen_h / 12;
            mage_w = screen_w / 12;

            Invalidate();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            attack = true;
            Console.WriteLine(dir);
            Console.WriteLine("here");
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        
    }


}
