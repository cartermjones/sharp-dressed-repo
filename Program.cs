/*
    This is a number guessing game built in C# using Microsoft Visual Studio. 
    It was built from an online tutorial.
    I made some modifications for score-keeping.
*/

using System;

//Namespace
namespace NumberGuesser
{
    //Main Class
    class Program
    {
        
        //Entry-point method
        static void Main(string[] args)
        {
            GetAppInfo(); //Run GetAppInfo function to get info

            GreetUser(); //Greet user, ask name

            //
            int win = 0;
            int loss = 0;

            while (true)
            {

                //Create a new random object
                Random random = new Random();

                int correctNumber = random.Next(1, 10);

                //Init guess var
                int guess = 0;

                Console.WriteLine("Guess a number between 1 and 10...");

                //While guess is not correct execute this code block
                while (guess != correctNumber)
                {
                    //Get user's input
                    string guessInput = Console.ReadLine();

                    //Make sure its a number
                    if (!int.TryParse(guessInput, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "That's not a number, bro. Try again. 123456789");
                        //Keep going
                        continue;
                    }

                    //Cast into guess var
                    guess = Int32.Parse(guessInput);

                    //Match guess to correct number
                    if (guess != correctNumber)
                    {
                        //Increment the number of losses.
                        loss++;

                        //Display loss message to user.
                        PrintColorMessage(ConsoleColor.Red, "That's not the right number! Try again");
                        Console.WriteLine("Wins: {0} Losses: {1}", win, loss);
                    }
                }

                //Increment the number of wins.
                win++;

                //Print Success message
                PrintColorMessage(ConsoleColor.Yellow, "Correct!");

                Console.WriteLine("Wins: {0} Losses: {1}", win, loss);

                //Ask to play again
                Console.WriteLine("Play again? [Y or N]");

                //Get answer
                string answer = Console.ReadLine().ToUpper();

                if (answer == "Y" || answer == "y")
                {
                    continue;
                }

                else if (answer == "N" || answer == "n")
                {
                    Console.WriteLine("Total Wins: {0}  Total Losses: {1} ", win, loss);

                    float percentage = ((float)win / (float)loss) * 100;

                    Console.WriteLine("It looks like you won {0}% of the time.", percentage);

                    return;
                }

                else
                {
                    return;
                }

            }
        }
    
        //Get and display app info
        static void GetAppInfo()
        {
            //Set app vars
            string appName = "Number Guesser";
            string appVersion = "1.0.1";
            string appAuthor = "Carter Jones";

            //Change text color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}; Version {1} by {2}", appName, appVersion, appAuthor);

            //Reset text color
            Console.ResetColor();
        }

        //Ask user name and greet.
        static void GreetUser()
        {
            Console.WriteLine("Welcome to the Number Guesser! What's your name? ");

            string userName = Console.ReadLine();

            Console.WriteLine("Hi, {0}. Let's play a game...", userName);
        }

        //Print color message
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
