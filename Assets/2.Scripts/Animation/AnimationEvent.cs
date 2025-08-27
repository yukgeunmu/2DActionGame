using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public AttackTrigger Trigger;


    public void AttackTrue()
    {
        Trigger.gameObject.SetActive(true);
    }

    public void AttackFalse() 
    {
        Trigger .gameObject.SetActive(false);
    }
}
