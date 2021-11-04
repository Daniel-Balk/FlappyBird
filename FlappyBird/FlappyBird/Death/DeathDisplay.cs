using FlappyBird.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Death
{
    public class DeathDisplay : IFlappyCompound
    {
        public void BeforeRender()
        {

        }

        public void Click()
        {

        }

        public void DoPhysics()
        {
            // No Physics
        }

        public Bitmap GetFrame()
        {
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Dead)
                return Properties.Resources.DeathScreen;
            return new Bitmap(GetRectangle().Width, GetRectangle().Height);
        }

        Rectangle rect = new Rectangle(0, 0, 1200, 900);
        public Rectangle GetRectangle()
        {
            return rect;
        }

        int z = FlappyBirdApplication.MainMenuZ++;
        public int GetZ()
        {
            return z;
        }

        public void Update()
        {

        }

        public void Hover()
        {

        }
    }
}