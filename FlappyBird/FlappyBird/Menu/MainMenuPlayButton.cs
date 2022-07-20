using FlappyBird.Engine;
using System.Diagnostics;
using System.Drawing;

namespace FlappyBird.Menu
{
    public class MainMenuPlayButton : IFlappyCompound
    {
        public bool IsActive => FlappyBirdApplication.Playing == ComponentActivityMode.Menu;

        public static bool Visible { get; set; } = true;
        public void BeforeRender()
        {

        }

        public void Click()
        {
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Menu)
                FlappyBirdApplication.Playing = ComponentActivityMode.Playing;
        }

        public void DoPhysics()
        {
            
        }

        public Bitmap GetFrame()
        {
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Menu)
            {
                if (!hover)
                {
                    return Properties.Resources.PlayButton;
                }
                else
                {
                    hover = false;
                    return Properties.Resources.HoverPlayButton;
                }
            }
            return new Bitmap(GetRectangle().Width, GetRectangle().Height);
        }

        Rectangle rect = new Rectangle(1200/2-112/2, 900 / 2 - 56 / 2 + 30, 112, 56);
        public Rectangle GetRectangle()
        {
            return rect;
        }

        int z = FlappyBirdApplication.MainMenuButtonZ++;
        public int GetZ()
        {
            return z;
        }

        bool hover = false;
        public void Hover()
        {
            hover = true;
        }

        public void Update()
        {

        }
    }
}