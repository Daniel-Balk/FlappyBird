using System.Diagnostics;
using System.Drawing;

namespace FlappyBird
{
    public class MainMenuPlayButton : IFlappyCompound
    {
        public static bool Visible { get; set; } = true;
        public void BeforeRender()
        {

        }

        public void Click()
        {
            System.Windows.Forms.MessageBox.Show("Yay, Click!");
        }

        public void DoPhysics()
        {
            
        }

        public Bitmap GetFrame()
        {
            Bitmap b = new Bitmap(GetRectangle().Width, GetRectangle().Height);
            Graphics g = Graphics.FromImage(b);
            if(!hover)
            g.DrawImage(Properties.Resources.PlayButton, 0, 0, b.Width, b.Height);
            else
                g.DrawImage(Properties.Resources.HoverPlayButton, 0, 0, b.Width, b.Height);
            g.Dispose();
            if (hover)
                hover = false;
            return b;
        }

        Rectangle rect = new Rectangle(1200/2-128/2, 900 / 2 - 128 / 2, 128, 128);
        public Rectangle GetRectangle()
        {
            return rect;
        }

        public int GetZ()
        {
            return FlappyBirdApplication.MainMenuButtonZ;
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