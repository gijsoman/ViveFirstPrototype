using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShootingDirection : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {
        Vector3 forward = transform.TransformDirection(Vector3.right) * 10;
        Debug.DrawRay(transform.position, forward);
    }
}
