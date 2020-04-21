using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TreadmillAnimationModifier : MonoBehaviour
{
    private Animator animator;
    enum MovementType
    {
        Idle,
        Walking,
        Running
    }
    private MovementType LastMovement;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementType newMovement;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
            if(Input.GetKey(KeyCode.LeftShift)) newMovement = MovementType.Walking;
            else newMovement = MovementType.Running;
        }
        else
            newMovement = MovementType.Idle;

        if (newMovement != LastMovement)
        {
            
            switch (newMovement)
            {
                case MovementType.Idle: animator.enabled = false; break;
                case MovementType.Walking: animator.enabled = true; animator.speed *= 0.661538f; break;
                case MovementType.Running: animator.enabled = true; animator.speed *= 1.511628f; break;
            }
            LastMovement = newMovement;
        }
    }
}
