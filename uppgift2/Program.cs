using System;
using System.Collections.Generic;
using System.Text;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int guessCount = 10;
            bool haveWon = false;
            List<char> correctLetters = new List<char>();
            StringBuilder incorrectLetters = new StringBuilder();
            string[] secretWords = new string[] { "ryssland", "frankrike", "turkiet", "tyskland", "storbritannien", "spanien", "ukraina", "polen", "nederländerna", "sverige", "danmark", "finland", "norge" };
            int randomNumber = new Random().Next(0, secretWords.Length);
            char[] secretWord = secretWords[randomNumber].ToCharArray();
            int secretWordCount = 0;
            

            while (guessCount > 0)
            {

                foreach (char character in secretWord)
                {
                    if (correctLetters.Contains(character))
                    {
                        Console.Write($" {character} ");
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }

                }
                Console.WriteLine("");
                Console.WriteLine($"Du har {guessCount} försök");
                Console.WriteLine("Inkorrekta bokstäver: " + incorrectLetters);
                Console.Write("Gissa på det hemliga ordet: ");
                string guess = Console.ReadLine();
                guess = guess.ToLower();

                if (guess.Length == 1)
                {
                    bool isTheSame = IsTheSame(guess, incorrectLetters, correctLetters);
                    if (isTheSame == true)
                    {
                        Console.WriteLine("Du kan inte gissa på samma bokstav");
                    }
                    else
                    {
                        int letterCheck = DoesItContain(guess, secretWord);
                        if (letterCheck == 0)
                        {
                            incorrectLetters.Append(guess.ToUpper() + " ");
                            guessCount--;
                        }
                        else
                        {
                            correctLetters.Add(guess[0]);
                            secretWordCount += letterCheck;
                        }
                    }

                }
                else if (guess.Length > 1)
                {
                    string s = string.Join("", secretWord);
                    if (guess == s)
                    {
                        haveWon = true;
                        break;
                    }
                    guessCount--;
                }

                if (secretWord.Length == secretWordCount)
                {
                    haveWon = true;
                    break;
                }
            }

            if (haveWon == true)
            {
                string svar = string.Join("", secretWord);
                Console.WriteLine($"Du vann!, svaret var {svar.ToUpperInvariant()}");
            }
            else
            {
                Console.WriteLine("Du förlorade");
            }

        }

        static int DoesItContain(string argLetter, char[] argChar)
        {
            int isTrue = 0;
            foreach (char e in argChar)
            {
                if (e == argLetter[0])
                {
                    isTrue++;
                }
            }
            return isTrue;
        }

        static bool IsTheSame(string argLetter, StringBuilder argString, List<char> argCorrect)
        {
            bool isTrue = false;
            for (int i = 0; i < argString.Length; i++)
            {
                if (argLetter.ToUpper()[0] == argString[i])
                {
                    isTrue = true;
                }
            }

            if (isTrue == false)
            {
                foreach (char e in argCorrect)
                {
                    if (argLetter[0] == e)
                    {
                        isTrue = true;
                    }
                }
            }


            return isTrue;
        }




    }
}



