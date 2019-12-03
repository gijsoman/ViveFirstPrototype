using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class Shootable : MonoBehaviour
{

    public SteamVR_Action_Boolean Shoot;

    private void HandAttachedUpdate(Hand hand)
    {
        //Debug.Log();
        if (Shoot != null && Shoot.GetStateDown(hand.handType))
        {
            Debug.Log("BAM");
        }
    }
}
