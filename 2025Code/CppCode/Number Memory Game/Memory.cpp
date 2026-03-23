#include "splashkit.h"
#include "utilities.h"

using std::to_string;
using std::stoi;

const int MAX_LEADBOARD = 11; // Max amount of attempts that can be recorded on the leaderboar
const int MAX_DIFFICULTY = 3;
const int MAX_NUMBERS = 50; 
const int MAX_WIDTH = 800; // Width of the game window
const int MAX_HEIGHT = 600; // Height of the game window
const int DIGITS = 9;
const int EASY_DELAY = 1000;
const int MEDIUM_DELAY = 400;
const int HARD_DELAY = 200;

/**
 * @brief
 * Enum for the difficulty options
 */
enum class Difficulty 
{ 
    Easy = 1, 
    Medium, 
    Hard 
};

/**
 * @brief 
 * Structures used to track each players details and the leaderboard
 */
struct play_details //This is each players details that are tracked on the scoreboard at the end
{
    string name;
    Difficulty difficulty;
    int numbers;
    int numberscorrect;
    int time;
    int score;
};

/**
 * @brief 
 * The play structure contains an array of each players details and the amount of attempts they have had
 */
struct play
{
    int attempts;
    play_details details[MAX_LEADBOARD];
};

/**
 * @brief 
 * Player choses the difficulty and enters details that are recorded in their score at the end
 * @param current current game being played made of struct play
 */
void menu(play &current)
{
    while (current.details[current.attempts].name == "")
    {
        current.details[current.attempts].name = read_string("\nEnter your name: ");
    }
    write_line("\n1 : Easy");
    write_line("2 : Medium");
    write_line("3 : Hard");
    int diff_choice = read_integerr("Choose your difficulty: ", 1, MAX_DIFFICULTY);
    current.details[current.attempts].difficulty = static_cast<Difficulty>(diff_choice);
    current.details[current.attempts].numbers = read_integerr("\nHow many numbers to remember: ", 5, MAX_NUMBERS);
    current.details[current.attempts].score = 0;
    current.details[current.attempts].numberscorrect = 0;
    current.details[current.attempts].time = 0.0; 
}

/**
 * @brief 
 * Sorts the leaderboard so that the highest score is on top and the lowest score is at the bottom.
 * If the amount of attempts goes above 10 then the lowest score will be deleted.
 * @param current current game being played made of struct play
 */
void sort_leaderboard(play &current)
{
    for (int i = 0; i < current.attempts - 1; i++)
    {
        for (int j = i + 1; j < current.attempts; j++)
        {
            if (current.details[j].score > current.details[i].score) // If the score after a score is bigger then they swap
            {
                play_details temp = current.details[i]; // The lower score goes to temporary spot
                current.details[i] = current.details[j]; // Its replaced by the bigger score
                current.details[j] = temp; // Then the bigger scores old spot is replaced by the smaller score that was stored in the temporary spot
            }
        }
    }
    if (current.attempts == MAX_LEADBOARD) // if the amount of attempts goes above 10 then the lowest score will be deleted.
    {
    current.attempts--;
    }
}

/**
 * @brief 
 * Converts the difficulty number to the equivalent word for when reading scores
 * @param i 
 * @param current 
 * @return string 
 */
string difficulty_description(int i, const play &current)
{
    switch (current.details[i].difficulty)
    {
        case Difficulty::Easy:
            return "Easy";
        case Difficulty::Medium:
            return "Medium";
        case Difficulty::Hard:
            return "Hard";
        default:
            return "Null";
    }
}

/**
 * @brief Get the difficulty delay to use
 * @param difficulty takes the players selected difficulty
 * @return int  returns the delay in milliseconds for the chosen difficulty
 */
int get_difficulty_delay(Difficulty difficulty) {
    switch (difficulty) {
        case Difficulty::Easy:
            return EASY_DELAY;
        case Difficulty::Medium:
            return MEDIUM_DELAY;
        case Difficulty::Hard:
            return HARD_DELAY;
        default:
            return EASY_DELAY;
    }
}

/**
 * @brief 
 * Draws the game window, displays the numbers one by one, tracks the time taken to recall the numbers and calculates the score
 * @param current current game being played made of struct play
 * @param number the array of numbers to be recalled
 * @param count the amount of numbers to be recalled
 * @param difficulty the chosen difficulty that affects how fast the numbers dissapear
 * @param my_font the font used for displaying text
 */
void draw_game(const int* number, int count, Difficulty difficulty, font my_font) {
    // Draws the numbers on the screen, one by one
    for (int i = 0; i < count; i++) {
        clear_screen(color_white());
        refresh_screen();
        process_events();
        delay(300);
        // Center and scale text
        int font_size = MAX_WIDTH / 8;
        draw_text(to_string(number[i]), color_black(), my_font, MAX_WIDTH / 2, MAX_HEIGHT / 2, font_size);
        refresh_screen();
        process_events();
        delay(get_difficulty_delay(difficulty));
    }
}

/**
 * @brief Handles the game logic like the input, timer, score and number recall
 * @param current current game being played made of struct play
 * @param number the array of numbers to be recalled
 * @param my_font the font used for displaying text
 */
