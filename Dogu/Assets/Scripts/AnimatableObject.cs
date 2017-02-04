using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface AnimatableObject
{
    //to manage an objects animations, this is hardd coupling, because AnimatableObject needs AnimationManager to be set,
    //and AnimationManagers need reference back to AnimatableObject so it knows what it's managing
    AnimationManager animationManager { set; get; }   
    GameObject gameObject { set; get; }

}

