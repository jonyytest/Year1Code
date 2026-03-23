//  using SplashKitSDK;
//   using static SplashKitSDK.SplashKit;
#include "splashkit.h"

int main()
{


  const int PLAYER_RADIUS = 50;
  const int PLAYER_SPEED = 3;

  int player_x = 640;

  open_window("circle moving", 1280, 720);

  while( ! quit_requested() )
  {
      clear_screen(color_white());
      fill_circle(color_turquoise(), player_x, 360, PLAYER_RADIUS);
      refresh_screen(60);

      process_events();

      if ( key_down(RIGHT_KEY) )
      {
          player_x += PLAYER_SPEED;
      }

      if ( key_down(LEFT_KEY) )
      {
          player_x -= PLAYER_SPEED;
      }
  }
return 0;
}