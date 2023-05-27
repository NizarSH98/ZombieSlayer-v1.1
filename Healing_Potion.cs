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
    class Healing_Potion
    {
        Image healing_potion = Image.FromFile("images\\\\Health\\Healing_Potion.png");
       public bool ready=false;
        public bool took = false;
        int x;
        int y;
        int w;
        int h;
        public Healing_Potion()
        {
            h = h;
        w = w;
           x = x;
            y = y;

        }
        public Healing_Potion(int x, int y, int w, int h)
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
        public void draw(Graphics gfx, int x,int y, int w, int h)
        {
           
            gfx.DrawImage(healing_potion, x, y, w, h);
        }
    }
}
