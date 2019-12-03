using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable))]
public class Shootable : MonoBehaviour
{
    public SteamVR_Action_Boolean Shoot;
    public Transform EndOfBarrel;
    public GameObject BulletPrefab;
    public AudioClip ShootSound;

    private void HandAttachedUpdate(Hand hand)
    {
        //Debug.Log();
        if (Shoot != null && Shoot.GetStateDown(hand.handType))
        {
            Vector3 forward = EndOfBarrel.transform.TransformDirection(Vector3.right) * 10;
            Instantiate(BulletPrefab, EndOfBarrel.position, Quaternion.LookRotation(forward));
        }
    }


}
