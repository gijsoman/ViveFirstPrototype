using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(CapsuleCollider))]
public class EnemyMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();        
    }

    private void Move()
    {
        animator.SetFloat("Forward", Input.GetAxis("Vertical"));
    }
}
