using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;
        public bool Started { get; private set; } = false;

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            // Creating a new array of size _actors.Length + 1
            Actor[] appendedArray = new Actor[_actors.Length + 1];

            // Copy values from old array into new array
            for (int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }

            // Set last value in new array to the new actor
            appendedArray[appendedArray.Length - 1] = actor;

            // Copy new array over old array
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            // Do not allow index to be out of _actors bounds
            if (index < 0 || index >= _actors.Length)
                return false;

            // Create a new array of size _actors.Length - 1
            Actor[] tempArray = new Actor[_actors.Length - 1];

            // Create flag to check if the actor was removed
            bool actorRemoved = false;

            // Copy values from old array into new array,
            //  leaving out index
            int n = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (i != index)
                {
                    tempArray[n] = _actors[i];
                    n++;
                }
                else
                {
                    actorRemoved = true;
                }
            }

            // Copy new array over old array
            _actors = tempArray;

            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            // Create a new array of size _actors.Length - 1
            Actor[] tempArray = new Actor[_actors.Length - 1];

            // Create flag to check if the actor was removed
            bool actorRemoved = false;

            // Copy values from old array into new array,
            //  leaving out specified actor
            int n = 0;
            for (int i = 0; i < tempArray.Length; i++)
            {
                if (_actors[i] != actor)
                {
                    tempArray[n] = _actors[i];
                    n++;
                }
                else
                {
                    actorRemoved = true;
                }
            }

            // Copy new array over old array
            _actors = tempArray;

            return actorRemoved;
        }

        public void Start()
        {
            Started = true;
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Start();
            }
        }

        public void Update()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Update();
            }
        }

        public void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].End();
            }
        }
    }
}
