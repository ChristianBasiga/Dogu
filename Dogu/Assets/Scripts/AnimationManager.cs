using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Dogu
{
    //Okay should've only touched this in animationManaging branch, but fuck it
    public class AnimationManager : MonoBehaviour
    {

        //There will be multiple AnimationManager instances, because if only one, unless thread the animation plays
        //even then it's in sequence, but every AnimatableObject needs to have an animationManager to manage animations
        //And only manages own animations, this way two different animations can play because AnimationManager wont
        //be trying to play it all.
        public AnimatableObject objectManaging;

        
        private void Update()
        {
            if (objectManaging != null )
            {
                triggerAnim();
            }
        }

        void triggerAnim()
        {
            //TIL: If keep triggering animation it won't cut off animation mid niamtion it will do full animation
            //so all frames of animation is done in a single frame.
            Animator animator = objectManaging.gameObject.GetComponent<Animator>();
            animator.SetTrigger(objectManaging.state.toString);
        }
    }
}