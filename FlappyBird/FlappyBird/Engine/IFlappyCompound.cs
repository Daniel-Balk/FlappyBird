using System.Drawing;

namespace FlappyBird.Engine
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
        void Hover();
    }
}
