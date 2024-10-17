using System;
using System.Drawing;
using System.Linq;

namespace Hangman
{
    public class Game
    {
        public string WordToGuess { get; private set; }
        public int Mistakes { get; private set; }
        public char[] GuessedLetters { get; private set; }
        private Hangman hangman;

        public int MaxMistakes => hangman.MaxMistakes;

        public Game()
        {
            hangman = new Hangman();
        }

        public void StartGame()
        {
            WordToGuess = Utils.GetRandomWord(); // Rastgele il al
            GuessedLetters = new char[WordToGuess.Length];
            hangman = new Hangman();
        }

        public void CheckGuess(char guess)
        {
            if (!WordToGuess.Contains(guess))
            {
                Mistakes++;
            }
            else
            {
                // Doğru tahmin
                for (int i = 0; i < WordToGuess.Length; i++)
                {
                    if (WordToGuess[i] == guess)
                    {
                        GuessedLetters[i] = guess;
                    }
                }
            }
        }

        public Image GetHangmanImage()
        {
            return hangman.DrawHangman(Mistakes);
        }
    }

    public class Hangman
    {
        public int MaxMistakes => 6;

        public Image DrawHangman(int mistakes)
        {
            // Resim dosyalarını buradan yükleyin
            string imagePath = $"Resources/hangman-{mistakes}.png"; // resim dosyaları "hangman_0.png", "hangman_1.png", ... şeklinde olmalı
            return Image.FromFile(imagePath);
        }
    }
}

