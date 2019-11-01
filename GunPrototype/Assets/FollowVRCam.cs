using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowVRCam : MonoBehaviour
{
    public Transform VRCamera;
    float xOffset;

    private void Start()
    {
        xOffset = transform.localPosition.x - VRCamera.localPosition.x;
    }

    private void FixedUpdate()
    {
        transform.localPosition = new Vector3(VRCamera.localPosition.x - xOffset, transform.localPosition.y, VRCamera.localPosition.z);
    }
}
