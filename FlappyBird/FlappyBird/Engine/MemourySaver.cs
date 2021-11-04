using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlappyBird.Engine
{
    public static class MemourySaver
    {
        public static void Save()
        {
            Thread t = null;
            t = new Thread(new ThreadStart(() =>
            {
                while (true)
                {
                    Thread.Sleep(500);
                    GC.Collect();
                }
            }));
            t.Start();
        }
    }
}