void process_game(play &current, int* number, font my_font) {
    close_window("Number Memory");
    delay(300);
    write_line("Enter the numbers one by one:");
    create_timer("Recall");
    start_timer("Recall");
    for (int i = 0; i < current.details[current.attempts].numbers; i++) {
        int answer = read_integerr(to_string((i + 1)) + ": ", 0, DIGITS);
        if (answer == number[i]) {
            current.details[current.attempts].numberscorrect++;
        }
    }
    pause_timer("Recall");
    current.details[current.attempts].time = timer_ticks("Recall");
    reset_timer("Recall");
    current.details[current.attempts].score = ((current.details[current.attempts].numberscorrect * static_cast<int>(current.details[current.attempts].difficulty)) * 100000) / (current.details[current.attempts].time * 0.1);
    write_line("Your score is " + to_string(current.details[current.attempts].score));
    write_line("You got " + to_string(current.details[current.attempts].numberscorrect) + " out of " + to_string(current.details[current.attempts].numbers) + " correct!");
    write_line("You recalled the numbers in " + to_string(current.details[current.attempts].time) + " milliseconds!\n");
    read_string("Press enter to continue..");
    write_line("");
}

/**
 * @brief 
 * Manages the game loop, opening the window, starting the game and generating the random numbers
 * @param current current game being played made of struct play
 */
void play_game(play &current) {
    font my_font = load_font("Arial", "arial.ttf");
    open_window("Number Memory", MAX_WIDTH, MAX_HEIGHT);
    bool started = false;
    while (!started && !quit_requested()) {
        clear_screen(color_white());
        // Center and scale start message
        int start_font = MAX_WIDTH / 16;
        draw_text("Press Spacebar to Start.", color_black(), my_font, start_font, MAX_WIDTH / 6.5, MAX_HEIGHT / 2);
        refresh_screen();
        process_events();
        if (key_down(SPACE_KEY)) {
            started = true;
            delay(1000);
        }
    }
    int count = current.details[current.attempts].numbers;
    int* number = new int[count];
    for (int i = 0; i < count; i++) {
        number[i] = rnd(0, DIGITS);
    }
    draw_game(number, count, current.details[current.attempts].difficulty, my_font);
    process_game(current, number, my_font);
    delete[] number;
}

/**
 * @brief 
 * Displays the leaderboard with each players details
 * @param current current game being played made of struct play
 */
void leaderboard(const play &current)
{
    string difficulty = difficulty_description(0, current);
    write_line("------------------------------------- High Score -------------------------------------");
    write_line(current.details[0].name + " - Score: " + to_string(current.details[0].score) + " - Difficulty: " + difficulty + " - Numbers correct: " + to_string(current.details[0].numberscorrect) + "/" + to_string(current.details[0].numbers) + " - Recall time: " + to_string(current.details[0].time) + "s");
    write_line("--------------------------------------------------------------------------------------");
    for(int i = 1; i < current.attempts; i++)
    {
        difficulty = difficulty_description(i, current);
        write_line(to_string(i) + ": " + current.details[i].name + " - Score: " + to_string(current.details[i].score) + " - Difficulty: " + difficulty + " - Numbers correct: " + to_string(current.details[i].numberscorrect) + "/" + to_string(current.details[i].numbers) + " - Recall time: " + to_string(current.details[i].time) + "ms");
    }
}

/**
 * @brief 
 * Introduction to the game and how to play
 */
void intro()
{
    write_line("---------------------------------------------------- How to Play ----------------------------------------------------");
    write_line("-           The purpose of this game is to test your skills at recalling numbers that appear on the screen          -");
    write_line("-              You will be asked to enter your name, difficulty speed and how many numbers to remember              -");
    write_line("-      A window will open and once you start, numbers between 0 and 9 will appear and then dissapear one by one     -");
    write_line("-  The numbers will remain on the screen depending on the difficulty you chose, harder means they dissapear faster  -");
    write_line("-     Once all the numbers have been shown, the window will close and you will enter each number one at a time      -");
    write_line("- Your score will be calculated based on how many you get right, the difficulty and your time to recall the numbers -");
    write_line("---------------------------------------------------------------------------------------------------------------------");
    read_string("\nPress enter to start...\n");
}

/**
 * @brief 
 * Prompts the user if they want to play again
 * @return true if the user wants to play again, false otherwise
 */
bool play_again() {
    bool ask = false;
    while (!ask) {
        write_line("");
        string answer = to_lowercase(read_string("Play again? Y/n: "));
        if (answer == "n" || answer == "no") {
            return false;
        } else if (answer == "y" || answer == "yes") {
            write_line("\nType 1 to view How to Play");
            string entered = read_string("Or press Enter to continue");
            if (entered == "1") {
                intro();
            }
            return true;
        } else {
            write_line("Invalid option. Please enter 'Y' or 'N'.");
        }
    }
    return false;
}

/**
 * @brief  Main function of program
 */
int main()
{
    intro();
    play current;
    current.attempts = 0;
    bool again = true;
    while(again)
    {
        write_line("\n-+-<[  Welcome to the Number Memory Test by Jonathan Moffitt!  ]>-+-");
        menu(current);
        play_game(current);
        current.attempts++;
        sort_leaderboard(current);
        leaderboard(current); 
        again = play_again();
    }
    write_line("Thanks for playing!");
    return 0;
}