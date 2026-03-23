using SplashKitSDK;
using static System.Convert;
using static SplashKitSDK.SplashKit;

//Screen
const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;

//Spider
const int SPIDER_RADIUS = 25;
const int SPIDER_SPEED = 3;
int spiderX, spiderY;

//Fly
const int FLY_RADIUS = 15;
int flyX;
int flyY;
long appearAt;
bool flyAppeared;
long escapeAt;

//Game
const string GAME_TIMER = "Game Timer";
int score;

spiderX = SCREEN_WIDTH / 2;
spiderY = SCREEN_HEIGHT / 2;

flyX = 0;
flyY = 0;
flyAppeared = false;
appearAt = 1000 + Rnd(2000);
escapeAt = 0;

score = 0;

OpenWindow("FlyCatch", SCREEN_WIDTH, SCREEN_HEIGHT);

CreateTimer(GAME_TIMER);
StartTimer(GAME_TIMER);


while (!QuitRequested())
{
    if (KeyDown(KeyCode.RightKey) && spiderX + SPIDER_RADIUS < SCREEN_WIDTH)
    {
        spiderX += SPIDER_SPEED;
    }
    if (KeyDown(KeyCode.LeftKey) && spiderX - SPIDER_RADIUS > 0)
    {
        spiderX -= SPIDER_SPEED;
    }
    if (KeyDown(KeyCode.DownKey) && spiderY + SPIDER_RADIUS < SCREEN_HEIGHT)
    {
        spiderY += SPIDER_SPEED;
    }
    if (KeyDown(KeyCode.UpKey) && spiderY - SPIDER_RADIUS > 0)
    {
        spiderY -= SPIDER_SPEED;
    }

    if (!flyAppeared && TimerTicks(GAME_TIMER) > appearAt)
    {
        flyAppeared = true;
        flyX = Rnd(SCREEN_WIDTH);
        flyY = Rnd(SCREEN_HEIGHT);
        escapeAt = TimerTicks(GAME_TIMER) + 2000 + Rnd(5000);
    }
    else if (flyAppeared && TimerTicks(GAME_TIMER) > escapeAt)
    {
        flyAppeared = false;
        appearAt += TimerTicks(GAME_TIMER) + 1000 + Rnd(2000);
    }

    if (flyAppeared && CirclesIntersect(flyX, flyY, FLY_RADIUS, spiderX, spiderY, SPIDER_RADIUS))
    {
        flyAppeared = false;
        score++;
        appearAt += TimerTicks(GAME_TIMER) + 1000 + Rnd(2000);
    }
    ClearScreen(ColorWhite());
    FillCircle(ColorBlack(), spiderX, spiderY, SPIDER_RADIUS);
    if (flyAppeared)
    {
        FillCircle(ColorDarkGreen(), flyX, flyY, FLY_RADIUS);
    }
    DrawText($"Flies Caught: {score}", ColorBlack(), 0, 0);
    RefreshScreen(60);
    ProcessEvents();
}
