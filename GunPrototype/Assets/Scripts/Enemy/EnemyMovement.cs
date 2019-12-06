using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    private Animator animator;

    public float inputX;
    public float inputY;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        inputY = Input.GetAxis("Vertical");
        inputX = Input.GetAxis("Horizontal");

        animator.SetFloat("InputY", inputY);
    }
}
