using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;
        private Actor _actor;
        private Player _player;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;


        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }


        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            Console.CursorVisible = false;

            _scene = new Scene();
            _actor = new Actor(new Vector2(10, 10), 'O', ConsoleColor.Red);
            _actor.Velocity.X = 1;
            _player = new Player(new Vector2());

            _scene.AddActor(_actor);
            _scene.AddActor(_player);
        }


        //Called every frame.
        public void Update()
        {
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Console.Clear();
            _scene.Draw();
        }


        //Called when the game ends.
        public void End()
        {

        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver)
            {
                Update();
                Draw();
                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                System.Threading.Thread.Sleep(150);
            }

            End();
        }

        /// <summary>
        /// Return whether or not a key is pressed
        /// </summary>
        /// <returns>The pressed ConsoleKey</returns>
        public static ConsoleKey GetNextKey()
        {
            // If the user hasn't pressed a key, return
            if (!Console.KeyAvailable)
            {
                return 0;
            }

            // Return the key that was pressed
            return Console.ReadKey(true).Key;
        }

    }
}
