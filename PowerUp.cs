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
    class PowerUp { 
        Image powerup = Image.FromFile("images\\\\Health\\Powerup.png");
        public bool ready = false;
        public bool took = false;
        int x;
        int y;
        int w;
        int h;
        public PowerUp()
        {
            h = h;
            w = w;
            x = x;
            y = y;

        }
        public PowerUp(int x, int y, int w, int h)
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
        public void draw(Graphics gfx, int x, int y, int w, int h)
        {

            gfx.DrawImage(powerup, x, y, w, h);
        }
    }
}
