using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public enum ItemType { Gun, Pepper };

[RequireComponent(typeof(Interactable), typeof(Rigidbody))]
public class Wieldable : MonoBehaviour
{
    public Material mat;
    public ItemType Type;

    public bool allowedToholster;

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

    public delegate void WieldEvent();
    public WieldEvent OnDetachObject;
    public WieldEvent OnAttachObject;

    [HideInInspector]
    public Interactable interactable;

    private Rigidbody rb;

    protected virtual void Awake()
    {
        interactable = GetComponent<Interactable>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void OnHandHoverBegin(Hand hand)
    {
        if(mat != null)        
            mat.color = Color.black;
    }

    protected virtual void OnHandHoverEnd(Hand hand)
    {
        if(mat != null)
            mat.color = Color.yellow;
    }

    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (startingGrabType == GrabTypes.Grip)
        {
            OnAttachObject.Invoke();
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
            rb.isKinematic = true;
            attached = true;         
        }
    }

    protected virtual void HandAttachedUpdate(Hand hand)
    {
        GrabTypes endingGrabType = hand.GetGrabEnding();

        if (endingGrabType == GrabTypes.Grip)
        {
            OnDetachObject?.Invoke();
            hand.DetachObject(gameObject);
            rb.isKinematic = false;
            attached = false;
        }
    }

    private void OnDestroy()
    {
        OnDetachObject = null;
        OnAttachObject = null;
    }
}
