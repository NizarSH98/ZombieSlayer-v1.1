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
    class Zombie
    {

        int x, y, h, w;
        Image img;
        Image[] img_walking_r = { Image.FromFile("images\\Zombie\\movR1.png"), Image.FromFile("images\\Zombie\\movR1.png"), Image.FromFile("images\\Zombie\\movR1.png"), Image.FromFile("images\\Zombie\\movR2.png"), Image.FromFile("images\\Zombie\\movR2.png"), Image.FromFile("images\\Zombie\\movR2.png"), Image.FromFile("images\\Zombie\\movR3.png"), Image.FromFile("images\\Zombie\\movR3.png"), Image.FromFile("images\\Zombie\\movR3.png"), Image.FromFile("images\\Zombie\\movR4.png"), Image.FromFile("images\\Zombie\\movR4.png"), Image.FromFile("images\\Zombie\\movR4.png") };
        Image[] img_walking_l = { Image.FromFile("images\\Zombie\\movL1.png"), Image.FromFile("images\\Zombie\\movL1.png"), Image.FromFile("images\\Zombie\\movL1.png"), Image.FromFile("images\\Zombie\\movL2.png"), Image.FromFile("images\\Zombie\\movL2.png"), Image.FromFile("images\\Zombie\\movL2.png"), Image.FromFile("images\\Zombie\\movL3.png"), Image.FromFile("images\\Zombie\\movL3.png"), Image.FromFile("images\\Zombie\\movL3.png"), Image.FromFile("images\\Zombie\\movL4.png"), Image.FromFile("images\\Zombie\\movL4.png"), Image.FromFile("images\\Zombie\\movL4.png") };
         Image[] img_spawning = {  Image.FromFile("images\\Zombie\\spawn1.png"), Image.FromFile("images\\Zombie\\spawn1.png"), Image.FromFile("images\\Zombie\\spawn1.png"), Image.FromFile("images\\Zombie\\spawn2.png"), Image.FromFile("images\\Zombie\\spawn2.png"), Image.FromFile("images\\Zombie\\spawn2.png"), Image.FromFile("images\\Zombie\\spawn3.png"), Image.FromFile("images\\Zombie\\spawn3.png"), Image.FromFile("images\\Zombie\\spawn3.png"), Image.FromFile("images\\Zombie\\spawn4.png"), Image.FromFile("images\\Zombie\\spawn4.png"), Image.FromFile("images\\Zombie\\spawn4.png"),Image.FromFile("images\\Zombie\\movR1.png") };
        Image[] img_die_R = { Image.FromFile("images\\Zombie\\die1R.png"), Image.FromFile("images\\Zombie\\die1R.png"), Image.FromFile("images\\Zombie\\die1R.png"),  Image.FromFile("images\\Zombie\\die2R.png"), Image.FromFile("images\\Zombie\\die2R.png"), Image.FromFile("images\\Zombie\\die2R.png"), Image.FromFile("images\\Zombie\\die3R.png"), Image.FromFile("images\\Zombie\\die3R.png"), Image.FromFile("images\\Zombie\\die3R.png"),  Image.FromFile("images\\Zombie\\die4R.png"), Image.FromFile("images\\Zombie\\die4R.png"), Image.FromFile("images\\Zombie\\die4R.png") };
        Image[] img_die_L = { Image.FromFile("images\\Zombie\\die1L.png"), Image.FromFile("images\\Zombie\\die1L.png"), Image.FromFile("images\\Zombie\\die1L.png"), Image.FromFile("images\\Zombie\\die2L.png"), Image.FromFile("images\\Zombie\\die2L.png"), Image.FromFile("images\\Zombie\\die2L.png"), Image.FromFile("images\\Zombie\\die3L.png"), Image.FromFile("images\\Zombie\\die3L.png"), Image.FromFile("images\\Zombie\\die3L.png"), Image.FromFile("images\\Zombie\\die4L.png"), Image.FromFile("images\\Zombie\\die4L.png"), Image.FromFile("images\\Zombie\\die4L.png") };
        Image[] img_hitting_R = { Image.FromFile("images\\Zombie\\hit1R.png"), Image.FromFile("images\\Zombie\\hit1R.png"), Image.FromFile("images\\Zombie\\hit2R.png"), Image.FromFile("images\\Zombie\\hit2R.png"), Image.FromFile("images\\Zombie\\hit3R.png"), Image.FromFile("images\\Zombie\\hit3R.png") };
        Image[] img_hitting_L = { Image.FromFile("images\\Zombie\\hit1L.png"), Image.FromFile("images\\Zombie\\hit1L.png"), Image.FromFile("images\\Zombie\\hit2L.png"), Image.FromFile("images\\Zombie\\hit2L.png"), Image.FromFile("images\\Zombie\\hit3L.png") ,Image.FromFile("images\\Zombie\\hit3L.png") };
        Image img_standing = Image.FromFile("images\\Zombie\\movD2.png");
        int counter_wr = 0;
        int counter_wl = 0;
        int counter_sp = 0;
        int counter_d = 0;
        int counter_hr = 0;
        int counter_hl = 0;
        int hits = 0;
        int z_die = 0;
        public const int STANDING = 0;
        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int SPAWN = 3;
        public const int DIE_R = 4;
        public const int DIE_L = 7;
        public const int HITTING_R = 5;
        public const int HITTING_L = 6;
        public int state=0 ;
        public bool ready = false;
        public bool die = false;
        public bool search = false;
        Random random = new Random();

        public int GetZD()
        {
            return z_die;
        }
        public void SetZD(int n)
        {
            this.z_die = n;
        }
        public int GetRX(int screen_w)
        {
            return random.Next(0, screen_w);        }
        public int GetRY(int screen_h)
        {
            return random.Next(0, screen_h);
        }

        public Zombie(int w, int h)
        {
            this.h = h;
            this.w = w; 
            img = img_standing;

        }
        public Zombie(int x, int y, int w, int h)
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
        public void draw(Graphics gfx, int x, int y,int w,int h)
        {
            switch (state)
            {
                case Zombie.STANDING:
                    img = img_standing;
                    break;
                case Zombie.RIGHT:
                    img = img_walking_r[counter_wr];
                    counter_wr++;
                    if (counter_wr == img_walking_r.Length)
                        counter_wr = 0;
                    break;
                case Zombie.LEFT:
                    img = img_walking_l[counter_wl];
                    counter_wl++;
                    if (counter_wl == img_walking_l.Length)
                        counter_wl = 0;
                    break;
                case Zombie.HITTING_R:
                    img = img_hitting_R[counter_hr];
                    counter_hr++;
                    if (counter_hr == img_hitting_R.Length)
                    {
                        hits++;
                        counter_hr = 0;
                    }
                    break;
                case Zombie.HITTING_L:
                    img = img_hitting_L[counter_hl];
                    counter_hl++;
                    if (counter_hl == img_hitting_L.Length){
                        hits++;
                        counter_hl = 0;
                    }
                    break;

                case Zombie.SPAWN:
                    
                    while(counter_sp != img_spawning.Length)
                    {
                        img = img_spawning[counter_sp];
                        counter_sp++;
                       
                        break;
                    }
                  
                    break;
                case Zombie.DIE_R:

                    while (counter_d != img_die_R.Length)
                    {
                        img = img_die_R[counter_d];
                        counter_d++;

                        break;
                    }break;
                case Zombie.DIE_L:
                    while (counter_d != img_die_L.Length)
                    {
                        img = img_die_L[counter_d];
                        counter_d++;

                        break;
                    }

                    break;
            }
            gfx.DrawImage(img, this.x, this.y, w, h);
        }

    }
}