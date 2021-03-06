﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Game
    {
        private static bool _gameOver = false;
        private Scene _scene;
        private Actor _actor;
        private Player _player;
        private PatrolEnemy _pEnemy;

        public static ConsoleColor DefaultColor { get; set; } = ConsoleColor.White;


        //Static function used to set game over without an instance of game.
        public static void SetGameOver(bool value)
        {
            _gameOver = value;
        }


        //Called when the game begins. Use this for initialization.
        public void Start()
        {
            // Creates new window for Raylib
            Raylib.InitWindow(1024, 760, "Math For Games");

            // Set target fps
            Raylib.SetTargetFPS(60);

            // Setup console window
            Console.CursorVisible = false;
            Console.Title = "Math For Games";

            // Creates a new scene for our actors
            _scene = new Scene();

            // Creates a new actor
            _actor = new Actor(new Vector2(10, 10), Color.RED, ConsoleColor.Red, 'a');

            _actor.Velocity.X = 1;
            _pEnemy = new PatrolEnemy(new Vector2(15, 30), new Vector2(3, 0));

            _player = new Player(new Vector2());

            _scene.AddActor(_actor);
            _scene.AddActor(_player);
            _scene.AddActor(_pEnemy);


            _scene.Start();
        }


        //Called every frame.
        public void Update()
        {
            
            _scene.Update();
        }

        //Used to display objects and other info on the screen.
        public void Draw()
        {
            Raylib.BeginDrawing();

            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawRectangle(500, 500,30,30,Color.GREEN);

            Console.Clear();
            _scene.Draw();

            Raylib.EndDrawing();
        }


        //Called when the game ends.
        public void End()
        {
            _scene.End();
        }


        //Handles all of the main game logic including the main game loop.
        public void Run()
        {
            Start();

            while (!_gameOver && !Raylib.WindowShouldClose())
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
