using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(CharacterController))]
public class VRWalking : MonoBehaviour
{
    public float Sensitivity = 0.1f;
    public float MaxSpeed =  1.0f;

    public SteamVR_Action_Boolean MovePress = null;
    public SteamVR_Action_Vector2 MoveValue = null;

    private float speed = 0.0f;

    private CharacterController characterController;
    private Transform cameraRig = null;
    private Transform head = null;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        cameraRig = SteamVR_Render.Top().origin;
        head = SteamVR_Render.Top().head;
    }

    private void Update()
    {
        HandleHead();
        HandleHeight();
        CalculateMovement();        
    }

    private void HandleHead()
    {
        //store current
        Vector3 oldPosition = cameraRig.position;
        Quaternion oldRotation = cameraRig.rotation;

        //rotation
        transform.eulerAngles = new Vector3(0f, head.rotation.eulerAngles.y, 0f);


        //restore 
        cameraRig.position = oldPosition;
        cameraRig.rotation = oldRotation;
    }

    private void CalculateMovement()
    {
        //figure out movement orientation
        Vector3 orientationEuler = new Vector3(0, transform.eulerAngles.y, 0);
        Quaternion orientation = Quaternion.Euler(orientationEuler);
        Vector3 movement = Vector3.zero;

        //if not moving
        if (MovePress.GetStateUp(SteamVR_Input_Sources.Any))
        {
            speed = 0f;
        }

        //if button pressed
        if (MovePress.state)
        {
            //add clamp
            speed += MoveValue.axis.y * Sensitivity;
            speed = Mathf.Clamp(speed, -MaxSpeed, MaxSpeed);

            //orientation
            movement += orientation * (speed * Vector3.forward) * Time.deltaTime;
        }

        //apply
        characterController.Move(movement);
    }

    private void HandleHeight()
    {
        //get the head in local space
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        characterController.height = headHeight;
        
        //cut in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        //Move capsule in local space
        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;

        //rotate
        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;

        //apply
        characterController.center = newCenter;
    }
}
