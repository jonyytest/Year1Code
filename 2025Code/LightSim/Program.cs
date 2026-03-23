using static System.Console;
using SplashKitSDK;

namespace LightSim
{
    public class Light
    {
    private bool _isOn;
    private int _x, _y;
    public bool IsOn => _isOn;
    public int X => _x;
    public int Y => _y;

    private string BitmapName
    {
        get
        {
            if (_isOn)
                return "on";
            else
                return "off";
        }
    }
    
    private Bitmap Image
        {
            get
            {
                return SplashKit.BitmapNamed(BitmapName);
            }
        }

    public bool IsUnderMouse
    {
        get
        {
            return Image.PointCollision(X, Y, SplashKit.MouseX(), SplashKit.MouseY());
        }
    }

    public Light(int x, int y)
    {
        _isOn = false;
        _x = x;
        _y = y;
    }

    public void Draw()
    {
        Image.Draw(X, Y);
    }

    public void TogglePower()
    {
        _isOn = !_isOn;
    }
    }

    public class Program
    {
        public static void Main()
        {
            var window = SplashKit.OpenWindow("Light Simulator", 350, 300);

            SplashKit.LoadBitmap("on", "medium-on-light.png");
            SplashKit.LoadBitmap("off", "medium-off-light.png");

            var light = new Light(100, 50);

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                if (SplashKit.MouseClicked(MouseButton.LeftButton)
                && light.IsUnderMouse)
                {
                    light.TogglePower();
                }

                var bg = light.IsOn ? Color.White : Color.Black;
                SplashKit.ClearScreen(bg);

                light.Draw();
                SplashKit.RefreshScreen(60);
            }
        }
    }
}
