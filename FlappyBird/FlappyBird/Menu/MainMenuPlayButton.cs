using FlappyBird.Engine;
using System.Diagnostics;
using System.Drawing;

namespace FlappyBird.Menu
{
    public class MainMenuPlayButton : IFlappyCompound
    {
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
            Bitmap b = new Bitmap(GetRectangle().Width, GetRectangle().Height);
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Menu)
            {
                Graphics g = Graphics.FromImage(b);
                if (!hover)
                    g.DrawImage(Properties.Resources.PlayButton, 0, 0, b.Width, b.Height);
                else
                    g.DrawImage(Properties.Resources.HoverPlayButton, 0, 0, b.Width, b.Height);
                g.Dispose();
            }
            if (hover)
                hover = false;
            return b;
        }

        Rectangle rect = new Rectangle(1200/2-128/2, 900 / 2 - 128 / 2, 128, 128);
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