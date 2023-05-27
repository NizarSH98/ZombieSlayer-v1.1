using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using SkeletonSlayer;

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
        Image Pause = Image.FromFile("images\\Pause.png");
        Image G_O = Image.FromFile("images\\Game_Over.png");
        Image No = Image.FromFile("images\\NO.png");
        Image Yes = Image.FromFile("images\\YES.png");
        Image M_O_YesNo = Image.FromFile("images\\Mouse_Over_YesNo.png");

        int mage_walk_counter = 0;
        int mage_run_counter = 0;
        int mage_atk_counter = 0;
        int mage_die_counter = 0;
        int HP_counter = 0;
        int mage_step;

        public int screen_w;
        public int screen_h;

        public int mage_x;
        public int mage_y;
        public int mage_h;
        public int mage_w;
        Random rx = new Random();

        int[] Health =new int[100] ;
        int map_x;
        int map_y;
        int map_w;
        int map_h;
        int mapI = 0;
        int Z_x;
        int Z_y;
        int S_x;
        int S_y;
        int P_X;
        int P_Y;
        int P_W;
        int P_H;
        int GO_X;
        int GO_Y;
        int GO_W;
        int GO_H;
        int No_X;
        int Yes_X;
        int YesNo_Y;
        int YesNo_W;
        int YesNo_H;
       
   
        int potion_count = 0;
        int sheild_counter=0;
        int sheild_Time = 100;
        int HP1_X;
        int HP2_X;
        int HP1_Y;
        int HP2_Y;
        int sheild_x;
        int sheild_y;
        int zombies_1_dead = 0;
        int zombies_2_dead = 0;
        int health_counter_i = 0;
        int esc_counter = 0;
        int sheild_count=0;
       Random r = new Random();
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
        bool pause = false;
        bool LEVEL1 = false;
        bool LEVEL2 = false;
        bool new_map_1 = false;
        bool sh=false;
        bool mouse_over_yes=false;
        bool mouse_over_no = false;
        Zombie[] zombies_1;
        Zombie[] zombies_2;
        Skeleton[] skeletons;
        Zombie zombie;
        Healing_Potion HP_1;
        Healing_Potion HP_2;
        int zombie1_counter;
        int zombie2_counter;
        int skeleton_counter;
        Sheild sheild;
        int zombie1_time_counter;
        int zombie2_time_counter;
        int init_zombie1_time_counter = 60;
        int init_zombie2_time_counter = 55;
        int skeleton_time_counter;
        int init_skeleton_time_counter = 70;
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
                if (HP_1.ready && !HP_1.took)
                {
                    HP_1.draw(g, HP_1.GetX(), HP_1.GetY(), mage_w, mage_h);

                }
                if (HP_2.ready && !HP_2.took)
                {
                    HP_2.draw(g, HP_2.GetX(), HP_2.GetY(), mage_w, mage_h);

                }
                if (sheild.ready && !sheild.took)
                {
                    sheild.draw(g, sheild.GetX(), sheild.GetY(), mage_w/2, mage_h/2);

                }
                if (moveright == true && run == false && !attack)  //walk
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

                if (zombies_1 != null)
                    for (i = 0; i < zombies_1.Length; i++)
                    {
                        if (zombies_1[i].state != 0 && zombies_1[i].ready)
                        {
                            zombies_1[i].draw(g, zombies_1[i].GetX(), zombies_1[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (zombies_2 != null)
                    for (i = 0; i < zombies_2.Length; i++)
                    {
                        if (zombies_2[i].state != 0 && zombies_2[i].ready)
                        {
                            zombies_2[i].draw(g, zombies_2[i].GetX(), zombies_2[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (skeletons != null)
                    for (i = 0; i < skeletons.Length; i++)
                    {
                        if (skeletons[i].state != 0 && skeletons[i].ready)
                        {
                            skeletons[i].draw(g, skeletons[i].GetX(), skeletons[i].GetY(), mage_w, mage_h);

                        }

                    }
            }
            if (mage_die && (mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
            {
                 if (zombies_1 != null)
                    for (i = 0; i < zombies_1.Length; i++)
                    {
                        if (zombies_1[i].state != 0 && zombies_1[i].ready)
                        {
                            zombies_1[i].draw(g, zombies_1[i].GetX(), zombies_1[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (zombies_2 != null)
                    for (i = 0; i < zombies_2.Length; i++)
                    {
                        if (zombies_2[i].state != 0 && zombies_2[i].ready)
                        {
                            zombies_2[i].draw(g, zombies_2[i].GetX(), zombies_2[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (skeletons != null)
                    for (i = 0; i < skeletons.Length; i++)
                    {
                        if (skeletons[i].state != 0 && skeletons[i].ready)
                        {
                            skeletons[i].draw(g, skeletons[i].GetX(), skeletons[i].GetY(), mage_w, mage_h);

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

            g.DrawImage(map[mapI + 1], map_x, map_y, map_w, map_h);


            if (health_counter < health.Length - 1)
            {
                g.DrawImage(health[health_counter], screen_w - mage_w - mage_w / 5, screen_h / 100, mage_w, mage_h / 2);
            }
            if (sh)
                sheild.draw(g, screen_w - mage_w - mage_w / 2, screen_h / 90, mage_w/3, mage_w/4);
            
            if (pause&&!mage_die)
            {
                g.DrawImage(Pause, P_X, P_Y, P_W, P_Y);
            }
            if (mage_die)
            {
                g.DrawImage(G_O, GO_X, GO_Y, GO_W, GO_H);
                g.DrawImage(No,No_X,YesNo_Y,YesNo_W,YesNo_H);
                g.DrawImage(Yes, Yes_X, YesNo_Y, YesNo_W, YesNo_H);
            }
            if (mouse_over_yes|| mouse_over_no)
            {
                g.DrawImage(M_O_YesNo, MousePosition.X-screen_w/80, MousePosition.Y-screen_h/25, screen_w/40, screen_h/30);
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
            P_W = screen_w / 2;
            P_H = screen_h / 2;
            P_X = screen_w / 4;
            P_Y = screen_h / 4;
          
            mage_x = screen_w / 10;
            mage_y = screen_w / 2;
            mage_walk_counter = 0;
            mage_run_counter = 0;
            mage_step = ((screen_h / 100) + (screen_w / 100)) / 2;
            HP_1 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
            HP_2 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
           sheild = new Sheild(r.Next(0, screen_w), r.Next(0, screen_h), mage_w/4, mage_w/4);
            zombie = new Zombie(Z_x, Z_y, mage_w, mage_h);
            zombies_1 = new Zombie[17];
            for (i = 0; i < zombies_1.Length; i++)
            {
                Z_x = r.Next(0, screen_w);
                Z_y = r.Next(0, screen_h);
                zombies_1[i] = new Zombie(Z_x, Z_y, mage_w, mage_h);

            }
            zombies_2 = new Zombie[15];
            for (i = 0; i < zombies_2.Length; i++)
            {
                Z_x = r.Next(0, screen_w);
                Z_y = r.Next(0, screen_h);
                zombies_2[i] = new Zombie(Z_x, Z_y, mage_w, mage_h);

            }
            skeletons = new Skeleton[35];
            for (i = 0; i < skeletons.Length; i++)
            {
                S_x = r.Next(0, screen_w);
                S_y = r.Next(0, screen_h);
                skeletons[i] = new Skeleton(S_x, S_y, mage_w, mage_h);

            }
            int[] Health = new int[100];

            zombie1_time_counter = init_zombie1_time_counter;
            zombie2_time_counter = init_zombie2_time_counter;
            skeleton_time_counter = init_skeleton_time_counter;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GO_W = screen_w/2;
            GO_H = screen_h/3;
            GO_X = screen_w / 2-GO_W/2;
            GO_Y = screen_h / 2 - GO_H ;
            YesNo_W = GO_W / 5;
            YesNo_H = GO_H / 5;
            Yes_X = screen_w / 2 - YesNo_W;
           No_X = screen_w / 2 ;
            YesNo_Y = GO_Y + GO_H+(YesNo_H/2);
         
            if (!LEVEL1)
            {
                HP1_X = HP_1.GetX();
                HP1_Y = HP_1.GetY();
                if (!mage_die)
                {


                    if (((zombie1_counter) < zombies_1.Length) && (zombie1_time_counter == 0))
                    {
                        zombies_1[zombie1_counter].ready = true;
                        zombie1_counter++;
                    }
                    zombie1_time_counter = zombie1_time_counter == 0 ? 25 : zombie1_time_counter - 1;
                    for (int i = 0; i < zombies_1.Length; i++)
                    {

                        if (!zombies_1[i].die)
                        {
                            if (!zombies_1[i].search)
                            {
                                zombies_1[i].SetX(Z_x);
                                zombies_1[i].SetY(Z_y);
                                zombies_1[i].Setstate(3);
                                if (zombies_1[i].GetSp() == zombies_1[i].GetLSp())
                                {
                                    zombies_1[i].search = true;
                                    Z_x = r.Next(0, screen_w);
                                    Z_y = r.Next(0, screen_h);
                                }

                            }



                            if (zombies_1[i].search)
                            {
                                if (zombies_1[i].GetX() > mage_x)
                                {


                                    if ((Math.Abs(zombies_1[i].GetX() - mage_x) < (mage_w / 2)) && Math.Abs(zombies_1[i].GetY() - mage_y) < mage_h / 2)
                                    {
                                        zombies_1[i].Setstate(6);
                                        if (health_counter != health.Length - 1)
                                            health_counter_i = zombies_1[i].GetHits();

                                        Health[i] = health_counter_i;
                                        health_counted = false;
                                    }
                                    else
                                    {
                                        zombies_1[i].SetX(zombies_1[i].GetX() - mage_step - 1);
                                        zombies_1[i].Setstate(1);
                                    }



                                }
                                if (zombies_1[i].GetX() < mage_x)
                                {


                                    if (Math.Abs(zombies_1[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_1[i].GetY() - mage_y) < mage_h / 2)
                                    {
                                        zombies_1[i].Setstate(5);
                                        health_counter_i = zombies_1[i].GetHits();

                                        Health[i] = health_counter_i;
                                        health_counted = false;

                                    }
                                    else
                                    {
                                        zombies_1[i].SetX(zombies_1[i].GetX() + mage_step - 1);

                                        zombies_1[i].Setstate(2);
                                    }
                                }
                                if (zombies_1[i].GetY() > mage_y)
                                    zombies_1[i].SetY(zombies_1[i].GetY() - mage_step - 1);

                                if (zombies_1[i].GetY() < mage_y)
                                    zombies_1[i].SetY(zombies_1[i].GetY() + mage_step - 1);
                            }
                        }


                        if (health_counter == health.Length - 1)
                        {

                            mage_die = true;

                        }
                        if (Math.Abs(zombies_1[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_1[i].GetY() - mage_y) < mage_h / 2 && zombies_1[i] != null && attack && zombies_1[i].GetX() < mage_x)
                        {
                            zombies_1[i].die = true;
                            zombies_1[i].Setstate(4);
                            if (zombies_1[i].GetDR() == zombies_1[i].GetLDR())
                            {

                                zombies_1[i].Setstate(0);
                            }
                        }
                        else if (Math.Abs(zombies_1[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_1[i].GetY() - mage_y) < mage_h / 2 && zombies_1[i] != null && attack && zombies_1[i].GetX() > mage_x)
                        {
                            zombies_1[i].die = true;
                            zombies_1[i].Setstate(7);
                            if (zombies_1[i].GetDL() == zombies_1[i].GetLDL())
                            {

                                zombies_1[i].Setstate(0);
                            }
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

                        if (mage_x > -mage_w / 6)
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
                {
                    if ((mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
                        mage_die_counter++;

                }

                P_W = screen_w / 2;
                P_H = screen_h / 2;
                P_X = screen_w / 4;
                P_Y = screen_h / 4;
                zombies_1_dead = 0;
               
                Invalidate();
            }
          
            if (zombies_1 != null)
            {
                for (i = 0; i < zombies_1.Length; i++)
                {
                    if (zombies_1[i].die)
                    {
                        zombies_1_dead++;
                        if (zombies_1_dead == zombies_1.Length)
                        {
                            LEVEL1 = true;

                        }
                    }
                }
            }
            if (LEVEL1 && !LEVEL2)
            {
                if (!mage_die) { 
                if (mage_y < mage_h / 2 && mapI == 0)
                {
                        health_counter = 0;
                    mapI = 2;
                    mage_y = screen_h - mage_h;
                    new_map_1 = true;
                        for(int o = 0; o < Health.Length; o++)
                        {
                            Health[o] = 0;
                        }
                }

                zombies_1 = null;

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

                    if (mage_x > -mage_w / 6)
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

                if (new_map_1)
                {
                    if (!mage_die)
                    {   
                        if (((skeleton_counter) < skeletons.Length) && (skeleton_time_counter == 0))
                        {
                            skeletons[skeleton_counter].ready = true;
                            skeleton_counter++;
                        }
                        skeleton_time_counter = skeleton_time_counter == 0 ? 20: skeleton_time_counter - 1;
                        if (((zombie2_counter) < zombies_2.Length) && (zombie2_time_counter == 0))
                        {
                            zombies_2[zombie2_counter].ready = true;
                            zombie2_counter++;
                        }
                        zombie2_time_counter = zombie2_time_counter == 0 ? 35 : zombie2_time_counter - 1;

                        for (int i = 0; i < skeletons.Length; i++)
                        {

                            if (!skeletons[i].die)
                            {
                                if (!skeletons[i].search)
                                {
                                    skeletons[i].SetX(S_x);
                                    skeletons[i].SetY(S_y);
                                    skeletons[i].Setstate(3);
                                    if (skeletons[i].GetSp() == skeletons[i].GetLSp())
                                    {
                                        skeletons[i].search = true;
                                        S_x = r.Next(0, screen_w);
                                        S_y = r.Next(0, screen_h);
                                    }

                                }



                                if (skeletons[i].search)
                                {
                                    if (skeletons[i].GetX() > mage_x)
                                    {


                                        if ((Math.Abs(skeletons[i].GetX() - mage_x) < (mage_w / 2)) && Math.Abs(skeletons[i].GetY() - mage_y) < mage_h / 2)
                                        {
                                            skeletons[i].Setstate(6);
                                            if (health_counter != health.Length - 1)
                                                if (!sh) { 
                                            health_counter_i = skeletons[i].GetHits();

                                            Health[i] = health_counter_i;
                                                    health_counted = false;
                                                }
                                            
                                        }
                                        else
                                        {
                                            skeletons[i].SetX(skeletons[i].GetX() - mage_step - 1);
                                            skeletons[i].Setstate(1);
                                        }



                                    }
                                    if (skeletons[i].GetX() < mage_x)
                                    {


                                        if (Math.Abs(skeletons[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(skeletons[i].GetY() - mage_y) < mage_h / 2 )
                                        {
                                            skeletons[i].Setstate(5);
                                            if (!sh)
                                            {
                                                health_counter_i = skeletons[i].GetHits();
                                                Health[i] = health_counter_i;
                                                health_counted = false;
                                            }
                                           

                                        }
                                        else
                                        {
                                            skeletons[i].SetX(skeletons[i].GetX() + mage_step - 1);

                                            skeletons[i].Setstate(2);
                                        }
                                    }
                                    if (skeletons[i].GetY() > mage_y)
                                        skeletons[i].SetY(skeletons[i].GetY() - mage_step - 1);

                                    if (skeletons[i].GetY() < mage_y)
                                        skeletons[i].SetY(skeletons[i].GetY() + mage_step - 1);
                                }
                            }



                            if (health_counter == health.Length - 1)
                            {

                                mage_die = true;

                            }
                            if (Math.Abs(skeletons[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(skeletons[i].GetY() - mage_y) < mage_h / 2 && skeletons[i] != null && attack && skeletons[i].GetX() < mage_x)
                            {
                                skeletons[i].die = true;
                                skeletons[i].Setstate(4);
                                if (skeletons[i].GetDR() == skeletons[i].GetLDR())
                                {

                                    skeletons[i].Setstate(0);
                                }
                            }
                            else if (Math.Abs(skeletons[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(skeletons[i].GetY() - mage_y) < mage_h / 2 && skeletons[i] != null && attack && skeletons[i].GetX() > mage_x)
                            {
                                skeletons[i].die = true;
                                skeletons[i].Setstate(7);
                                if (skeletons[i].GetDL() == skeletons[i].GetLDL())
                                {

                                    skeletons[i].Setstate(0);
                                }
                            }

                        }

                        for (int i = 0; i < zombies_2.Length; i++)
                        {

                            if (!zombies_2[i].die)
                            {
                                if (!zombies_2[i].search)
                                {
                                    zombies_2[i].SetX(S_x);
                                    zombies_2[i].SetY(S_y);
                                    zombies_2[i].Setstate(3);
                                    if (zombies_2[i].GetSp() == zombies_2[i].GetLSp())
                                    {
                                        zombies_2[i].search = true;
                                        Z_x = r.Next(0, screen_w);
                                        Z_y = r.Next(0, screen_h);
                                    }

                                }



                                if (zombies_2[i].search)
                                {
                                    if (zombies_2[i].GetX() > mage_x)
                                    {


                                        if ((Math.Abs(zombies_2[i].GetX() - mage_x) < (mage_w / 2)) && Math.Abs(zombies_2[i].GetY() - mage_y) < mage_h / 2)
                                        {
                                            zombies_2[i].Setstate(6);
                                            if (health_counter != health.Length - 1)
                                                if (!sh)
                                                {
                                                    health_counter_i = zombies_2[i].GetHits();

                                                    Health[i] = health_counter_i;
                                                    health_counted = false;
                                                }
                                            
                                        }
                                        else
                                        {
                                            zombies_2[i].SetX(zombies_2[i].GetX() - mage_step - 1);
                                            zombies_2[i].Setstate(1);
                                        }



                                    }
                                    if (zombies_2[i].GetX() < mage_x)
                                    {


                                        if (Math.Abs(zombies_2[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_2[i].GetY() - mage_y) < mage_h / 2)
                                        {
                                            zombies_2[i].Setstate(5);
                                            if (!sh)
                                            {
                                                health_counter_i = zombies_2[i].GetHits();

                                                Health[i] = health_counter_i;
                                                health_counted = false;
                                            }
                                           

                                        }
                                        else
                                        {
                                            zombies_2[i].SetX(zombies_2[i].GetX() + mage_step - 1);

                                            zombies_2[i].Setstate(2);
                                        }
                                    }
                                    if (zombies_2[i].GetY() > mage_y)
                                        zombies_2[i].SetY(zombies_2[i].GetY() - mage_step - 1);

                                    if (zombies_2[i].GetY() < mage_y)
                                        zombies_2[i].SetY(zombies_2[i].GetY() + mage_step - 1);
                                }
                            }

                          

                            if (health_counter >= health.Length - 1)
                            {

                                mage_die = true;

                            }
                            if (Math.Abs(zombies_2[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_2[i].GetY() - mage_y) < mage_h / 2 && zombies_2[i] != null && attack && zombies_2[i].GetX() < mage_x)
                            {
                                zombies_2[i].die = true;
                                zombies_2[i].Setstate(4);
                                if (zombies_2[i].GetDR() == zombies_2[i].GetLDR())
                                {

                                    zombies_2[i].Setstate(0);
                                }
                            }
                            else if (Math.Abs(zombies_2[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(zombies_2[i].GetY() - mage_y) < mage_h / 2 && zombies_2[i] != null && attack && zombies_2[i].GetX() > mage_x)
                            {
                                zombies_2[i].die = true;
                                zombies_2[i].Setstate(7);
                                if (zombies_2[i].GetDL() == zombies_2[i].GetLDL())
                                {

                                    zombies_2[i].Setstate(0);
                                }
                            }

                        }

                    }

                    
                   

                    if (mage_die)
                    {
                        if ((mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
                            mage_die_counter++;

                    }


                }

                P_W = screen_w / 2;
                P_H = screen_h / 2;
                P_X = screen_w / 4;
                P_Y = screen_h / 4;
              
                Invalidate();
            }
            if (!health_counted && !sh)
            {
                health_counter = 0;
                for (i = 0; i < Health.Length; i++)
                {
                    if (health_counter < health.Length - 1)
                        health_counter += Health[i];

                    if (i == Health.Length - 1)
                        health_counted = true;
                }

            }

            if (mage_die)
            {
                if ((Math.Abs(Yes_X - MousePosition.X) < YesNo_W && Math.Abs(YesNo_Y - MousePosition.Y) < YesNo_H && MousePosition.X > Yes_X && MousePosition.Y > YesNo_Y))
                {
                    mouse_over_yes = true;
                    mouse_over_no = false;
                }
                else if ((Math.Abs(No_X - MousePosition.X) < YesNo_W && Math.Abs(YesNo_Y - MousePosition.Y) < YesNo_H && MousePosition.X > Yes_X && MousePosition.Y > YesNo_Y))
                {
                    mouse_over_no = true;
                    mouse_over_yes = false;
                }
                else
                {
                    mouse_over_yes = false;
                    mouse_over_no = false;
                }

            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (!mage_die)
                {
                    esc_counter++;
                    pause = true;
                    timer1.Stop();
                    timer2.Stop();
                    Invalidate();
                    if (esc_counter == 2)
                    {
                        Application.Exit();
                    }
                }
                if (mage_die)
                {
                    Application.Exit();
                }
            }

            if (e.KeyCode == Keys.P)
            {
                pause = false;
                esc_counter = 0;
                timer1.Start();
                timer2.Start();
            }
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
            P_W = screen_w / 2;
            P_H = screen_h / 2;
            P_X = screen_w / 4;
            P_Y = screen_h / 4;
            mage_h = screen_h / 12;
            mage_w = screen_w / 12;
           
            Invalidate();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            attack = true;
            Console.WriteLine(dir);
            Console.WriteLine("here");
            if (mouse_over_no)
            {
                Application.Exit();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!LEVEL1)
            {
                HP1_X = HP_1.GetX();
                HP1_Y = HP_1.GetY();
                HP_counter++;
                if (potion_count < 1)
                {

                    if (HP_counter > 300 && !HP_1.ready)
                    {
                        HP_1.ready = true;
                        HP_1.took = false;

                    }
                    if (HP_1.ready && !HP_1.took)
                    {
                        if (Math.Abs(HP1_X - mage_x) < mage_w / 3)
                        {
                            if (Math.Abs(HP1_Y - mage_y) < mage_h / 3)
                            {
                                HP_1.took = true;
                            }
                        }

                    }

                    if (HP_1.ready && HP_1.took)
                    {
                        for (int h = 0; h < Health.Length; h++)
                        {
                            health_counter = 0;
                            Health[h] = 0;
                            if (h == Health.Length - 1)
                            {
                                HP_1.ready = false;
                                HP_1.took = false;
                                potion_count++;
                                HP_counter = 0;
                            }

                        }
                    }



                }
            }

            if (LEVEL1 && !LEVEL2)
            {
                HP2_X = HP_2.GetX();
                HP2_Y = HP_2.GetY();
                sheild_x = sheild.GetX();
                sheild_y=sheild.GetY();
                HP_counter++;
                sheild_counter++;
                if (sheild_count < 1)
                {
                    if(sheild_counter>350 && !sheild.ready)
                    {
                        sheild.ready = true;
                        sheild.took = false;
                    }
                    if (sheild.ready && !sheild.took)
                    {
                        if(Math.Abs(sheild_x- mage_x) < mage_w / 3)
                        {
                            if (Math.Abs(sheild_y - mage_y) < mage_h / 3)
                            {
                                sheild.took=true;
                            }
                        }
                    }
                    if (sheild.ready && sheild.took)
                    {
                        if (sheild_Time > 0)
                        {
                            sh = true;
                            sheild_Time--;
                        }
                        else
                        {
                            sheild.ready = false;
                            sheild.took = false;
                            sh=false;
                            sheild_count++;
                        }
                       
                    }

                }




                if (potion_count < 3)
                {

                    if (HP_counter > 300 && !HP_2.ready)
                    {
                        HP_2.ready = true;
                        HP_2.took = false;

                    }
                    if (HP_2.ready && !HP_2.took)
                    {
                        if (Math.Abs(HP2_X - mage_x) < mage_w / 3)
                        {
                            if (Math.Abs(HP2_Y - mage_y) < mage_h / 3)
                            {
                                HP_2.took = true;
                            }
                        }

                        

                    }

                    if (HP_2.ready && HP_2.took)
                    {
                        for (int h = 0; h < Health.Length; h++)
                        {
                            health_counter = 0;
                            Health[h] = 0;
                            if (h == Health.Length - 1)
                            {
                                HP_2.ready = false;
                                HP_2.took = false;
                                potion_count++;
                                HP_2.SetX(r.Next(0, screen_w));
                                HP_2.SetY(r.Next(0, screen_h));
                            }

                        }
                    }

                }
            }
           
        }

        private void Mouse_Hover(object sender, EventArgs e)
        {
            
        }
    }
}
        
    



