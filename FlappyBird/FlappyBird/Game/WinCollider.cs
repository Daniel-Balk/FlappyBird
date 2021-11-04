using FlappyBird.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    public class WinCollider : IFlappyCompound
    {
        public void BeforeRender()
        {
            if (Usability)
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                    rect.X -= 1;
        }

        public void Click()
        {
            
        }

        public void DoPhysics()
        {
            
        }

        public Bitmap GetFrame()
        {
            return new Bitmap(rect.Width, rect.Height);
        }

        public Rectangle rect = new Rectangle(1000, 0, 1, 900);

        public bool Usability { get; set; } = true;

        public Rectangle GetRectangle()
        {
            return rect;
        }
        static int SZ = 110;
        int z = SZ++;
        public int GetZ()
        {
            return z;
        }

        public void Hover()
        {
            
        }

        public void Update()
        {
            if (Usability)
            {
                if (rect.IntersectsWith(FlappyBirdApplication.bird.Rectangle))
                {
                    FlappyBirdApplication.Playing = ComponentActivityMode.Win;
                }
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Dead || FlappyBirdApplication.Playing == ComponentActivityMode.Win)
                {
                    Usability = false;
                }
            }
        }
    }
}
