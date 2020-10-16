using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Actor
    {
        protected char _icon = 'a';
        protected Vector2 _position;
        protected Vector2 _velocity;
        protected ConsoleColor _actorColor;

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
        
        public Actor()
        {
            _position = new Vector2();
            _velocity = new Vector2();
            _actorColor = ConsoleColor.Green;
        }

        public Actor(Vector2 position, char icon = 'a', ConsoleColor color = ConsoleColor.Green)
        {
            _icon = icon;
            _position = position;
            _velocity = new Vector2();
            _actorColor = color;
        }
        
        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            _position += _velocity;
            _position.X = Math.Clamp(_position.X, 0, Console.WindowWidth - 1);
            _position.Y = Math.Clamp(_position.Y, 0, Console.WindowHeight - 1);
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = _actorColor;
            Console.SetCursorPosition((int) _position.X, (int) _position.Y);
            Console.Write(_icon);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual void End()
        {

        }
    }
}
