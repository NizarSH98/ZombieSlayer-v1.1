using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using SkeletonSlayer;
using System.Threading;
using System.Diagnostics;
using System.Media;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ZombieSlayer
{



    public partial class Form1 : Form
    {
        string dir = Directory.GetCurrentDirectory();

        SoundPlayer MainMenu = new System.Media.SoundPlayer(@"sounds\\MusicMainMenu.wav");    //Added
        SoundPlayer Levels = new System.Media.SoundPlayer(@"sounds\\MusicMap.wav");
        SoundPlayer Boss = new System.Media.SoundPlayer(@"sounds\\MusicBossFight.wav");
        SoundPlayer hit = new System.Media.SoundPlayer(@"sounds\\Sound_Hit.wav");
        SoundPlayer fire = new System.Media.SoundPlayer(@"sounds\\sound_fireshot.wav");

        GameState gameState = new GameState();


        Image[] map = { Image.FromFile("images\\map\\map1.png"), Image.FromFile("images\\map\\map1_1.png"), Image.FromFile("images\\map\\map2.png"), Image.FromFile("images\\map\\map3.png"), Image.FromFile("images\\map\\map3_2.png"), Image.FromFile("images\\map\\map3_3.png") };
        Image[] main_menu = { Image.FromFile("images\\map\\Main_Menu.png"), Image.FromFile("images\\map\\Main_1.png"), Image.FromFile("images\\map\\Main_2.png") };
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
        Image Pause = Image.FromFile("images\\More\\Pause.png");
        Image G_O = Image.FromFile("images\\More\\Game_Over.png");
        Image No = Image.FromFile("images\\More\\NO.png");
        Image Yes = Image.FromFile("images\\More\\YES.png");
        Image M_O_YesNo = Image.FromFile("images\\More\\Mouse_Over_YesNo.png");
        Image RST = Image.FromFile("images\\More\\Restart.png");
        Image Ext = Image.FromFile("images\\More\\Exit.png");
        Image Ext_Y = Image.FromFile("images\\More\\Ext_Y.png");
        Image LVL_1 = Image.FromFile("images\\More\\Level_1.png");
        Image LVL_2 = Image.FromFile("images\\More\\Level_2.png");
        Image BOSS_LVL = Image.FromFile("images\\More\\Boss_Level.png");
        Image COMPLETED = Image.FromFile("images\\More\\Completed.png");
        Image ARCADE = Image.FromFile("images\\More\\Arcade.png");
        Image SURVIVAL = Image.FromFile("images\\More\\Survival.png");
        Image Gate = Image.FromFile("images\\More\\Gate.png");
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
        bool Main_Menu = false;
        int main_counter = 0;
        bool Arcade = false;
        bool Survival = false;
        Random rx = new Random();
        int[] Health = new int[100];
        int map_x;
        int map_y;
        int map_w;
        int map_h;
        int mapI = 0;
        int rc = 0;
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
        int shottype = 1;
        bool completed = false;
        bool restart = false;
        int potion_count = 0;
        int sheild_counter = 0;
        int sheild_Time = 100;
        int HP1_X;
        int HP2_X;
        int HP1_Y;
        int HP2_Y;
        int HP3_X;
        int HP3_Y;
        int sheild_x;
        int sheild_y;
        int sheild2_x;
        int sheild2_y;
        int zombies_1_dead = 0;
        int zombies_2_dead = 0;
        int skeletons_dead = 0;
        int health_counter_i = 0;
        int esc_counter = 0;
        int sheild_count = 0;
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
        bool BOSS_LEVEL = false;
        bool new_map_1 = false;
        bool new_map_2 = false;
        bool sh = false;
        bool mouse_over_yes = false;
        bool mouse_over_no = false;
        bool mouse_over_rst = false;
        bool mouse_over_ext = false;
        bool completed_2 = false;
        Zombie[] zombies_1;
        Zombie[] zombies_2;
        Skeleton[] skeletons;
        Zombie zombie;
        Healing_Potion HP_1;
        Healing_Potion HP_2;
        Healing_Potion HP_3;
        int zombie1_counter;
        int zombie2_counter;
        int skeleton_counter;
        Sheild sheild;
        Sheild sheild2;
        int zombie1_time_counter;
        int zombie2_time_counter;
        int init_zombie1_time_counter = 80;
        int init_zombie2_time_counter = 80;
        int skeleton_time_counter;
        int init_skeleton_time_counter = 100;
        int health_counter = 0;
        int i;
        int lvl_1_time = 60;
        bool lvl_1_draw = false;
        int lvl_2_time = 60;
        bool lvl_2_draw = false;
        int boss_lvl_time = 40;
        bool boss_lvl_draw = false;
        fireshot[] F;
        Zombie[] zombies;
        Skeleton[] skeletonss;
        fireshot[] Fs;
        int shotx;
        int shoty;
        int shotcounter = 0;



        bool save = false;
        bool load = false;


        public Form1()
        {
            InitializeComponent();
            InitGfx();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            if (!Main_Menu)
            {
                if (Arcade)
                {
                    main_counter = 2;
                }
                else if (Survival)
                {
                    main_counter = 1;
                }
                g.DrawImage(main_menu[main_counter], map_x, map_y, map_w, map_h);
                g.DrawImage(ARCADE, screen_w / 3, screen_h / 2 - screen_h / 20, screen_w / 10, screen_h / 10);
                g.DrawImage(SURVIVAL, (screen_w / 3) * 2, screen_h / 2 - screen_h / 20, screen_w / 10, screen_h / 10);
                g.DrawImage(Gate, screen_w / 15, (screen_h / 2 - screen_h / 20) + screen_h / 10, screen_w / 15, screen_h / 10);
                g.DrawImage(Ext_Y, screen_w / 18, ((screen_h / 2 - screen_h / 20) + screen_h / 10) - screen_h / 10, screen_w / 10, screen_h / 10);


            }
            else
            {
                g.DrawImage(map[mapI], map_x, map_y, map_w, map_h);

            }
            //g.DrawImage(zombie_R[i ++], map_x, map_y, mage_w, mage_h);



            if (!mage_die)
            {
                if (HP_1.ready && !HP_1.took && !LEVEL1 && !LEVEL2)
                {
                    HP_1.draw(g, HP_1.GetX(), HP_1.GetY(), mage_w, mage_h);

                }
                if (HP_2.ready && !HP_2.took && LEVEL1 && !LEVEL2)
                {
                    HP_2.draw(g, HP_2.GetX(), HP_2.GetY(), mage_w, mage_h);

                }
                if (HP_3.ready && !HP_3.took && LEVEL2)
                {
                    HP_3.draw(g, HP_3.GetX(), HP_3.GetY(), mage_w, mage_h);

                }
                if (sheild.ready && !sheild.took && LEVEL1 && !LEVEL2)
                {
                    sheild.draw(g, sheild.GetX(), sheild.GetY(), mage_w / 2, mage_h / 2);

                }
                if (sheild2.ready && !sheild2.took && LEVEL2)
                {
                    sheild2.draw(g, sheild2.GetX(), sheild2.GetY(), mage_w / 2, mage_h / 2);

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
                        if (zombies_1[i].state != 0 && zombies_1[i].ready && !zombies_1[i].shot)
                        {
                            zombies_1[i].draw(g, zombies_1[i].GetX(), zombies_1[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (zombies_2 != null)
                    for (i = 0; i < zombies_2.Length; i++)
                    {
                        if (zombies_2[i].state != 0 && zombies_2[i].ready && !zombies_2[i].shot)
                        {
                            zombies_2[i].draw(g, zombies_2[i].GetX(), zombies_2[i].GetY(), mage_w, mage_h);

                        }

                    }
                if (skeletons != null)
                    for (i = 0; i < skeletons.Length; i++)
                    {
                        if (skeletons[i].state != 0 && skeletons[i].ready && !skeletons[i].shot)
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
            if (Main_Menu && Arcade)
                if (mapI == 0)
                {
                    g.DrawImage(map[mapI + 1], map_x, map_y, map_w, map_h);

                }
                else if (mapI == 3 || mapI == 4)
                {
                    g.DrawImage(map[5], map_x, map_y, map_w, map_h);
                }

            if (health_counter < health.Length - 1 && Main_Menu)
            {
                g.DrawImage(health[health_counter], screen_w - mage_w - mage_w / 5, screen_h / 100, mage_w, mage_h / 2);
            }
            if (sh)
                sheild.draw(g, screen_w - mage_w - mage_w / 2, screen_h / 90, mage_w / 3, mage_w / 4);

            if (pause && !mage_die && Main_Menu)
            {
                g.DrawImage(Pause, P_X, P_Y, P_W, P_H);
                g.DrawImage(RST, P_X + P_W / 7, P_Y + P_H - (P_H / 6), P_W / 3, P_H / 4);
                g.DrawImage(Ext, P_X + (P_X / 2) + P_W / 6, P_Y + P_H - (P_H / 4) + (P_H / 50), P_W / 2, (P_H / 3) + P_H / 20);

            }
            if (mage_die)
            {
                g.DrawImage(G_O, GO_X, GO_Y, GO_W, GO_H);
                g.DrawImage(No, No_X, YesNo_Y, YesNo_W, YesNo_H);
                g.DrawImage(Yes, Yes_X, YesNo_Y, YesNo_W, YesNo_H);
            }
            if (mouse_over_yes || mouse_over_no || mouse_over_ext || mouse_over_rst)
            {
                g.DrawImage(M_O_YesNo, MousePosition.X - screen_w / 80, MousePosition.Y - screen_h / 25, screen_w / 40, screen_h / 30);
            }
            for (int i = 0; i < 5; i++)
            {
                if (F[i].GetShoot() == true && Arcade)
                {

                    F[i].draw_shot(g, mage_w / 2, mage_h / 2, screen_w, screen_h, shottype);

                }
            }
            for (int i = 0; i < 50; i++)
            {
                if (Fs[i].GetShoot() == true && Survival)
                {

                    Fs[i].draw_shot(g, mage_w / 2, mage_h / 2, screen_w, screen_h, shottype);

                }
            }
            if (lvl_1_draw && !pause)
            {
                g.DrawImage(LVL_1, screen_w / 4, screen_h / 6, screen_w / 2, screen_h / 2);
            }
            if (completed || completed_2)
            {
                if (!pause)
                    g.DrawImage(COMPLETED, screen_w / 6, screen_h / 6, screen_w / 2 + screen_w / 4, screen_h / 2);
            }
            if (lvl_2_draw && !pause)
            {
                g.DrawImage(LVL_2, screen_w / 4, screen_h / 6, screen_w / 2, screen_h / 2);

            }
            if (boss_lvl_draw && !pause)
            {
                g.DrawImage(BOSS_LVL, screen_w / 4, screen_h / 6, screen_w / 2, screen_h / 2);

            }
        }

        private void InitGfx()
        {

            MainMenu.Play();                                                                        //added







            // screen_w = this.Size.Width;
            // screen_h = this.Size.Height;
            map_x = 0;
            map_y = 0;
            map_h = screen_h;
            map_w = screen_w;

            //mage_h = 32;
            //mage_w = 32;
            P_W = screen_w / 2;
            P_H = screen_h / 3;
            P_X = screen_w / 4;
            P_Y = screen_h / 4;

            mage_x = screen_w / 2;
            mage_y = screen_w - mage_h;
            mage_walk_counter = 0;
            mage_run_counter = 0;
            mage_step = ((screen_h / 100) + (screen_w / 100)) / 2;
            HP_1 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
            HP_2 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
            HP_3 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
            sheild = new Sheild(r.Next(0, screen_w), r.Next(0, screen_h), mage_w / 4, mage_w / 4);
            sheild2 = new Sheild(r.Next(0, screen_w), r.Next(0, screen_h), mage_w / 4, mage_w / 4);
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
            F = new fireshot[5];
            F[0] = new fireshot();
            F[1] = new fireshot();
            F[2] = new fireshot();
            F[3] = new fireshot();
            F[4] = new fireshot();
            Z_x = r.Next(0, screen_w);
            Z_y = r.Next(0, screen_h);
            zombies = new Zombie[0];
            skeletonss = new Skeleton[0];
            Fs = new fireshot[50];
            for (int i = 0; i < 50; i++)
            {
                Fs[i] = new fireshot();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Main_Menu == true)                                                                                                               //Added
            {

                Levels.Stop();
                Boss.Stop();


            }

            else if (lvl_1_draw == true || lvl_2_draw == true)
            {
                MainMenu.Stop();
                Levels.Play();

            }
            else if (BOSS_LEVEL == true)
            {
                Levels.Stop();
                Boss.Play();

            }
            else
                MainMenu.Play();


            if (!Main_Menu)
            {
                if (Math.Abs(mage_x - screen_w / 15) < mage_w / 3 && Math.Abs(mage_y - (screen_h / 2 + mage_h / 3)) < mage_h)
                {
                    Application.Exit();
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
                    if (!Arcade && !Survival)
                    {
                        if (mage_y > (screen_h - screen_h / 2 + mage_h))
                        {
                            if (run == false)
                            {
                                mage_y -= mage_step + 2;
                            }
                            else
                                mage_y -= mage_step + 4;
                        }
                    }
                    else if (mage_y > 0)
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
                if (Math.Abs(mage_x - screen_w / 3) < mage_w / 2 && Math.Abs(mage_y - (screen_h - screen_h / 2 + mage_h)) < mage_h)
                {
                    Arcade = true;
                    Survival = false;
                }
                else if (Math.Abs(mage_x - (screen_w / 3) * 2) < mage_w && Math.Abs(mage_y - (screen_h - screen_h / 2 + mage_h)) < mage_h)
                {
                    Survival = true;
                    Arcade = false;
                }

                if (mage_y < mage_h / 2)
                {
                    mage_y = screen_h - mage_h;
                    Main_Menu = true;
                }
                if (restart)
                {

                    zombies_1 = new Zombie[17];
                    for (i = 0; i < zombies_1.Length; i++)
                    {
                        Z_x = r.Next(0, screen_w);
                        Z_y = r.Next(0, screen_h);
                        zombies_1[i] = new Zombie(Z_x, Z_y, mage_w, mage_h);
                        rc++;
                    }
                    zombies_2 = new Zombie[15];
                    for (i = 0; i < zombies_2.Length; i++)
                    {
                        Z_x = r.Next(0, screen_w);
                        Z_y = r.Next(0, screen_h);
                        zombies_2[i] = new Zombie(Z_x, Z_y, mage_w, mage_h);
                        rc++;
                    }
                    skeletons = new Skeleton[35];
                    for (i = 0; i < skeletons.Length; i++)
                    {
                        S_x = r.Next(0, screen_w);
                        S_y = r.Next(0, screen_h);
                        skeletons[i] = new Skeleton(S_x, S_y, mage_w, mage_h);
                        rc++;
                    }
                    for (i = 0; i < F.Length; i++)
                    {
                        F[i] = new fireshot();
                        rc++;
                    }
                    Health = new int[100];

                    zombie1_time_counter = init_zombie1_time_counter;
                    zombie2_time_counter = init_zombie2_time_counter;
                    skeleton_time_counter = init_skeleton_time_counter;
                }
                if (rc == 72)
                {
                    rc = 0;
                    mouse_over_yes = false;
                    mouse_over_rst = false;
                    restart = false;
                }
                Invalidate();
            }
            if (Main_Menu && Arcade)
            {
                timer3.Stop();

                if (rc == 0)
                {
                    GO_W = screen_w / 2;
                    GO_H = screen_h / 3;
                    GO_X = screen_w / 2 - GO_W / 2;
                    GO_Y = screen_h / 2 - GO_H;
                    YesNo_W = GO_W / 5;
                    YesNo_H = GO_H / 5;
                    Yes_X = screen_w / 2 - YesNo_W;
                    No_X = screen_w / 2;
                    YesNo_Y = GO_Y + GO_H + (YesNo_H / 2);

                    if (!LEVEL1 && !LEVEL2)
                    {
                        lvl_1_time--;
                        if (lvl_1_time > 0)
                        {
                            lvl_1_draw = true;
                        }
                        else
                        {
                            lvl_1_draw = false;
                        }
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
                        P_H = screen_h / 3;
                        P_X = screen_w / 4;
                        P_Y = screen_h / 4;
                        zombies_1_dead = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            if (F[i].Gethit() == false)
                            {

                                if (F[i].Getdir() == 2)
                                    F[i].SetX(F[i].GetX() + 10);
                                else
                                    F[i].SetX(F[i].GetX() - 10);
                            }
                        }
                        for (int j = 0; j < zombies_1.Length; j++)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                if (Math.Abs(F[i].GetX() - zombies_1[j].GetX()) < mage_w / 2 && Math.Abs(F[i].GetY() - zombies_1[j].GetY()) < mage_h / 2 && !F[i].Gethit() && !zombies_1[j].die)
                                {


                                    zombies_1[j].search = false;
                                    zombies_1[j].die = true;
                                    zombies_1[j].shot = true;
                                    F[i].Sethit(true);
                                }

                            }
                        }
                        Invalidate();
                    }
                    if (!health_counted && !sh && !completed)
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
                                    completed = true;
                                }
                            }
                        }
                    }

                    if (LEVEL1 && !LEVEL2)
                    {
                        if (!new_map_1)
                        {

                            for (int i = 0; i < F.Length; i++)
                            {
                                F[i] = new fireshot();
                            }
                        }
                        if (!mage_die)
                        {

                            if (mage_x > screen_w - mage_w && mapI == 0)
                            {
                                health_counter = 0;
                                mapI = 2;
                                mage_x = mage_w;
                                new_map_1 = true;
                                for (int o = 0; o < Health.Length; o++)
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
                            completed = false;
                            lvl_2_time--;
                            if (lvl_2_time > 0)
                            {
                                lvl_2_draw = true;
                            }
                            else
                            {
                                lvl_2_draw = false;
                            }


                            if (!mage_die)
                            {
                                if (((skeleton_counter) < skeletons.Length) && (skeleton_time_counter == 0))
                                {
                                    skeletons[skeleton_counter].ready = true;
                                    skeleton_counter++;
                                }
                                skeleton_time_counter = skeleton_time_counter == 0 ? 20 : skeleton_time_counter - 1;
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
                                                        if (!sh)
                                                        {
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


                                                if (Math.Abs(skeletons[i].GetX() - mage_x) < mage_w / 2 && Math.Abs(skeletons[i].GetY() - mage_y) < mage_h / 2)
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
                                for (int i = 0; i < 5; i++)
                                {
                                    if (F[i].Gethit() == false)
                                    {

                                        if (F[i].Getdir() == 2)
                                            F[i].SetX(F[i].GetX() + 10);
                                        else
                                            F[i].SetX(F[i].GetX() - 10);
                                    }
                                }
                                for (int j = 0; j < zombies_2.Length; j++)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (Math.Abs(F[i].GetX() - zombies_2[j].GetX()) < mage_w / 2 && Math.Abs(F[i].GetY() - zombies_2[j].GetY()) < mage_h / 2 && !F[i].Gethit() && !zombies_2[j].die)
                                        {


                                            zombies_2[j].search = false;
                                            zombies_2[j].die = true;
                                            zombies_2[j].shot = true;
                                            F[i].Sethit(true);
                                        }

                                    }
                                }
                                for (int j = 0; j < skeletons.Length; j++)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        if (Math.Abs(F[i].GetX() - skeletons[j].GetX()) < mage_w / 2 && Math.Abs(F[i].GetY() - skeletons[j].GetY()) < mage_h / 2 && !F[i].Gethit() && !skeletons[j].die)
                                        {


                                            skeletons[j].search = false;
                                            skeletons[j].die = true;
                                            skeletons[j].shot = true;
                                            F[i].Sethit(true);
                                        }

                                    }
                                }
                            }




                            if (mage_die)
                            {
                                if ((mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
                                    mage_die_counter++;

                            }


                            P_W = screen_w / 2;
                            P_H = screen_h / 3;
                            P_X = screen_w / 4;
                            P_Y = screen_h / 4;


                        }
                        Invalidate();
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



                    }
                    if (zombies_2 != null)
                    {
                        zombies_2_dead = 0;
                        for (i = 0; i < zombies_2.Length; i++)
                        {
                            if (zombies_2[i].die)
                            {

                                zombies_2_dead++;


                            }
                        }
                    }
                    if (skeletons != null)
                    {
                        skeletons_dead = 0;
                        for (i = 0; i < skeletons.Length; i++)
                        {
                            if (skeletons[i].die)
                            {
                                skeletons_dead++;

                            }
                            if ((i == skeletons.Length - 1) && (skeletons_dead < skeletons.Length))
                                skeletons_dead = 0;
                        }
                    }



                    if (skeletons_dead + zombies_2_dead == 50)
                    {
                        LEVEL2 = true;
                        LEVEL1 = false;
                        completed_2 = true;

                    }






                    if (LEVEL2)
                    {
                        if (!new_map_2)
                        {

                            for (int i = 0; i < F.Length; i++)
                            {
                                F[i] = new fireshot();
                            }
                        }
                        if (new_map_2)
                        {
                            completed_2 = false;
                            boss_lvl_time--;
                            if (boss_lvl_time > 0)
                            {
                                boss_lvl_draw = true;
                            }
                            else
                            {
                                boss_lvl_draw = false;
                            }
                            for (int i = 0; i < 5; i++)
                            {
                                if (F[i].Gethit() == false)
                                {

                                    if (F[i].Getdir() == 2)
                                        F[i].SetX(F[i].GetX() + 10);
                                    else
                                        F[i].SetX(F[i].GetX() - 10);
                                }
                            }
                        }
                        if (!mage_die)
                        {

                            if (mage_y < mage_h / 3 && mapI == 2)
                            {
                                health_counter = 0;
                                mapI = 3;
                                mage_y = screen_h + mage_h / 2;
                                new_map_2 = true;
                                for (int o = 0; o < Health.Length; o++)
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
                            zombies_2 = null;
                            skeletons = null;
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


                        Invalidate();
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
            if (Main_Menu && Survival)
            {
                mapI = 2;
                shottype = 2;
                for (int i = 0; i < 50; i++)
                {
                    if (Fs[i].Gethit() == false)
                    {

                        if (Fs[i].Getdir() == 2)
                            Fs[i].SetX(Fs[i].GetX() + 10);
                        else
                            Fs[i].SetX(Fs[i].GetX() - 10);
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



                if (mage_die)
                {
                    if ((mage_die_counter != mage_die_L.Length) && (mage_die_counter != mage_die_R.Length))
                        mage_die_counter++;

                }

                P_W = screen_w / 2;
                P_H = screen_h / 3;
                P_X = screen_w / 4;
                P_Y = screen_h / 4;
                Invalidate();
            }


            if (save)
            {
                
                gameState.mage_walk_counter = mage_walk_counter;
                gameState.mage_run_counter = mage_run_counter;
                gameState.mage_atk_counter = mage_atk_counter;
                gameState.mage_die_counter = mage_die_counter;
                gameState.HP_counter = HP_counter;
                gameState.mage_step= mage_step;
                gameState.screen_w = screen_w;
                gameState.screen_h = screen_h;
                gameState.mage_x = mage_x;
                gameState.mage_y = mage_y;
                gameState.mage_h = mage_h;
                gameState.mage_w = mage_w;
                gameState.Main_Menu = Main_Menu;
                gameState.main_counter = main_counter;
                gameState.Arcade = Arcade;
                gameState.Survival = Survival;
                gameState.rx=rx;
                gameState.Health= Health ;
                gameState.map_x = map_x;
                gameState.map_y = map_y;
                gameState.map_w = map_w;
                gameState.map_h = map_h;
                gameState.mapI=mapI;
                gameState.rc = rc;
                gameState.Z_x = Z_x;
                gameState.Z_y = Z_y;
                gameState.S_x = S_x;
                gameState.S_y = S_y;
                gameState.P_X = P_X;
                gameState.P_Y = P_Y;
                gameState.P_W = P_W;
                gameState.P_H = P_H;
                gameState.GO_X = GO_X;
                gameState.GO_Y = GO_Y;
                gameState.GO_W = GO_W;
                gameState.GO_H = GO_H;
                gameState.No_X = No_X;
                gameState.Yes_X = Yes_X;
                gameState.YesNo_Y = YesNo_Y;
                gameState.YesNo_W = YesNo_W;
                gameState.YesNo_H=YesNo_H;
                gameState.shottype=shottype;
                gameState.completed=completed;
                gameState.restart=restart;
                gameState.potion_count=potion_count;
                gameState.sheild_counter=sheild_counter;
                gameState.sheild_Time = sheild_Time;
                gameState.HP1_X = HP1_X;
                gameState.HP2_X= HP2_X;
                gameState.HP1_Y = HP1_Y;
                gameState.HP2_Y = HP2_Y;
                gameState.HP3_X = HP3_X;
                gameState.HP3_Y = HP3_Y;
                gameState.sheild_x = sheild_x;
                gameState.sheild_y = sheild_y;
                gameState.sheild2_x = sheild2_x;
                gameState.sheild2_y = sheild2_y;
                gameState.zombies_1_dead=zombies_1_dead;
                gameState.zombies_2_dead=zombies_2_dead;
                gameState.skeletons_dead = skeletons_dead;
                gameState.health_counter_i=health_counter_i;
                gameState.esc_counter = esc_counter;
                gameState.sheild_count=sheild_count;
                gameState.r = r;
                gameState.moveup=moveup;
                gameState.movedown=movedown;
                gameState.moveleft=moveleft;
                gameState.moveright=moveright;
                gameState.mage_die = mage_die;
                gameState.L = L;
                gameState.R = R;
                gameState.run=run;
                gameState.attack=attack;
                gameState.DR=DR;
                gameState.Dl=Dl;
                gameState.health_counted=health_counted;
                gameState.pause=pause;
                gameState.LEVEL1 = LEVEL1;
                gameState.LEVEL2=LEVEL2;
                gameState.BOSS_LEVEL=BOSS_LEVEL;
                gameState.new_map_1=new_map_1;
                gameState.new_map_2=new_map_2;
                gameState.sh=sh;
                gameState.mouse_over_yes=mouse_over_yes;
                gameState.mouse_over_no=mouse_over_no;
                gameState.mouse_over_rst=mouse_over_rst;
                gameState.mouse_over_ext=mouse_over_ext;
                gameState.completed_2=completed_2;

                gameState.zombie1_counter = zombie1_counter;
                gameState.zombie2_counter = zombie2_counter;
                gameState.skeleton_counter = skeleton_counter;

                gameState.zombie1_time_counter = zombie1_time_counter;
                gameState.zombie2_time_counter=zombie2_time_counter;
                gameState.init_zombie1_time_counter=init_zombie1_time_counter;
                gameState.init_zombie2_time_counter = init_zombie2_time_counter;
                gameState.skeleton_time_counter=skeleton_time_counter;
                gameState.init_skeleton_time_counter= init_skeleton_time_counter;
                gameState.health_counter = health_counter;
                gameState.i = i;
                gameState.lvl_1_time=lvl_1_time;
                gameState.lvl_1_draw = lvl_1_draw;
                gameState.lvl_2_time=lvl_2_time;
                gameState.lvl_2_draw=lvl_2_draw;
                gameState.boss_lvl_time=boss_lvl_time;
                gameState.boss_lvl_draw=boss_lvl_draw;

                gameState.shotx = shotx;
                gameState.shoty=shoty;
                gameState.shotcounter=shotcounter;


                string json = JsonConvert.SerializeObject(gameState);
                File.WriteAllText("savegame.json", json);

                save = false;

            }
            if(load)
            {
                if (File.Exists("savegame.json"))
                {
                    string json = File.ReadAllText("savegame.json");
                    GameState gameState = JsonConvert.DeserializeObject<GameState>(json);

                    // Use the gameState object to restore the game state

                    mage_walk_counter = gameState.mage_walk_counter;
                    mage_run_counter = gameState.mage_run_counter;
                    mage_atk_counter = gameState.mage_atk_counter;
                    mage_die_counter = gameState.mage_die_counter;
                    HP_counter = gameState.HP_counter;
                    mage_step = gameState.mage_step;
                    screen_w = gameState.screen_w;
                    screen_h = gameState.screen_h;
                    mage_x = gameState.mage_x;
                    mage_y = gameState.mage_y;
                    mage_h = gameState.mage_h;
                    mage_w = gameState.mage_w;
                    Main_Menu = gameState.Main_Menu;
                    main_counter = gameState.main_counter;
                    Arcade = gameState.Arcade;
                    Survival = gameState.Survival;
                    rx = gameState.rx;
                    Health = gameState.Health;
                    map_x = gameState.map_x;
                    map_y = gameState.map_y;
                    map_w = gameState.map_w;
                    map_h = gameState.map_h;
                    mapI = gameState.mapI;
                    rc = gameState.rc;
                    Z_x = gameState.Z_x;
                    Z_y = gameState.Z_y;
                    S_x = gameState.S_x;
                    S_y = gameState.S_y;
                    P_X = gameState.P_X;
                    P_Y = gameState.P_Y;
                    P_W = gameState.P_W;
                    P_H = gameState.P_H;
                    GO_X = gameState.GO_X;
                    GO_Y = gameState.GO_Y;
                    GO_W = gameState.GO_W;
                    GO_H = gameState.GO_H;
                    No_X = gameState.No_X;
                    Yes_X = gameState.Yes_X;
                    YesNo_Y = gameState.YesNo_Y;
                    YesNo_W = gameState.YesNo_W;
                    YesNo_H = gameState.YesNo_H;
                    shottype = gameState.shottype;
                    completed = gameState.completed;
                    restart = gameState.restart;
                    potion_count = gameState.potion_count;
                    sheild_counter = gameState.sheild_counter;
                    sheild_Time = gameState.sheild_Time;
                    HP1_X = gameState.HP1_X;
                    HP2_X = gameState.HP2_X;
                    HP1_Y = gameState.HP1_Y;
                    HP2_Y = gameState.HP2_Y;
                    HP3_X = gameState.HP3_X;
                    HP3_Y = gameState.HP3_Y;
                    sheild_x = gameState.sheild_x;
                    sheild_y = gameState.sheild_y;
                    sheild2_x = gameState.sheild2_x;
                    sheild2_y = gameState.sheild2_y;
                    zombies_1_dead = gameState.zombies_1_dead;
                    zombies_2_dead = gameState.zombies_2_dead;
                    skeletons_dead = gameState.skeletons_dead;
                    health_counter_i = gameState.health_counter_i;
                    esc_counter = gameState.esc_counter;
                    sheild_count = gameState.sheild_count;
                    r = gameState.r;
                    moveup = gameState.moveup;
                    movedown = gameState.movedown;
                    moveleft = gameState.moveleft;
                    moveright = gameState.moveright;
                    mage_die = gameState.mage_die;
                    L = gameState.L;
                    R = gameState.R;
                    run = gameState.run;
                    attack = gameState.attack;
                    DR = gameState.DR;
                    Dl = gameState.Dl;
                    health_counted = gameState.health_counted;
                    pause = gameState.pause;
                    LEVEL1 = gameState.LEVEL1;
                    LEVEL2 = gameState.LEVEL2;
                    BOSS_LEVEL = gameState.BOSS_LEVEL;
                    new_map_1 = gameState.new_map_1;
                    new_map_2 = gameState.new_map_2;
                    sh = gameState.sh;
                    mouse_over_yes = gameState.mouse_over_yes;
                    mouse_over_no = gameState.mouse_over_no;
                    mouse_over_rst = gameState.mouse_over_rst;
                    mouse_over_ext = gameState.mouse_over_ext;
                    completed_2 = gameState.completed_2;

                    zombie1_counter = gameState.zombie1_counter;
                    zombie2_counter = gameState.zombie2_counter;
                    skeleton_counter = gameState.skeleton_counter;

                    zombie1_time_counter = gameState.zombie1_time_counter;
                    zombie2_time_counter = gameState.zombie2_time_counter;
                    init_zombie1_time_counter = gameState.init_zombie1_time_counter;
                    init_zombie2_time_counter = gameState.init_zombie2_time_counter;
                    skeleton_time_counter = gameState.skeleton_time_counter;
                    init_skeleton_time_counter = gameState.init_skeleton_time_counter;
                    health_counter = gameState.health_counter;
                    i = gameState.i;
                    lvl_1_time = gameState.lvl_1_time;
                    lvl_1_draw = gameState.lvl_1_draw;
                    lvl_2_time = gameState.lvl_2_time;
                    lvl_2_draw = gameState.lvl_2_draw;
                    boss_lvl_time = gameState.boss_lvl_time;
                    boss_lvl_draw = gameState.boss_lvl_draw;

                    shotx = gameState.shotx;
                    shoty = gameState.shoty;
                    shotcounter = gameState.shotcounter;

                }
                else
                {
                    // Handle the case when no saved game exists
                }
                load = false;
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
                    timer3.Start();
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
                timer3.Stop();
                load = true;
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
                if (e.KeyCode == Keys.Space)
                {
                    if (Arcade)
                    {
                        if (Dl == true)
                            F[shotcounter].Setdir(1);
                        else
                            F[shotcounter].Setdir(2);
                        F[shotcounter].SetX(mage_x + (mage_w / 2));
                        F[shotcounter].SetY(mage_y + (mage_h / 2));
                        F[shotcounter].SetShoot(true);
                        shotcounter++;
                        if (shotcounter > 4)
                            shotcounter = 0;
                        F[shotcounter].Sethit(false);
                    }
                    if (Survival)
                    {
                        if (Dl == true)
                            Fs[shotcounter].Setdir(1);
                        else
                            Fs[shotcounter].Setdir(2);
                        Fs[shotcounter].SetX(mage_x + (mage_w / 2));
                        Fs[shotcounter].SetY(mage_y + (mage_h / 2));
                        Fs[shotcounter].SetShoot(true);
                        shotcounter++;
                        if (shotcounter > 50)
                            shotcounter = 0;
                        Fs[shotcounter].Sethit(false);
                    }


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
            P_H = screen_h / 3;
            P_X = screen_w / 4;
            P_Y = screen_h / 4;
            mage_h = screen_h / 12;
            mage_w = screen_w / 12;

            Invalidate();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            attack = true;


            if (mouse_over_yes || mouse_over_rst)
            {

                timer1.Start();
                timer2.Start();
                timer3.Stop();
                mage_walk_counter = 0;
                mage_run_counter = 0;
                mage_atk_counter = 0;
                mage_die_counter = 0;
                HP_counter = 0;
                Health = new int[100];
                shottype = 1;
                mapI = 0;
                zombie2_counter = 0;
                skeleton_counter = 0;
                potion_count = 0;
                sheild_counter = 0;
                sheild_Time = 100;
                zombie1_counter = 0;
                zombies_1_dead = 0;
                zombies_2_dead = 0;
                skeletons_dead = 0;
                health_counter_i = 0;
                esc_counter = 0;
                sheild_count = 0;
                restart = true;
                moveup = false;
                moveleft = false;
                moveright = false;
                mage_die = false;
                L = false;
                R = false;
                run = false;
                attack = false;
                DR = false;
                Dl = false;
                health_counted = false;
                pause = false;
                LEVEL1 = false;
                LEVEL2 = false;
                BOSS_LEVEL = false;
                Arcade = false;
                Survival = false;
                Main_Menu = false;
                new_map_1 = false;
                sh = false;
                mouse_over_yes = false;
                mouse_over_no = false;
                mouse_over_rst = false;
                lvl_1_draw = false;
                lvl_1_time = 60;
                init_zombie1_time_counter = 80;
                init_zombie2_time_counter = 80;
                HP_counter = 0;
                new_map_2 = false;
                init_skeleton_time_counter = 100;
                health_counter = 0;
                lvl_2_time = 60;
                lvl_2_draw = false;
                boss_lvl_draw = false;
                boss_lvl_time = 40;
                HP_1 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
                HP_2 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
                HP_3 = new Healing_Potion(r.Next(0, screen_w), r.Next(0, screen_h), mage_w, mage_h);
                sheild = new Sheild(r.Next(0, screen_w), r.Next(0, screen_h), mage_w / 4, mage_w / 4);
                sheild2 = new Sheild(r.Next(0, screen_w), r.Next(0, screen_h), mage_w / 4, mage_w / 4);
                zombie = new Zombie(Z_x, Z_y, mage_w, mage_h);


                zombie1_time_counter = init_zombie1_time_counter;
                zombie2_time_counter = init_zombie2_time_counter;
                skeleton_time_counter = init_skeleton_time_counter;




            }
            if (mouse_over_no || mouse_over_ext)
            {
                Application.Exit();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Main_Menu && Arcade) {
                if (!LEVEL1)
                {
                    HP1_X = HP_1.GetX();
                    HP1_Y = HP_1.GetY();
                    HP_counter++;
                    if (potion_count < 1)
                    {

                        if (HP_counter > 350 && !HP_1.ready)
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

                if (LEVEL1 && !LEVEL2 && new_map_1)
                {
                    HP2_X = HP_2.GetX();
                    HP2_Y = HP_2.GetY();
                    sheild_x = sheild.GetX();
                    sheild_y = sheild.GetY();
                    HP_counter++;
                    sheild_counter++;
                    if (sheild_count < 1)
                    {
                        if (sheild_counter > 350 && !sheild.ready)
                        {
                            sheild.ready = true;
                            sheild.took = false;
                        }
                        if (sheild.ready && !sheild.took)
                        {
                            if (Math.Abs(sheild_x - mage_x) < mage_w / 3)
                            {
                                if (Math.Abs(sheild_y - mage_y) < mage_h / 3)
                                {
                                    sheild.took = true;
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
                                sh = false;
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
                            HP_counter = 0;
                        }

                    }
                }
                if (LEVEL2 && new_map_2)
                {
                    HP3_X = HP_3.GetX();
                    HP3_Y = HP_3.GetY();
                    sheild_x = sheild2.GetX();
                    sheild_y = sheild2.GetY();
                    sheild_Time = 300;

                    HP_counter++;
                    sheild_counter++;
                    if (sheild_count < 3)
                    {

                        if (sheild_counter > 350 && !sheild2.ready)
                        {
                            sheild2.ready = true;
                            sheild2.took = false;
                        }
                        if (sheild2.ready && !sheild2.took)
                        {
                            if (Math.Abs(sheild_x - mage_x) < mage_w / 3)
                            {
                                if (Math.Abs(sheild_y - mage_y) < mage_h / 3)
                                {
                                    sheild2.took = true;

                                }
                            }
                        }
                        if (sheild2.ready && sheild2.took)
                        {
                            if (sheild_Time > 0)
                            {
                                sh = true;
                                sheild_Time--;
                            }
                            else
                            {
                                sheild2.ready = false;
                                sheild2.took = false;
                                sh = false;
                                sheild_count++;
                            }

                        }

                    }




                    if (potion_count < 3)
                    {

                        if (HP_counter > 350 && !HP_3.ready)
                        {
                            HP_3.ready = true;
                            HP_3.took = false;

                        }
                        if (HP_3.ready && !HP_3.took)
                        {
                            if (Math.Abs(HP2_X - mage_x) < mage_w / 3)
                            {
                                if (Math.Abs(HP2_Y - mage_y) < mage_h / 3)
                                {
                                    HP_3.took = true;
                                }
                            }



                        }

                        if (HP_3.ready && HP_3.took)
                        {
                            for (int h = 0; h < Health.Length; h++)
                            {
                                health_counter = 0;
                                Health[h] = 0;
                                if (h == Health.Length - 1)
                                {
                                    HP_3.ready = false;
                                    HP_3.took = false;
                                    potion_count++;
                                    HP_3.SetX(r.Next(0, screen_w));
                                    HP_3.SetY(r.Next(0, screen_h));
                                }

                            }

                        }

                    }
                }
            }


        }

        private void Mouse_Hover(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (pause && (Arcade || Survival))
            {



                if ((Math.Abs((P_X + P_W / 7) - MousePosition.X)) < P_W / 3 && Math.Abs((P_Y + P_H - (P_H / 6)) - MousePosition.Y) < (P_H / 4) && MousePosition.X > (P_X + P_W / 7) && MousePosition.Y > P_Y + P_H - (P_H / 6))
                {
                    mouse_over_rst = true;
                    mouse_over_ext = false;

                }
                else if ((Math.Abs((P_X + (P_X / 2) + P_W / 6) - MousePosition.X) < (P_W / 2) && Math.Abs((P_Y + P_H - (P_H / 4) + (P_H / 50)) - MousePosition.Y) < ((P_H / 3) + P_H / 20) && MousePosition.X > (P_X + (P_X / 2) + P_W / 6) && MousePosition.Y > (P_Y + P_H - (P_H / 4) + (P_H / 50))))
                {
                    mouse_over_ext = true;
                    mouse_over_rst = false;

                }
                else
                {
                    mouse_over_rst = false;
                    mouse_over_ext = false;

                }
            }
            Invalidate();
        }

       
    }
   
}
        
    



