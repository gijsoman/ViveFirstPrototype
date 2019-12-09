using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private bool isWalking = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Turning();
        Walking();
        Move();
        
    }

    private void Turning()
    {
        animator.SetFloat("Turn", Input.GetAxis("Horizontal"));
    }

    private void Walking()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isWalking = !isWalking;
            animator.SetBool("Walk", isWalking);
        }
    }

    private void Move()
    {
        animator.SetFloat("Forward", Input.GetAxis("Vertical"));
    }
}
