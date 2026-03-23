using static System.Convert;
using static SplashKitSDK.SplashKit;

const int MINUTES_PER_HOUR = 60;
double speed;
double timeRemaining;
double totalDistance, totalTime;
string name;
string userInput;
double distance, time;
double distanceRemaining;

Write("What is your name: ");
name = ReadLine();

WriteLine();
WriteLine($"Hi {name}.");
WriteLine();

Write("How far have you travelled so far? Enter km: ");
userInput = ReadLine();
distance = ToDouble(userInput);

Write("How long has it taken? Enter minutes: ");
userInput = ReadLine();
time = ToDouble(userInput);

WriteLine("What is the remaining distance? Enter km: ");
userInput = ReadLine();
distanceRemaining = ToDouble(userInput);

speed = distance / (time / MINUTES_PER_HOUR);
WriteLine();
WriteLine($"Your average speed is {speed} km/h.");
WriteLine();

timeRemaining = (distanceRemaining / speed) * MINUTES_PER_HOUR;
WriteLine($"The time remaining is {timeRemaining} minutes.");
WriteLine();

totalDistance = distance + distanceRemaining;
WriteLine($"Your total distance is {totalDistance} km.");
WriteLine();

totalTime = time + timeRemaining;
WriteLine($"Your total time is {totalTime} minutes.");
WriteLine();