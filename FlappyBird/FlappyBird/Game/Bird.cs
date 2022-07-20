using FlappyBird.Engine;
using FlappyBird.Properties;
using System.Drawing;
using System.Threading;

namespace FlappyBird.Game
{
    public class Bird : IFlappyCompound
    {
        public void BeforeRender()
        {

        }

        public void Click()
        {

        }

        public void StartJump()
        {
            upspeed = 250;
        }
        int upspeed = 0;

        public void DoPhysics()
        {
            if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
            {
                int i = upspeed / (-50);
                if (Rectangle.Y + i > 0)
                    if (Rectangle.Y + i < 900 - Rectangle.Height)
                        Rectangle.Y += (int)(i*1.75F);
            }
        }

        public int Zoom { get; set; } = 4;
        public RotateFlipType Rotation { get; set; } = RotateFlipType.RotateNoneFlipNone;
        public Bitmap GetFrame()
        {
            Bitmap b = new Bitmap(Rectangle.Width / Zoom, Rectangle.Height / Zoom);
            var g = Graphics.FromImage(b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
            {
                g.DrawImage(Resources.Bird, 0, 0, b.Width, b.Height);
            }

            g.Dispose();

            b.RotateFlip(Rotation);

            Bitmap returning = new Bitmap(Rectangle.Width, Rectangle.Height);
            var rg = Graphics.FromImage(returning);
            rg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            rg.DrawImage(b, 0, 0, Rectangle.Width, Rectangle.Height);
            b.Dispose();
            rg.Dispose();

            return returning;
        }

        public Rectangle Rectangle = new Rectangle(32, 256, 68, 68);
        public Rectangle GetRectangle()
        {
            return Rectangle;
        }
        public int Z { get; set; } = FlappyBirdApplication.BirdZ++;

        public bool IsActive => FlappyBirdApplication.Playing == ComponentActivityMode.Playing;

        public int GetZ()
        {
            return Z;
        }

        public void Hover()
        {

        }
        bool setup = false;
        public void Update()
        {
            if (!setup)
            {
                Thread t = new Thread(new ThreadStart(() =>
                {
                    while (true)
                    {
                        if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                        {
                            upspeed--;
                            if (upspeed == 50)
                                upspeed = -50;
                        }
                        Thread.Sleep(1);
                    }
                }));
                t.Start();
                setup = true;
            }
        }
    }
}