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
        private char charcterGuess;
        private string _dashedWord;
        private int numOfLimbs = 6;
        private char[] overWrite;

        public string ReturnDashed()
        {
            return _dashedWord;
        }

        public HangmanGame()
        {
            //My list of words(should be 20 or more)
            string[] _list = new string[]
                { "BURNOUT", "RATCHET", "FREDDY", "CLANK", "CUPHEAD", "MUGMAN", "PAPYRUS", "KNUCKLES", "GANONDORF", "SANS",
                 "MARIO", "LUIGI", "KRATOS", "ATREUS"};

            //This will randomize the list
            index = new Random().Next(_list.Length);
            _guessWords = _list[index];

            //And this converts each character in the string to a dash
            for (int i = 0; i < _guessWords.Length; i++)
            {
                _dashedWord += "+";
            }
        }

        public void OverWrite()
        {
            overWrite = _dashedWord.ToCharArray();

            for (int i = 0; i < _guessWords.Length; i++)
            {
                if (_guessWords[i] == charcterGuess)
                {
                    overWrite[i] = charcterGuess;
                }
            }
            _dashedWord = new string(overWrite);

            //Renders the gallows
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            //_renderer.Render(5, 5, 6);

            while (numOfLimbs > 0)
            {
                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(ReturnDashed());

                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What is your next guess: ");
                string guess = Console.ReadLine();
                guess = guess.ToUpper();
            }
        }
    }
}
