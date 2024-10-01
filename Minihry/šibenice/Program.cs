using System;
using System.IO;

namespace šibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\OndracekJ23\Documents\cs-neco-jako-projekt\Minihry\šibenice\slova.txt"; // Cesta k souboru se slovy

            // Zkontrolovat, zda soubor existuje
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Soubor se slovy neexistuje!");
                return;
            }

            // Načíst slova ze souboru
            string[] words = File.ReadAllText(filePath).Split(',');

            // Vybrat náhodné slovo
            Random random = new Random();
            string wordToGuess = words[random.Next(words.Length)].Trim().ToLower();

            // Nastavit počáteční stav hry
            char[] guessedWord = new string('_', wordToGuess.Length).ToCharArray();
            int lives = 6; // Počet pokusů
            bool isWordGuessed = false;
            string wrongLetters = "";

            Console.WriteLine("Vítej ve hře Šibenice!");

            // Hlavní smyčka hry
            while (lives > 0 && !isWordGuessed)
            {
                Console.WriteLine($"\nSlovo: {new string(guessedWord)}");
                Console.WriteLine($"Špatné pokusy: {wrongLetters}");
                Console.WriteLine($"Zbývající pokusy: {lives}");

                // Hráč zadá písmeno
                Console.Write("Zadej písmeno: ");
                char guess;
                if (!char.TryParse(Console.ReadLine().ToLower(), out guess))
                {
                    Console.WriteLine("Zadej platné písmeno!");
                    continue;
                }

                // Zkontrolovat, zda písmeno je ve slově
                if (wordToGuess.Contains(guess))
                {
                    // Aktualizovat správně uhodnutá písmena
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess)
                        {
                            guessedWord[i] = guess;
                        }
                    }

                    // Zkontrolovat, zda celé slovo je uhodnuto
                    if (new string(guessedWord) == wordToGuess)
                    {
                        isWordGuessed = true;
                        Console.WriteLine($"Gratulace! Uhodl jsi slovo: {wordToGuess}");
                    }
                }
                else
                {
                    // Nesprávné písmeno
                    if (!wrongLetters.Contains(guess))
                    {
                        wrongLetters += guess + " ";
                        lives--;
                    }
                }
            }

            if (!isWordGuessed)
            {
                Console.WriteLine($"Prohrál jsi! Slovo bylo: {wordToGuess}");
            }
        }
    }
}
