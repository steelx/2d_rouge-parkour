using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AgentAnimations : MonoBehaviour
{
    protected Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void SetMovementAnimation(bool isWalking)
    {
        animator.SetBool("walking", isWalking);
    }

    /*
     * AnimateAgent called from AgentInputController's OnVelocityChange event
     */
    public void AnimateAgent(float velocity)
    {
        SetMovementAnimation(velocity > 0);
    }
}
