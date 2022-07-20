using FlappyBird.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    public class BackgroundImage : IFlappyCompound
    {
        public bool IsActive => true;

        public static bool Show { get; set; } = true;
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
            if (Show)
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                    return Properties.Resources.BackImg;
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
