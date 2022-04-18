using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;

        public HangmanGame()
        {
            //My list of words(should be 20 or more)
            string[] _list = new string[]
                { "BURNOUT", "RATCHET", "FREDDY", "CLANK", "CUPHEAD", "MUGMAN", "PAPYRUS", "KNUCKLES"};

            //This will randomize the list
            int index = new Random().Next(_list.Length);
            string guessWords = _list[index];

            string charcterGuess = "";

            //Renders the gallows
            _renderer = new GallowsRenderer();
        }

        public bool isStillAlive()
        {
            bool allLimbs = false;

            //if()
            //{
            //    return allLimbs;
            //}
        }

        public void Run()
        {
            //int limbs = 6;

            //while (limbs > 0)
            //{

            //}

            //_renderer.Render(5, 5, 6);

            //Console.SetCursorPosition(0, 13);
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("Your current guess: ");
            //Console.WriteLine("--------------");
            //Console.SetCursorPosition(0, 15);

            //Console.ForegroundColor = ConsoleColor.Green;

            //Console.Write("What is your next guess: ");
            //var nextGuess = Console.ReadLine();
        }

    }
}
