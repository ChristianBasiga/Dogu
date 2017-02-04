using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogu
{
    public class Player : AnimatableObject {

        State currentState;
        
        AnimationManager animationManager;
        Stats playerStats;
        //Hearts that drain.
        Stack<GameObject> hearts;


       
        
        void getHeartReferences()
        {
            for (short i = 0; i < 4; i++)
                hearts.Push(GameObject.Find("Heart" + i));
        }

        void setDefaultPlayerStats()
        {
            //Allocating new memoery each time rather than just changing it?
            //    stats = new Stats(4, 10.0); Inefficient
            playerStats.hp = 4;
            playerStats.speed = 10.0f;

        }

        private void Awake()
        {
            playerStates = new States.PlayerStates(this);
            playerStats = new Stats();
            currentState = new State(States.IDLE);
        }
        // Use this for initialization
        void Start() 
        {

            setDefaultPlayerStats();

            /*getHeartReferences();
            setDefaultPlayerStats();
            */
        }

        // Update is called once per frame
        void Update()
        {
            if (stats.hp <= 0)
                currentState = States.DYING;
        }

        public void damage()
        {
            --playerStats.hp;
            GameObject heart = hearts.Pop();
            
        }

        public override State state
        {
            set
            {
                //Previous state always one step behind currentState
                prevState = currentState;
                currentState = value;
            }
            get
            {
                return currentState;
            }
        }

        //Needed for double jumping and for doing stop animation
        public State prevState
        {
            set; get;
        }

        public Stats stats
        {
            get
            {
                return playerStats;
            }
        }
        public States.PlayerStates playerStates
        {
            private set;
            get;
        }

       
    }
}