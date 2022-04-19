﻿using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private string _guessWords;
        private int index;
        private char charcterGuess;
        private char[] dashedWord;
        private int numOfLimbs = 6;

        public HangmanGame()
        {
            //My list of words(should be 20 or more)
            string[] _list = new string[]
                { "BURNOUT", "RATCHET", "FREDDY", "CLANK", "CUPHEAD", "MUGMAN", "PAPYRUS", "KNUCKLES", "GANONDORF"};

            //This will randomize the list
            index = new Random().Next(_list.Length);
            _guessWords = _list[index];

            //This converts the string into an character array
            dashedWord = _guessWords.ToCharArray();

            //Renders the gallows
            _renderer = new GallowsRenderer();

            //And this converts each character in the string to a dash
            //for (int i = 0; i < dashedWord.Length; i++)
            //{
            //    dashedWord[i] = '-';

            //    if (charcterGuess == dashedWord[i])
            //    {

            //    }
            //    else if (charcterGuess != dashedWord[i])
            //    {
            //        numOfLimbs--;
            //        _renderer.Render(5, 5, 5);
            //    }
            //}
        }

        public void GameLogic()
        {
            for (int i = 0; i < dashedWord.Length; i++)
            {
                dashedWord[i] = '-';

                if (charcterGuess == dashedWord[i])
                {

                }
                else if (charcterGuess != dashedWord[i])
                {
                    numOfLimbs--;
                    _renderer.Render(5, 5, 5);
                }
            }
        }

        public void Run()
        {
            _renderer.Render(5, 5, 6);

            while (numOfLimbs > 0)
            {

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(dashedWord);

                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What is your next guess: ");
                charcterGuess = Convert.ToChar(Console.ReadLine());
                Char.ToUpper(charcterGuess);
            }
        }
    }
}
