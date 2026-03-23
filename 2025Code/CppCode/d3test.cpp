#include "splashkit.h"
#include "utilities.h"
using std::to_string;
using std::string;


class scoreboard
{
public:
    string player;
    int score;

    scoreboard()
    {
        player = "Unknown";
        score = 0;
    }

    scoreboard(string name, int value)
    {
        this->player = name;
        this->score = value;
    }

};

class scoreboard_array
{
private:
    scoreboard* data;
    int size;
    int capacity;

public:
    scoreboard_array()
    {
        size = 0;
        capacity = 2;
        data = new scoreboard[capacity];
    }

    ~scoreboard_array()
    {
        delete[] data;
    }

    void push_back(scoreboard s)
    {
        if (size == capacity)
        {
            scoreboard* temp = new scoreboard[capacity * 2];
            for (int i = 0; i < size; ++i)
            {
                temp[i] = data[i];
            }
            delete[] data;
            data = temp;
            capacity *= 2;
        }
        data[size] = s;
         size++;
    }

    scoreboard& operator[](int index)
    {
        return data[index];
    }

    int get_size()
    {
        return size;
    }
};


int main()
{
    scoreboard_array* scores = new scoreboard_array();

    scores->push_back(scoreboard("Jon", 100));
    scores->push_back(scoreboard("Bob", 75));
    scores->push_back(scoreboard("Tinga", 42));
    scores->push_back(scoreboard("Timmy", 88));

    for (int i = 0; i < scores->get_size(); i++)
{
    write_line("Player: " + (*scores)[i].player + " Score: " + to_string((*scores)[i].score));
}

    delete scores;
    scores = nullptr;

    return 0;
}