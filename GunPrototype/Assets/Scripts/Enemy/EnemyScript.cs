using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    bool Alive = true;
    public delegate void EnemyEvent();
    public EnemyEvent IDied;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet_45mm_Bullet(Clone)")
        {
            Debug.Log("Me Ded");
            Alive = false;
            IDied?.Invoke();
        }
    }

    private void OnDestroy()
    {        
        IDied = null;
    }
}
