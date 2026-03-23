#include "splashkit.h"
using std::to_string;

//Game
const string GAME_TIMER = "Game Timer";
int score;

//Screen
const int SCREEN_WIDTH = 800;
const int SCREEN_HEIGHT = 600;

//Spider
const int SPIDER_RADIUS = 25;
const int SPIDER_SPEED = 3;

const int FLY_RADIUS = 15;

void draw_game(int spider_x, int spider_y, bool fly_appeared, int fly_x, int fly_y)
{
    clear_screen(color_white());
    fill_circle(color_black(), spider_x, spider_y, SPIDER_RADIUS);
    if (fly_appeared)
    {
        fill_circle(color_dark_green(), fly_x, fly_y, FLY_RADIUS);
    }
    draw_text("Flies Caught:" +to_string(score)+"", color_black(), 0, 0);
    refresh_screen(60);
}

int main()
{

//Fly

int spider_x = SCREEN_WIDTH / 2;
int spider_y = SCREEN_HEIGHT / 2;

int fly_x = 0;
int fly_y = 0;
bool fly_appeared = false;
long appear_at = 1000 + rnd(2000);
long escape_at = 0;

score = 0;

open_window("FlyCatch", SCREEN_WIDTH, SCREEN_HEIGHT);

create_timer(GAME_TIMER);
start_timer(GAME_TIMER);


while (!quit_requested())
{
    if (key_down(RIGHT_KEY) && spider_x + SPIDER_RADIUS < SCREEN_WIDTH)
    {
        spider_x += SPIDER_SPEED;
    }
    if (key_down(LEFT_KEY) && spider_x - SPIDER_RADIUS > 0)
    {
        spider_x -= SPIDER_SPEED;
    }
    if (key_down(DOWN_KEY) && spider_y + SPIDER_RADIUS < SCREEN_HEIGHT)
    {
        spider_y += SPIDER_SPEED;
    }
    if (key_down(UP_KEY) && spider_y - SPIDER_RADIUS > 0)
    {
        spider_y -= SPIDER_SPEED;
    }

    if (!fly_appeared && timer_ticks(GAME_TIMER) > appear_at)
    {
        fly_appeared = true;
        fly_x = rnd(SCREEN_WIDTH);
        fly_y = rnd(SCREEN_HEIGHT);
        escape_at = timer_ticks(GAME_TIMER) + 2000 + rnd(5000);
    }
    else if (fly_appeared && timer_ticks(GAME_TIMER) > escape_at)
    {
        fly_appeared = false;
        appear_at += timer_ticks(GAME_TIMER) + 1000 + rnd(2000);
    }

    if (fly_appeared && circles_intersect(fly_x, fly_y, FLY_RADIUS, spider_x, spider_y, SPIDER_RADIUS))
    {
        fly_appeared = false;
        score++;
        appear_at += timer_ticks(GAME_TIMER) + 1000 + rnd(2000);
    }
    
    draw_game(spider_x, spider_y, fly_appeared, fly_x, fly_y);
    process_events();
}
return 0;
}