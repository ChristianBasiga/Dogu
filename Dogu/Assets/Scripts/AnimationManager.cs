using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour {

    //There will be multiple AnimationManager instances, because if only one, unless thread the animation plays
    //even then it's in sequence, but every AnimatableObject needs to have an animationManager to manage animations
    //And only manages own animations, this way two different animations can play because AnimationManager wont
    //be trying to play it all.
    AnimatableObject objectManaging;
    AnimatableObject managing
    {
        set
        {
            objectManaging = value;
        }
        
    }
	
    void triggerAnim(string animToTrigger)
    {
        
    }
}
