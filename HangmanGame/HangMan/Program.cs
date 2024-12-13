string word = "hello world!";

int maxLives = 10;
int currentLives = maxLives;

bool win = false;

List<char> guessedLetters = new List<char>();

while(currentLives > 0 && !win)
{
    foreach(char c in word)
    {
        if (c == ' ')
            Console.Write(" ");
        else if(guessedLetters.Contains(c))
            Console.Write(c);
        else
            Console.Write("_");
    }
    Console.WriteLine("\nPlease guess a letter!");
    Console.WriteLine(currentLives +" " + "out of" + " " + maxLives + " lives remaining.");

    char guess = Convert.ToChar(Console.ReadLine());

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

    foreach(char c in word)
        if(!guessedLetters.Contains(c) && c != ' ')
            wordComplete = false;

    win = wordComplete;
}

if (win)
    Console.WriteLine("Congratulations, you won the game!");
else
    Console.WriteLine("Goodbye World :(");