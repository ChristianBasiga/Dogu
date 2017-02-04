using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogu
{
    public class PlayerController : MonoBehaviour
    {
        //Hate that I can't use lambdas without delegates in c#, cause literally has only one use right now so seems like a huge waste of
        //a variable
        delegate bool MoveLogic();
        private Player playerControlling;
        //Will finish implementing double jumping later
        int timesJumped;
        // Use this for initialization
        void Start()
        {  
            playerControlling = GameObject.Find("DoguSprite").GetComponent<Player>();
            timesJumped = 0;
        }

        // Update is called once per frame
        void Update()
        {
            processInput();
        }

        void processInput()
        {
            float direction = Input.GetAxis("Horizontal");
            if (direction != 0)
            {
                playerControlling.GetComponent<SpriteRenderer>().flipX = (direction < 0) ? true : false; 
                Debug.Log(playerControlling.state.toString);
                move(new Vector3(direction, 0, 0));
            }
            else if (direction == 0)
            {
                if (playerControlling.prevState == States.MOVING)
                    playerControlling.state = playerControlling.playerStates.STOPPING;
                
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerControlling.state = States.ATTACKING;

            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                //Player shouldn't have that property, but since temporary objects and functors don't exist in c#, it's my only choice.
                playerControlling.state = playerControlling.playerStates.ATTACKINGFROMRANGE;
            }
            if (Input.GetKeyDown(KeyCode.Space) /*&& timesJumped < 2*/)
            {
                ++timesJumped;
                
                playerControlling.state = (timesJumped == 1)? playerControlling.playerStates.JUMPING
                : playerControlling.playerStates.DOUBLEJUMPING;

                StartCoroutine(jump(playerControlling.stats.speed));
            }
        }

        void move(Vector3 movement)
        {
            playerControlling.state = States.MOVING;
            transform.Translate(movement * Time.deltaTime * playerControlling.stats.speed);
        }

        IEnumerator jump(float limit)
        {
            Vector3 initPosition = transform.position;
            Vector3 goalPosition = Vector3.down;
            MoveLogic condition = () => { return transform.position.y > 0; };

            if (limit > 0)
            {
                goalPosition = Vector3.up;
                condition = () => { return transform.position.y < goalPosition.y; };
            }
            goalPosition *= limit;
           
            while (condition())
            {
                move(goalPosition / limit);
                yield return new WaitForEndOfFrame();
            }
            //Fall back down
            if (transform.position.y > 0 )
                StartCoroutine(jump(-limit));
            else
            {
                //Reset y back to zero because it will only get very close to zero
                Vector3 resettedY = transform.position;
                resettedY.y *= 0;
                transform.position = resettedY;
                timesJumped = 0;
            }
        }
    }
}