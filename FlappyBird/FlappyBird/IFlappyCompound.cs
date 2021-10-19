using System.Drawing;

namespace FlappyBird
{
    public interface IFlappyCompound
    {
        Rectangle GetRectangle();
        int GetZ();
        Bitmap GetFrame();
        void DoPhysics();
        void BeforeRender();
        void Update();
        void Click();
    }
}
