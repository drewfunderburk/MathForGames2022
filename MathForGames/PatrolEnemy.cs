using MathLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MathForGames
{
    class PatrolEnemy : Actor
    {
        private Vector2 _patrolDistance;
        private Vector2 _origin;

        public PatrolEnemy() : base()
        {
            _origin = _position;
            _patrolDistance = new Vector2(5, 0);
        }

        public PatrolEnemy(Vector2 position, Vector2 patrolDistance, char icon = 'P', ConsoleColor color = ConsoleColor.Red) : base(position, icon, color)
        {
            _origin = _position;
            _patrolDistance = patrolDistance;
        }

        public override void Start()
        {
            // Start the enemy moving if the patrol axis is  > 0
            if (_patrolDistance.X > 0)
                Velocity.X = 1;
            else if (_patrolDistance.Y > 0)
                Velocity.Y = 1;

            base.Start();
        }

        public override void Update()
        {
            if (Position.X - _origin.X >= _patrolDistance.X)
                Velocity.X *= -1;

            else if (Position.X - _origin.X <= -_patrolDistance.X)
                Velocity.X *= -1;

            if (Position.Y - _origin.Y >= _patrolDistance.Y)
                Velocity.Y *= -1;

            else if (Position.Y - _origin.Y <= -_patrolDistance.Y)
                Velocity.Y *= -1;

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
