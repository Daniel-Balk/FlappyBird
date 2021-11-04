using FlappyBird.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    public class BirdController : IFlappyCompound
    {
        public void BeforeRender()
        {
            
        }

        public void Click()
        {
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                FlappyBirdApplication.bird.StartJump();
        }

        public void DoPhysics()
        {
            
        }

        public Bitmap GetFrame()
        {
            return new Bitmap(rect.Width,rect.Height);
        }

        Rectangle rect = new Rectangle(0, 0, 1600, 900);
        public Rectangle GetRectangle()
        {
            return rect;
        }

        int z = FlappyBirdApplication.EventControllerZ++;
        public int GetZ()
        {
            return z;
        }

        public void Hover()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
