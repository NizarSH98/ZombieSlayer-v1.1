using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace ZombieSlayer
{
    class Boss
    {

        int x, y, h, w;
        Image img;
        Image[] img_walking_r = { Image.FromFile("images\\Boss\\movR_1.png"), Image.FromFile("images\\Boss\\movR_1.png"), Image.FromFile("images\\Boss\\movR_1.png"), Image.FromFile("images\\Boss\\movR_2.png"), Image.FromFile("images\\Boss\\movR_2.png"), Image.FromFile("images\\Boss\\movR_2.png"), Image.FromFile("images\\Boss\\movR_3.png"), Image.FromFile("images\\Boss\\movR_3.png"), Image.FromFile("images\\Boss\\movR_3.png"), Image.FromFile("images\\Boss\\movR_4.png"), Image.FromFile("images\\Boss\\movR_4.png"), Image.FromFile("images\\Boss\\movR_4.png") ,Image.FromFile("images\\Boss\\movR_5.png"), Image.FromFile("images\\Boss\\movR_5.png"), Image.FromFile("images\\Boss\\movR_5.png") };
        Image[] img_walking_l = { Image.FromFile("images\\Boss\\movL_1.png"), Image.FromFile("images\\Boss\\movL_1.png"), Image.FromFile("images\\Boss\\movL_1.png"), Image.FromFile("images\\Boss\\movL_2.png"), Image.FromFile("images\\Boss\\movL_2.png"), Image.FromFile("images\\Boss\\movL_2.png"), Image.FromFile("images\\Boss\\movL_3.png"), Image.FromFile("images\\Boss\\movL_3.png"), Image.FromFile("images\\Boss\\movL_3.png"), Image.FromFile("images\\Boss\\movL_4.png"), Image.FromFile("images\\Boss\\movL_4.png"), Image.FromFile("images\\Boss\\movL_4.png"), Image.FromFile("images\\Boss\\movL_5.png"), Image.FromFile("images\\Boss\\movL_5.png"), Image.FromFile("images\\Boss\\movL_5.png") };
        Image[] img_spawning = { Image.FromFile("images\\Boss\\portal.png"), Image.FromFile("images\\Boss\\start.png") };
        Image[] img_die_R = { Image.FromFile("images\\Boss\\dieR_1.png"), Image.FromFile("images\\Boss\\dieR_1.png"), Image.FromFile("images\\Boss\\dieR_1.png"), Image.FromFile("images\\Boss\\dieR_2.png"), Image.FromFile("images\\Boss\\dieR_2.png"), Image.FromFile("images\\Boss\\dieR_2.png"), Image.FromFile("images\\Boss\\dieR_3.png"), Image.FromFile("images\\Boss\\dieR_3.png"), Image.FromFile("images\\Boss\\dieR_3.png"), Image.FromFile("images\\Boss\\dieR_4.png"), Image.FromFile("images\\Boss\\dieR_4.png"), Image.FromFile("images\\Boss\\dieR_4.png") , Image.FromFile("images\\Boss\\dieR_5.png"), Image.FromFile("images\\Boss\\dieR_5.png"), Image.FromFile("images\\Boss\\dieR_5.png"), Image.FromFile("images\\Boss\\dieR_6.png"), Image.FromFile("images\\Boss\\dieR_6.png"), Image.FromFile("images\\Boss\\dieR_6.png"), Image.FromFile("images\\Boss\\dieR_7.png"), Image.FromFile("images\\Boss\\dieR_7.png"), Image.FromFile("images\\Boss\\dieR_7.png"), Image.FromFile("images\\Boss\\dieR_8.png"), Image.FromFile("images\\Boss\\dieR_8.png"), Image.FromFile("images\\Boss\\dieR_8.png") };
        Image[] img_die_L = { Image.FromFile("images\\Boss\\dieL_1.png"), Image.FromFile("images\\Boss\\dieL_1.png"), Image.FromFile("images\\Boss\\dieL_1.png"), Image.FromFile("images\\Boss\\dieL_2.png"), Image.FromFile("images\\Boss\\dieL_2.png"), Image.FromFile("images\\Boss\\dieL_2.png"), Image.FromFile("images\\Boss\\dieL_3.png"), Image.FromFile("images\\Boss\\dieL_3.png"), Image.FromFile("images\\Boss\\dieL_3.png"), Image.FromFile("images\\Boss\\dieL_4.png"), Image.FromFile("images\\Boss\\dieL_4.png"), Image.FromFile("images\\Boss\\dieL_4.png"), Image.FromFile("images\\Boss\\dieL_5.png"), Image.FromFile("images\\Boss\\dieL_5.png"), Image.FromFile("images\\Boss\\dieL_5.png"), Image.FromFile("images\\Boss\\dieL_6.png"), Image.FromFile("images\\Boss\\dieL_6.png"), Image.FromFile("images\\Boss\\dieL_6.png"), Image.FromFile("images\\Boss\\dieL_7.png"), Image.FromFile("images\\Boss\\dieL_7.png"), Image.FromFile("images\\Boss\\dieL_7.png"), Image.FromFile("images\\Boss\\dieL_8.png"), Image.FromFile("images\\Boss\\dieL_8.png"), Image.FromFile("images\\Boss\\dieL_8.png") };
        Image[] img_hitting_R = { Image.FromFile("images\\Boss\\hitR_1.png"), Image.FromFile("images\\Boss\\hitR_1.png"), Image.FromFile("images\\Boss\\hitR_1.png"), Image.FromFile("images\\Boss\\hitR_2.png"), Image.FromFile("images\\Boss\\hitR_2.png"), Image.FromFile("images\\Boss\\hitR_2.png"), Image.FromFile("images\\Boss\\hitR_3.png"), Image.FromFile("images\\Boss\\hitR_3.png"), Image.FromFile("images\\Boss\\hitR_3.png"), Image.FromFile("images\\Boss\\hitR_4.png"), Image.FromFile("images\\Boss\\hitR_4.png"), Image.FromFile("images\\Boss\\hitR_4.png"), Image.FromFile("images\\Boss\\hitR_5.png"), Image.FromFile("images\\Boss\\hitR_5.png"), Image.FromFile("images\\Boss\\hitR_5.png") };
        Image[] img_hitting_L = { Image.FromFile("images\\Boss\\hitL_1.png"), Image.FromFile("images\\Boss\\hitL_1.png"), Image.FromFile("images\\Boss\\hitL_1.png"), Image.FromFile("images\\Boss\\hitL_2.png"), Image.FromFile("images\\Boss\\hitL_2.png"), Image.FromFile("images\\Boss\\hitL_2.png"), Image.FromFile("images\\Boss\\hitL_3.png") , Image.FromFile("images\\Boss\\hitL_3.png"), Image.FromFile("images\\Boss\\hitL_3.png"), Image.FromFile("images\\Boss\\hitL_4.png"), Image.FromFile("images\\Boss\\hitL_4.png"), Image.FromFile("images\\Boss\\hitL_4.png"), Image.FromFile("images\\Boss\\hitL_5.png"), Image.FromFile("images\\Boss\\hitL_5.png"), Image.FromFile("images\\Boss\\hitL_5.png") };
       
        int counter_wr = 0;
        int counter_wl = 0;
        int counter_sp = 0;
        int counter_d = 0;
        int counter_hr = 0;
        int counter_hl = 0;
        int hits = 0;
        int b_die = 0;
        public const int PORTAL = -1;
        public const int STANDING = 0;
        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int DIE_R = 4;
        public const int DIE_L = 7;
        public const int HITTING_R = 5;
        public const int HITTING_L = 6;
        public int last_state = 0;
        public int state = 0;
        public bool ready = false;
        public bool die = false;
        public bool search = false;
        public bool shot = false;
        Random random = new Random();

        public int GetZD()
        {
            return b_die;
        }
        public void SetZD(int n)
        {
            this.b_die = n;
        }
        public int GetRX(int screen_w)
        {
            return random.Next(0, screen_w);
        }
        public int GetRY(int screen_h)
        {
            return random.Next(0, screen_h);
        }

        public Boss(int w, int h)
        {
            this.h = h;
            this.w = w;
           

        }
        public Boss(int x, int y, int w, int h)
        {
            this.h = h;
            this.w = w;
            this.x = x;
            this.y = y;

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
        public void Setstate(int state)
        {
            this.state = state;
        }
        public int GetSp()
        {
            return counter_sp;
        }
        public int GetLSp()
        {
            return img_spawning.Length;
        }

        public int GetDR()
        {
            return counter_d;
        }
        public int GetLDR()
        {
            return img_die_R.Length;
        }
        public int GetDL()
        {
            return counter_d;
        }
        public int GetLDL()
        {
            return img_die_L.Length;
        }
        public int GetHits()
        {
            return hits;
        }

        public void draw(Graphics gfx, int x, int y, int w, int h)
        {
            if (shot)
            {
                last_state = state;
                if (last_state == 2)
                {
                    state = 4;
                }
                else if (last_state == 1)
                {
                    state = 7;
                }

            }
            switch (state)
            {
                case Boss.PORTAL:
                    img = img_spawning[0];
                    break;
                case Boss.STANDING:
                    img = img_spawning[1];
                    break;
                case Boss.RIGHT:
                    img = img_walking_r[counter_wr];
                    counter_wr++;
                    if (counter_wr == img_walking_r.Length)
                        counter_wr = 0;
                    break;
                case Boss.LEFT:
                    img = img_walking_l[counter_wl];
                    counter_wl++;
                    if (counter_wl == img_walking_l.Length)
                        counter_wl = 0;
                    break;
                case Boss.HITTING_R:
                    img = img_hitting_R[counter_hr];
                    counter_hr++;
                    if (counter_hr == img_hitting_R.Length)
                    {
                        hits++;
                        counter_hr = 0;
                    }
                    break;
                case Boss.HITTING_L:
                    img = img_hitting_L[counter_hl];
                    counter_hl++;
                    if (counter_hl == img_hitting_L.Length)
                    {
                        hits++;
                        counter_hl = 0;
                    }
                    break;

               
                case Boss.DIE_R:

                    while (counter_d != img_die_R.Length)
                    {
                        img = img_die_R[counter_d];
                        counter_d++;


                        break;

                    }
                    break;
                case Boss.DIE_L:
                    while (counter_d != img_die_L.Length)
                    {
                        img = img_die_L[counter_d];
                        counter_d++;

                        break;
                    }

                    break;
            }
            gfx.DrawImage(img, x,y, w, h);
        }

    }
}