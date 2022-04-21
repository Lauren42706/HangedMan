using System;
using System.Linq;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guessWords;
        private int index;
        private string _dashedWord;
        private int numOfLimbs;
        private char[] overWrite;
        private string guess;

        public string ReturnDashed()
        {
            return _dashedWord;
        }

        public HangmanGame()
        {
            //My list of words(should be 20 or more)
            string[] _list = new string[]
                { "BURNOUT", "RATCHET", "FREDDY", "CLANK", "CUPHEAD", "MUGMAN", "PAPYRUS", "KNUCKLES", "GANONDORF", "SANS",
                 "MARIO", "LUIGI", "KRATOS", "ATREUS", "MILES", "SONIC", "STEVEN", "CYNTHIA", "BOWSER", "KOOPA", "GALAGA"};

            //This will randomize the list
            index = new Random().Next(_list.Length);
            _guessWords = _list[index];

            //And this converts each character in the string to a dash
            for (int i = 0; i < _guessWords.Length; i++)
            {
                _dashedWord += "+";
            }

            //Renders the gallows
            _renderer = new GallowsRenderer();
        }

        public void OverWrite(char charcterGuess)
        {
            //turning the dashedWord into an array
            overWrite = _dashedWord.ToCharArray();

            /*the forloops loops through each charcter of the word, and the overWrite character overwrites the dashes in the string*/
            for (int i = 0; i < _guessWords.Length; i++)
            {
                if (_guessWords[i] == charcterGuess)
                {
                    overWrite[i] = charcterGuess;
                }
            }
            //overwriting the dashes
            _dashedWord = new string(overWrite);
        }


        public void Run()
        {
            numOfLimbs = 6;

            bool gaem = true;


            while (gaem)
            {
                _renderer.Render(5, 5, numOfLimbs);

                try
                {
                        Console.SetCursorPosition(0, 13);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Your current guess: ");
                        Console.WriteLine(ReturnDashed());

                        Console.SetCursorPosition(0, 15);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("What is your next guess: ");
                        guess = Console.ReadLine();
                        guess = guess.ToUpper();

                        Console.SetCursorPosition(35, 15);
                        Console.WriteLine("                                                        ");

                        OverWrite(guess[0]);
                }
                catch (IndexOutOfRangeException EX)
                {
                    Console.SetCursorPosition(35, 15);
                    Console.Write(EX.Message);
                }

                if (guess.Length > 1)
                {
                    Console.SetCursorPosition(35, 15);
                    Console.Write("You can't enter more than 1 letter.");
                }

                for (int i = 0; i < _guessWords.Length; i++)
                {
                    //if the letter is not in the word
                    //i found out this loops through each letter and decrement on each character.
                    if (_guessWords.Contains(guess))
                    {
                        
                    }
                    else if (!_guessWords.Contains(guess))
                    {
                        numOfLimbs--;

                        break;
                    }

                }

                Console.SetCursorPosition(0, 17);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ReturnDashed());

                if (_dashedWord == _guessWords)
                {
                    Console.SetCursorPosition(0, 18);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"You Win! The word was {_guessWords}");
                    gaem = false;
                }

                if (numOfLimbs == 0)
                {
                    _renderer.Render(5, 5, 0);

                    Console.SetCursorPosition(0, 18);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You Lose! The word was {_guessWords}");
                    gaem = false;
                }
            }
        }
    }
}
