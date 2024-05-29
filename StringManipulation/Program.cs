using System;
using System.Collections.Generic;
using System.IO;

namespace StringManipulation
{
    internal class Program
    {
        static void Main()
        {
            // Load words from file
            string[] words = File.ReadAllLines("C:\\Users\\olive\\source\\repos\\StringManipulation\\StringManipulation\\Files\\Words.txt");

            // Randomly select a word
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)].ToLower();

            // Create a list of characters to represent the word with underscores
            char[] guessedWord = new char[wordToGuess.Length];
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                guessedWord[i] = '_';
            }

            int attempts = 7;
            List<char> guessedLetters = new List<char>();

            while (attempts > 0)
            {
                Console.Clear();
                Console.WriteLine("Hangman Game");
                Console.WriteLine($"Attempts left: {attempts}");
                Console.WriteLine("Guessed word: " + new string(guessedWord));
                Console.WriteLine("Guessed letters: " + string.Join(", ", guessedLetters));
                Console.Write("Enter a letter: ");
                char guess = Console.ReadLine().ToLower()[0];

                // Check if the letter has already been guessed
                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("You have already guessed that letter. Try again.");
                    continue;
                }

                guessedLetters.Add(guess);

                if (wordToGuess.Contains(guess))
                {
                    // Update guessedWord array
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            guessedWord[i] = guess;
                        }
                    }

                    // Check if the word is fully guessed
                    if (new string(guessedWord) == wordToGuess)
                    {
                        Console.Clear();
                        Console.WriteLine("Hangman Game");
                        Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
                        break;
                    }
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Wrong guess. Try again.");
                }
            }

            if (attempts == 0)
            {
                Console.Clear();
                Console.WriteLine("Hangman Game");
                Console.WriteLine("Sorry, you lost. The word was: " + wordToGuess);
            }

            Console.ReadLine();
        }
    }
}
