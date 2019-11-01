using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
//[RequireComponent(typeof(Rigidbody))]
public class Wieldable : MonoBehaviour
{
    public Material mat;

    [EnumFlags]
    [Tooltip("The flags used to attach this object to the hand.")]
    public Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.ParentToHand | Hand.AttachmentFlags.DetachFromOtherHand | Hand.AttachmentFlags.TurnOnKinematic;

    [Tooltip("The local point which acts as a positional and rotational offset to use while held")]
    public Transform attachmentOffset;

    [Tooltip("When detaching the object, should it return to its original parent?")]
    public bool restoreOriginalParent = false;

    protected bool attached = false;
    protected float attachTime;
    protected Vector3 attachPosition;
    protected Quaternion attachRotation;
    protected Transform attachEaseInTransform;

    [HideInInspector]
    public Interactable interactable;

    protected virtual void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    protected virtual void OnHandHoverBegin(Hand hand)
    {
        mat.color = Color.black;
    }

    protected virtual void OnHandHoverEnd(Hand hand)
    {
        mat.color = Color.yellow;
    }

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType == GrabTypes.Grip)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
    }
}
