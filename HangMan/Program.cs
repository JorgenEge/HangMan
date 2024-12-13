using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            PlayGame();

            Console.WriteLine("Do you want to play again? (y/n)");
            string response = Console.ReadLine().ToLower();
            playAgain = response == "y";
        }
    }

    static void PlayGame()
    {
        string word = "hello world!";

        int maxLives = 7;
        int currentLives = maxLives;

        bool win = false;

        List<char> guessedLetters = new List<char>();

        while (currentLives > 0 && !win)
        {
            DrawHangman(maxLives - currentLives);

            foreach (char c in word)
            {
                if (c == ' ')
                    Console.Write(" ");
                else if (guessedLetters.Contains(c))
                    Console.Write(c);
                else
                    Console.Write("_");
            }
            Console.WriteLine("\nPlease guess a letter!");
            Console.WriteLine(currentLives + " " + "out of" + " " + maxLives + " lives remaining.");

            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.Length != 1)
            {
                Console.WriteLine("Invalid input. Please guess a single letter.");
                continue;
            }

            char guess = input[0];

            if (guess == ' ')
            {
                Console.WriteLine("Spaces are not valid guesses. Please guess a letter.");
                continue;
            }

            if (word.Contains(guess) && !guessedLetters.Contains(guess))
                Console.WriteLine("Correct!");
            else
            {
                Console.WriteLine("Incorrect!");
                currentLives--;
            }
            guessedLetters.Add(guess);

            bool wordComplete = true;

            foreach (char c in word)
                if (!guessedLetters.Contains(c) && c != ' ')
                    wordComplete = false;

            win = wordComplete;
        }

        if (win)
            Console.WriteLine("Congratulations, you won the game!");
        else
            Console.WriteLine("Goodbye World :(");
    }

    static void DrawHangman(int wrongGuesses)
    {
        string[] hangmanStages = new string[]
        {
            @"
  +---+
  |   |
      |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
            @"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
        };

        Console.WriteLine(hangmanStages[wrongGuesses]);
    }
}