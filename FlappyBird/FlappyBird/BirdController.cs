using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class BirdController : IFlappyCompound
    {
        public void BeforeRender()
        {
            
        }

        public void Click()
        {
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

        public int GetZ()
        {
            return FlappyBirdApplication.EventControllerZ;
        }

        public void Hover()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
