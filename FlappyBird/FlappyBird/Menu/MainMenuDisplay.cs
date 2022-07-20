using FlappyBird.Engine;
using System;
using System.Drawing;

namespace FlappyBird.Menu
{
    public class MainMenuDisplay : IFlappyCompound
    {
        public bool IsActive => FlappyBirdApplication.Playing == ComponentActivityMode.Menu;

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
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Menu)
                    return Properties.Resources.MainMenu;
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