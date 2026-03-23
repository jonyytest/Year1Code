#include "splashkit.h"
#include "utilities.h"

using std::to_string;

const int MAX_TARGET_RADIUS = 200;
const int MIN_TARGET_RADIUS = 10;
const string TIMER_NAME = "reaction";

struct target_data 
{ 
int x;
int y;
int radius; 
};

struct game_data
{
  target_data target;
  int hits;
  int fastestreaction;
  int lastreaction;
};

target_data random_target(int last_reaction)
{
  int t = last_reaction;
  if (t < 0)    t = 0;
  if (t > 1000) t = 1000;

  int range = MAX_TARGET_RADIUS - MIN_TARGET_RADIUS;
  int r = MIN_TARGET_RADIUS + (t * range) / 1000;

  return { 
    rnd(r, screen_width() - r),
    rnd(r, screen_height() - r),
    r
  };
}

void draw_game(const game_data &g)
{
  clear_screen(COLOR_WHITE);
  draw_text("Hits: " + to_string(g.hits), COLOR_BLACK, 20, 20);
  draw_text("Fastest (ms): " + to_string(g.fastestreaction), COLOR_BLACK, 20, 40);
  fill_circle(COLOR_RED, g.target.x, g.target.y, g.target.radius);
  refresh_screen();
}

bool mouse_over_target(const target_data &t)
{
  return point_in_circle(mouse_x(), mouse_y(), t.x, t.y, t.radius);
}

int main()
{
  open_window("Reaction Timer", 800, 600);
  create_timer(TIMER_NAME);
  start_timer(TIMER_NAME);

  game_data game;
  game.hits= 0;
  game.fastestreaction= 10000; 
  game.lastreaction= 1000;
  game.target= random_target(game.lastreaction);

  while (!quit_requested())
  {
    process_events();

    if (mouse_clicked(LEFT_BUTTON) &&
        mouse_over_target(game.target))
    {
      game.lastreaction = timer_ticks(TIMER_NAME);
      if (game.lastreaction < game.fastestreaction)
        game.fastestreaction = game.lastreaction;

      game.hits++;
      game.target = random_target(game.lastreaction);
      reset_timer(TIMER_NAME);
    }

    draw_game(game);
  }

  return 0;
}
