using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ThirdPersonCamera))]
public class ThirdPersonCameraMouseControl : MonoBehaviour
{
    [SerializeField] private bool invertAxis = false;
    [SerializeField] private bool hideCursor = false;
    [SerializeField] private float mouseSensitivity = 10f;

    private ThirdPersonCamera thirdPersonCamera;

    void Start()
    {
        if (hideCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        thirdPersonCamera = GetComponent<ThirdPersonCamera>();
        thirdPersonCamera.SameRotationAsCharacter = false;
    }

    void Update()
    {
        if (!invertAxis)
        {
            thirdPersonCamera.Yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            thirdPersonCamera.Pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        }
        else
        {
            thirdPersonCamera.Yaw -= Input.GetAxis("Mouse X") * mouseSensitivity;
            thirdPersonCamera.Pitch += Input.GetAxis("Mouse Y") * mouseSensitivity;
        }


    }
}
