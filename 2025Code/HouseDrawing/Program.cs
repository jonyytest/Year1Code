using static System.Convert;
using static SplashKitSDK.SplashKit;

const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;
const int BOTTOM_GAP = 100;

int houseSize;
string userInput;
int wallX, wallY;
int roofLeft, roofRight, roofTop, roofMiddle;
int roofHeight, roofOverhang;


WriteLine("Please enter the size for the house: ");
userInput = ReadLine();
houseSize = ToInt32(userInput);

wallX = (SCREEN_WIDTH - houseSize) / 2;
wallY = SCREEN_HEIGHT - BOTTOM_GAP - houseSize;
roofHeight = houseSize * 3 / 4;
roofOverhang = houseSize / 4;
roofLeft = wallX - roofOverhang;
roofRight = wallX + houseSize + roofOverhang;
roofTop = wallY - roofHeight;
roofMiddle = wallX + houseSize / 2;


OpenWindow("House Drawing by Jon", SCREEN_WIDTH, SCREEN_HEIGHT);
ClearScreen(ColorWhite());
FillEllipse(ColorBrightGreen(), 0, 400, SCREEN_WIDTH, 400);
FillRectangle(ColorGray(), wallX, wallY, houseSize, houseSize);
FillTriangle(ColorRed(), roofLeft, wallY, roofMiddle, roofTop, roofRight, wallY);

RefreshScreen();
Delay(9000);

