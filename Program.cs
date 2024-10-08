﻿
string secret = "abfc"; // Hardcoded secret string (can be changed)
int secretLength = secret.Length;

// intro and game setup
Console.WriteLine($"Hello, I have chosen {secretLength} letters between 'a' and 'g' and have arranged them in a particular order.");
Console.WriteLine("Your job is to guess the letters and put them in the right order.");

// loop control variables
int guessCount = 0;
bool isGuessed = false;

// game loop
while (!isGuessed)
        {
guessCount++;
//players guess and input handling
Console.WriteLine($"\nGuess #{guessCount}: Please guess a sequence of {secretLength} lowercase letters with no repeats.");
           
string? input = Console.ReadLine(); // Allow null input with '?'
if (input == null) //Orginaily guess.Length != secretLength || !IsValidGuess(guess)) but theres was a null
            {
                Console.WriteLine("Input cannot be null. Please enter a valid guess.");
                continue;
            }
            string guess = input.Trim().ToLower();


            // Validate guess
            if (guess.Length != secretLength || !IsValidGuess(guess))
            {
                Console.WriteLine("Invalid guess. Please enter 4 letters between 'a' and 'g', with no duplicates.");
                continue;
            }


// compare the guess with the secret string
int correctPosition = 0;
int correctLetterWrongPosition = 0;


 HashSet<char> remainingSecretLetters = new HashSet<char>();


            // count letters that are correct and in the correct position
            for (int i = 0; i < secretLength; i++)
            {
                if (guess[i] == secret[i])
                {
                    correctPosition++;
                }
                else
                {
                    remainingSecretLetters.Add(secret[i]);
                }
            }


            // count letters that are correct but in the wrong position
            for (int i = 0; i < secretLength; i++)
            {
                if (guess[i] != secret[i] && remainingSecretLetters.Contains(guess[i]))
                {
                    correctLetterWrongPosition++;
                    remainingSecretLetters.Remove(guess[i]);
                }
            }
 // feedback           
 Console.WriteLine($"  - {correctPosition} in the right positions");
 Console.WriteLine($"  - {correctLetterWrongPosition} in the wrong positions");
// checks if the player has guessed the secret correctly
            if (correctPosition == secretLength)
            {
                isGuessed = true;
                Console.WriteLine($"\nYou did it! You guessed my secret ({secret}) in {guessCount} guesses.");
            }
        }
   


    // validate if the guess contains only 'a' to 'g' and no repeated letters
     static bool IsValidGuess(string guess)
{
     if (guess.Length != 4) return false;
        HashSet<char> seenLetters = new HashSet<char>();
        foreach (char c in guess)
        {
            if (c < 'a' || c > 'g' || seenLetters.Contains(c))
                return false;
            seenLetters.Add(c);
        }
        return true;
    }
