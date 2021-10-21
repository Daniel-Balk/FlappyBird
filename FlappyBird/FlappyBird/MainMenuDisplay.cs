using System.Drawing;

namespace FlappyBird
{
    public class MainMenuDisplay : IFlappyCompound
    {
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
            Bitmap b = new Bitmap(GetRectangle().Width, GetRectangle().Height);
            var g = Graphics.FromImage(b);
            if (Show)
                if (!FlappyBirdApplication.Playing)
                    g.DrawImage(Properties.Resources.MainMenu, 0, 0);
            g.Dispose();
            return b;
        }

        Rectangle rect = new Rectangle(0, 0, 1200, 900);
        public Rectangle GetRectangle()
        {
            return rect;
        }

        public int GetZ()
        {
            return FlappyBirdApplication.MainMenuZ;
        }

        public void Update()
        {

        }

        public void Hover()
        {
            
        }
    }
}