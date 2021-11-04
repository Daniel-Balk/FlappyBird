using FlappyBird.Engine;
using FlappyBird.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird.Game
{
    public class Tube : IFlappyCompound
    {
        public void BeforeRender()
        {
            if (Usability)
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                    rect.X-=1;
        }

        public void Click()
        {

        }

        public void DoPhysics()
        {

        }

        Bitmap Texture = null;

        public void SetTexture()
        {
            Bitmap b = new Bitmap(Rectangle.Width / Zoom, Rectangle.Height / Zoom);
            var g = Graphics.FromImage(b);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            var topleft = Resources.TopLeft;
            var topcent = Resources.TopCenter;
            var toprigh = Resources.TopRight;
            var cenleft = Resources.CenterLeft;
            var cencent = Resources.Center;
            var cenrigh = Resources.CenterRight;

            g.DrawImage(topleft, 0, 0, topleft.Width, topleft.Height);
            g.DrawImage(cenleft, 0, topleft.Height, cenleft.Width, b.Height - topleft.Height);

            g.DrawImage(topcent, topleft.Width, 0, b.Width - topleft.Width - toprigh.Width, topcent.Height);
            g.DrawImage(cencent, topleft.Width, topcent.Height, b.Width - topleft.Width - toprigh.Width, b.Height - topcent.Height);

            g.DrawImage(toprigh, b.Width - toprigh.Width - 1, 0);
            g.DrawImage(cenrigh, b.Width - toprigh.Width - 1, toprigh.Height, cenrigh.Width, b.Height - toprigh.Height);

            g.Dispose();

            b.RotateFlip(Rotation);

            Bitmap returning = new Bitmap(Rectangle.Width, Rectangle.Height);
            var rg = Graphics.FromImage(returning);
            rg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            rg.DrawImage(b, 0, 0, Rectangle.Width, Rectangle.Height);
            b.Dispose();
            rg.Dispose();
            Texture = returning;
        }

        public int Zoom { get; set; } = 4;
        public RotateFlipType Rotation { get; set; } = RotateFlipType.RotateNoneFlipY;
        public Bitmap GetFrame()
        {
            if (Texture == null)
                SetTexture();

            Bitmap returning = new Bitmap(Rectangle.Width, Rectangle.Height);

            var rg = Graphics.FromImage(returning);
            rg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            if (Usability)
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Playing)
                    rg.DrawImage(Texture, 0, 0, Rectangle.Width, Rectangle.Height);
            rg.Dispose();
            return returning;
        }

        private Rectangle rect = new Rectangle(32, 32, 128, 512);

        public Rectangle Rectangle
        {
            get
            {
                return rect;
            }
            set
            {
                rect = value;
                SetTexture();
            }
        }

        Rectangle noApp = new Rectangle(-100, -100, 1, 1);
        public Rectangle GetRectangle()
        {
            if (Usability)
                return Rectangle;
            return noApp;
        }
        public static int StaticZ { get; set; } = 512;
        public int Z { get; set; } = StaticZ++;
        public bool Usability { get; set; } = true;

        public int GetZ()
        {
            return Z;
        }

        public void Hover()
        {

        }

        public void Update()
        {
            if (Usability)
            {
                if (Rectangle.IntersectsWith(FlappyBirdApplication.bird.Rectangle))
                {
                    FlappyBirdApplication.Playing = ComponentActivityMode.Dead;
                }
                if (FlappyBirdApplication.Playing == ComponentActivityMode.Dead || FlappyBirdApplication.Playing == ComponentActivityMode.Win)
                {
                    Usability = false;
                }
            }
        }
    }
}
