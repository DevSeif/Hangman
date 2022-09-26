using System;
using System.Text;

namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int guessCount = 10;
            bool haveWon = false;
            char[] correctLetters = new char[] {};
            StringBuilder incorrectLetters = new StringBuilder();
            string[] secretWords = new string[] {"ryssland", "frankrike", "turkiet", "tyskland", "storbritannien", "spanien", "ukraina", "polen", "nederländerna", "sverige", "danmark", "finland", "norge" };
            int randomNumber = new Random().Next(0, secretWords.Length);
            char[] secretWord = secretWords[randomNumber].ToCharArray();

            while(guessCount != 0 || haveWon == false)
            {
                Console.WriteLine($"_ _ _ _ _ _ _ _");
                Console.WriteLine($"Du har {guessCount} försök");
                Console.WriteLine("Inkorrekta bokstäver: " + incorrectLetters);
                Console.Write("Gissa på det hemliga ordet: ");
                string guess = Console.ReadLine();
                guess = guess.ToLower();

                if(guess.Length == 1)
                {
                    bool isTheSame = IsTheSame(guess, incorrectLetters, correctLetters);
                    if (isTheSame == true)
                    {
                        Console.WriteLine("Du kan inte gissa på samma bokstav");
                    }
                    else
                    {
                        bool letterCheck = DoesItContain(guess, secretWord);
                        if (letterCheck == false)
                        {
                            incorrectLetters.Append(guess.ToUpper() + " ");
                            guessCount--;
                        }
                        else
                        {
                            Console.WriteLine("Rätt bokstav");
                        }
                    }
                    
                }
                else if (guess.Length > 1)
                {
                    if (guess == secretWord.ToString())
                    {
                        haveWon = true;
                        break;
                    }
                    guessCount--;
                }
            }

        }

        static bool DoesItContain(string argLetter, char[] argChar)
        {
            bool isTrue = false;
            foreach (char e in argChar)
            {
                if(e == argLetter[0])
                {
                    isTrue = true;
                }
            }
            return isTrue;
        }

        static bool IsTheSame(string argLetter, StringBuilder argString, char[] argCorrect)
        {
            bool isTrue = false;
            for(int i = 0; i < argString.Length; i++)
            {
                Console.WriteLine("");
                if (argLetter.ToUpper()[0] == argString[i])
                {
                    isTrue = true;
                }
            }
            if (isTrue = false)
            {
                foreach(char e in argCorrect)
                {
                    Console.WriteLine(e + "" + argLetter[0]);
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



