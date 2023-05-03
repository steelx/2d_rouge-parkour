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

    public void SetMovementAnimation(bool isWalking)
    {
        animator.SetBool("walking", isWalking);
    }

    public void AnimateAgent(float velocity)
    {
        SetMovementAnimation(velocity > 0);
    }
}
