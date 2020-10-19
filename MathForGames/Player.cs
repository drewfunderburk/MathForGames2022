using MathLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace MathForGames
{
    class Player : Actor
    {
        public Player() : base()
        {

        }

        public Player(Vector2 position, char icon = '@', ConsoleColor color = ConsoleColor.Green) 
            : base(position, icon, color) 
        { }

        public Player(Vector2 position, Color color, char icon = '@', ConsoleColor consoleColor = ConsoleColor.Green)
            : base(position, color, consoleColor, icon)
        { }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            ConsoleKey keyPressed = Game.GetNextKey();

            switch (keyPressed)
            {
                case ConsoleKey.A:
                    _velocity.X = -1;
                    break;
                case ConsoleKey.D:
                    _velocity.X = 1;
                    break;
                case ConsoleKey.W:
                    _velocity.Y = -1;
                    break;
                case ConsoleKey.S:
                    _velocity.Y = 1;
                    break;
                default:
                    _velocity.X = 0;
                    _velocity.Y = 0;
                    break;
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void End()
        {
            base.End();
        }

    }
}
