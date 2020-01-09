using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

[RequireComponent(typeof(Interactable), typeof(AudioSource))]
public class Shootable : MonoBehaviour
{
    public SteamVR_Action_Boolean Shoot;
    public Transform EndOfBarrel;
    public AudioClip ShootSound;
    public GameObject muzzleFlashPrefab;

    private AudioSource audiouSource;

    private void Start()
    {
        audiouSource = GetComponent<AudioSource>();
    }

    private void HandAttachedUpdate(Hand hand)
    {
        
        if (Shoot != null && Shoot.GetStateDown(hand.handType))
        {
            Vector3 forward = EndOfBarrel.transform.TransformDirection(Vector3.right) * 10;
            ObjectPooler.Instance.SpawnFromPool("Bullet", EndOfBarrel.position, Quaternion.LookRotation(forward));
            GameObject tempFlash;
            tempFlash = Instantiate(muzzleFlashPrefab, EndOfBarrel.position, Quaternion.LookRotation(forward));
            audiouSource.PlayOneShot(ShootSound);
            Destroy(tempFlash, 0.5f);
        }
    }


}
