using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = 'a';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _consoleColor;
        protected Color _rayColor = Color.GREEN;

        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public Vector2 Velocity
        {
            get
            {
                return _velocity;
            }
            set
            {
                _velocity = value;
            }
        }

        public bool Started { get; private set; } = false;

        public Actor()
        {
            _position = new Vector2();
            _velocity = new Vector2();
            _consoleColor = ConsoleColor.Green;
            _rayColor = Color.GREEN;
        }

        public Actor(Vector2 position, char icon = 'a', ConsoleColor color = ConsoleColor.Green)
        {
            _icon = icon;
            _position = position;
            _velocity = new Vector2();
            _consoleColor = color;
            _rayColor = Color.GREEN;
        }

        public Actor(Vector2 position, Color color, char icon = 'a')
        {
            _icon = icon;
            _position = position;
            _velocity = new Vector2();
            _rayColor = color;
        }

        public Actor(Vector2 position, Color color, ConsoleColor consoleColor = ConsoleColor.Green, char icon = 'a')
            : this(position, icon, consoleColor)
        {
            _rayColor = color;
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update()
        {
            _position += _velocity;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);
        }

        public virtual void Draw()
        {
            Raylib.DrawText(_icon.ToString(), (int) _position.X * 20, (int) _position.Y * 20, 20, _rayColor);
            Console.ForegroundColor = _consoleColor;
            Console.SetCursorPosition((int) _position.X, (int) _position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual void End()
        {

        }
    }
}
