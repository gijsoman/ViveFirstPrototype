using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class Shootable : MonoBehaviour
{

    public SteamVR_Action_Boolean Shoot;

    private Interactable interactable;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        if (interactable.attachedToHand)
        {
            SteamVR_Input_Sources hand = interactable.attachedToHand.handType;

            Debug.Log(Shoot.GetState(hand));
        }
    }
}
