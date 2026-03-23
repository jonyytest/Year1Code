#include "splashkit.h"
using std::stoi;
using std::to_string;

int main()
{

const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;
int radius;
int dot_x, dot_y;
float x;
float y;
radius = 1;
int i;

open_window("Circles", SCREEN_WIDTH, SCREEN_HEIGHT);
clear_screen(color_white());

while (!quit_requested())
    {
        
        if (key_typed(C_KEY))
    {
        clear_screen(random_color());
        delay(300);
    }
        if (key_typed(S_KEY))
            {
                radius = 10;
            }
        if (key_typed(M_KEY))
            {
                radius = 50;
            }
        if (key_typed(L_KEY))
            {
                radius = 100;
            }
        if (mouse_clicked(LEFT_BUTTON))
            {
               x = mouse_x();
               y = mouse_y();
                fill_circle(random_color(), x, y, radius);
            }
    if (key_typed(NUM_5_KEY))
    {
        for (i = 0; i < 100; i++)
        {
            dot_x = rnd(SCREEN_WIDTH);
            dot_y = rnd(SCREEN_HEIGHT);
            fill_circle(random_color(), dot_x, dot_y, radius);
        }
    }

            refresh_screen(60);
            process_events();
        }
    return 0;
}
