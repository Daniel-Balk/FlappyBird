using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public class FlappyBirdApplication
    {

        static List<IFlappyCompound> Compounds { get; set; } = new List<IFlappyCompound>();
        public static int MainMenuZ = 404;
        public static int MainMenuButtonZ = 500;
        static Dictionary<int, bool> Values { get; set; } = new Dictionary<int, bool>()
        {
            {
                0,
                false
            },
            {
                1,
                false
            }
        };
        public void PutOn(Graphics g, int width, int height)
        {
            Render(g, width, height);
        }
        public static Color BackColor { get; set; } = Color.FromArgb(0x00, 0x95, 0xDB);
        public static bool Playing { get; set; } = false;
        public static void Render(Graphics g, int width, int height)
        {
            if (!Values[0])
            {
                Values[0] = true;
                Setup();
            }
            g.Clear(BackColor);
            SortedDictionary<int, IFlappyCompound> cps = new SortedDictionary<int, IFlappyCompound>();
            foreach (var c in Compounds)
            {
                cps[c.GetZ()] = c;
            }
            foreach (var control in cps)
            {
                var cl = control.Value;
                cl.DoPhysics();
                cl.BeforeRender();
                if (cl.GetRectangle().IntersectsWith(new Rectangle(lastHov, new System.Drawing.Size(8, 8))))
                    cl.Hover();
                var render = cl.GetFrame();
                var rect = cl.GetRectangle();
                g.DrawImage(render, rect.X, rect.Y, rect.Width, rect.Height);
                render.Dispose();
            }
        }

        public void HandleKey(KeyEventArgs e)
        {
            WorkWithKey(e);
        }

        public static void WorkWithKey(KeyEventArgs e)
        {

        }

        public static void Shutdown()
        {
            Values[1] = true;
        }

        static readonly MainMenuPlayButton plb = new MainMenuPlayButton();
        static readonly MainMenuDisplay mmd = new MainMenuDisplay();
        public static void Setup()
        {
            Compounds.Add(mmd);
            Compounds.Add(plb);
            Thread upd = null;
            upd = new Thread(new ThreadStart(() =>
        {
            while (true)
            {
                if (Values[1])
                    break;
                foreach (var c in Compounds)
                {
                    c.Update();
                }
                Thread.Sleep(100);
            }
            upd.Abort();
        }));
            upd.Start();
        }

        public void Hovering(Point point)
        {
            lastHov = point;
        }
        static Point lastHov = new Point(0, 0);

        public void Click(Point point)
        {
            PerformClick(point);
        }
        public static void PerformClick(Point p)
        {
            foreach (var cl in Compounds)
            {
                if (cl.GetRectangle().IntersectsWith(new Rectangle(p, new System.Drawing.Size(8, 8))))
                    cl.Click();
            }
        }
    }
}