using System;
using System.IO;

namespace Hangman
{
    public static class Utils
    {
        public static string GetRandomWord()
        {
            string filePath = "C:\Users\hakan\source\repos\HangmanGame\HangmanGame\bin\Debug\Resources\Words.txt";
            string[] words = File.ReadAllLines(filePath);
            Random random = new Random();
            int index = random.Next(words.Length);
            return words[index].Trim(); // Satır sonu boşluklarını kaldır
        }

        public static string GetMaskedWord(char[] guessedLetters, string wordToGuess)
        {
            char[] maskedWord = new char[wordToGuess.Length];
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                maskedWord[i] = guessedLetters[i] != '\0' ? guessedLetters[i] : '_';
            }
            return new string(maskedWord);
        }

        public static bool IsWordGuessed(char[] guessedLetters, string wordToGuess)
        {
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guessedLetters[i] != wordToGuess[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}

