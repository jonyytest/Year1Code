using SplashKitSDK;
using static System.Convert;
using static SplashKitSDK.SplashKit;

const int PLAYER_RADIUS = 50;
const int PLAYER_SPEED = 3;
int playerX = 640;
int playerY = 360;

OpenWindow("Circle Moving", 1280, 720);

while (!QuitRequested())
{
    ClearScreen(ColorWhite());
    FillCircle(ColorTurquoise(), playerX, playerY, PLAYER_RADIUS);

    if (KeyDown(KeyCode.RightKey))
    {
        playerX += PLAYER_SPEED;
    }
    if (KeyDown(KeyCode.LeftKey))
    {
        playerX -= PLAYER_SPEED;
    }
    if (KeyDown(KeyCode.UpKey))
    {
        playerY -= PLAYER_SPEED;
    }
    if (KeyDown(KeyCode.DownKey))
    {
        playerY += PLAYER_SPEED;
    }

    RefreshScreen(60);
    ProcessEvents();
    
}