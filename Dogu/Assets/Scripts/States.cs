using UnityEngine;

namespace Dogu
{
    //State is just a decorator over a string to prevent ability to pass in any string as a state to AnimationManager, it has to be a state
    public class State
    {
        private string stateName;

        public State(string stateName)
        {
            this.stateName = stateName;
        }

        public State(State rhs)
        {
            stateName = rhs.stateName;
        }

        public string toString
        {
            get
            {
                return stateName;
            }
        }
    }

    public struct States
    {
        //Thank you stackoverflow, could just have const in c# since don't gotta new everything but ead only is great.
        public static readonly State IDLE = new State("Idle");
        public static readonly State ATTACKING = new State("Attack");
        public static readonly State DYING = new State("Die");
        public static readonly State MOVING = new State("Move");

        //These states are only available to Player, so Enemies should not even have to allocate memory for these.
        public class PlayerStates
        {
            public PlayerStates(Player player)
            { }
            public readonly State JUMPING = new State("Jump");
            public readonly State DOUBLEJUMPING = new State("DoubleJump");
            public readonly State ATTACKINGFROMRANGE = new State("Shoot");
            public readonly State DAMAGED = new State("Damaged");
            public readonly State STOPPING = new State("Stop");
        }
    }
}