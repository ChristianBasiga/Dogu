using UnityEngine;


namespace Dogu
{
    //Used to be interface but made abstract class so it can inherit MonoBehaviour so it can be public
    //Making this to avoid having to check if null after trying to get Animator on object
    //Better to prevent error then check for error and let it happen
    public abstract class AnimatableObject : MonoBehaviour
    {
          public abstract State state { set; get; }    
    }

  
}