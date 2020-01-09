using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public delegate void PlayerEvent();
    public PlayerEvent IDied;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IDied?.Invoke();
        }
    }

    private void OnDestroy()
    {
        IDied = null;
    }
}
