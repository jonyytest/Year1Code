using System.Diagnostics;
using Microsoft.VisualBasic;
using SplashKitSDK;
using static System.Convert;
using static SplashKitSDK.SplashKit;

const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;
int radius;
int dotX, dotY;
float x;
float y;
radius = 1;
int i;

OpenWindow("Circles", SCREEN_WIDTH, SCREEN_HEIGHT);
ClearScreen(ColorWhite());

while (!QuitRequested())
    {
        
        if (KeyTyped(KeyCode.CKey))
    {
        ClearScreen(RandomColor());
        Delay(300);
    }
        if (KeyTyped(KeyCode.SKey))
            {
                radius = 10;
            }
        if (KeyTyped(KeyCode.MKey))
            {
                radius = 50;
            }
        if (KeyTyped(KeyCode.LKey))
            {
                radius = 100;
            }
        if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
               x = MouseX();
               y = MouseY();
                FillCircle(RandomColor(), x, y, radius);
            }
    if (KeyTyped(KeyCode.Num5Key))
    {
        for (i = 0; i < 100; i++)
        {
            dotX = Rnd(SCREEN_WIDTH);
            dotY = Rnd(SCREEN_HEIGHT);
            FillCircle(RandomColor(), dotX, dotY, radius);
        }
            }

            RefreshScreen(60);
            ProcessEvents();
        }
    
