using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSlayer
{
    internal class fireshot
    {
        Image img;
        Image[] fireR = { Image.FromFile("images\\fireshot\\fireR_1.png"), Image.FromFile("images\\fireshot\\fireR_2.png"), Image.FromFile("images\\fireshot\\fireR_3.png"), Image.FromFile("images\\fireshot\\fireR_4.png"), Image.FromFile("images\\fireshot\\fireR_5.png") };
        Image[] fireL = { Image.FromFile("images\\fireshot\\fireL_1.png"), Image.FromFile("images\\fireshot\\fireL_2.png"), Image.FromFile("images\\fireshot\\fireL_3.png"), Image.FromFile("images\\fireshot\\fireL_4.png"), Image.FromFile("images\\fireshot\\fireL_5.png") };

        Image[] fire_hit = { Image.FromFile("images\\fireshot\\hit_1.png"), Image.FromFile("images\\fireshot\\hit_2.png"), Image.FromFile("images\\fireshot\\hit_3.png"), Image.FromFile("images\\fireshot\\hit_4.png") };


        Image[] fireR1 = { Image.FromFile("images\\fireshot\\fireR1_1.png"), Image.FromFile("images\\fireshot\\fireR1_2.png") };
        Image[] fireL1 = { Image.FromFile("images\\fireshot\\fireL1_1.png"), Image.FromFile("images\\fireshot\\fireL1_2.png") };

        Image[] fire_hit1 = { Image.FromFile("images\\fireshot\\hit1_1.png"), Image.FromFile("images\\fireshot\\hit1_2.png") };

        public bool ready = false;
        public bool took = false;
        int x;//shotX
        int y;//shotY
        int w;
        int h;
        int Tx;//tagetX
        int Ty;//tagerY
        int counter = 0;
        int counter2 = 0;
        int counter3 = 0;
        bool shoot = false;
        int dir = 2;
        bool hit = false;

        public fireshot()
        {


        }
        public fireshot(int x, int y, int w, int h, int Tx, int Ty)
        {
            this.h = h;
            this.w = w;
            this.x = x;
            this.y = y;
            this.Tx = Tx;
            this.Ty = Ty;

        }
        public void SetX(int x)
        {
            this.x = x;
        }
        public void SetY(int y)
        {
            this.y = y;
        }
        public int GetX()
        {
            return this.x;
        }
        public int GetY()
        {
            return this.y;
        }
        public void SetTx(int Tx)
        {
            this.Tx = Tx;
        }
        public void SetTy(int Ty)
        {
            this.Ty = Ty;
        }
        public int GetTx()
        {
            return this.Tx;
        }
        public int GetTy()
        {
            return this.Ty;
        }
        public void SetShoot(bool x)
        {
            shoot = x;
        }
        public bool GetShoot()
        {
            return shoot;
        }
        public void Setdir(int dir)
        {
            this.dir = dir;
        }
        public int Getdir()
        {
            return dir;
        }
        public void Sethit(bool hit)
        {
            this.hit = hit;
        }

        public bool Gethit()
        {
            return this.hit;
        }


        public void draw_shot(Graphics gfx, int w, int h, int Tx, int Ty, int type)
        {

            if (type == 1)
            {
                if (dir == 1 && hit == false)
                {
                    img = fireL[counter];

                }
                else if (dir == 2 && hit == false)
                {
                    img = fireR[counter];

                }
                else
                {
                    img = fire_hit[counter3];

                }
            }
            if (type == 2)
            {
                if (dir == 1 && hit == false)
                {
                    img = fireL1[counter2];

                }
                else if (dir == 2 && hit == false)
                {
                    img = fireR1[counter2];


                }
                else
                {
                    img = fire_hit1[counter2];

                }
            }

            counter++;
            counter2++;
            counter3++;
            if (counter == 4)
                counter = 0;
            if (counter2 == 1)
                counter2 = 0;
            if (counter3 == 3)
            {
                counter3 = 0;

            }


            gfx.DrawImage(img, x, y, w, h);
        }
    }
}
