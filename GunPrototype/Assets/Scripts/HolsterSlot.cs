﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HolsterSlot : MonoBehaviour
{
    public ItemType HolsterItemType;
    public GameObject HolsteredItem;

    private Wieldable currentWieldableItemWithinRange;

    public void HolsterItem(Vector3 _LocalHolsterPosition, Quaternion _LocalHolsterRotation)
    {
        if (HolsteredItem == null)
        {
            HolsteredItem = currentWieldableItemWithinRange.gameObject;
            currentWieldableItemWithinRange.rb.isKinematic = true;
            HolsteredItem.transform.SetParent(transform);

            //determine the position and rotation of the item when holstered.
            HolsteredItem.transform.localPosition = Vector3.zero;
            HolsteredItem.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Wieldable>() != null)
        {
            currentWieldableItemWithinRange = other.GetComponent<Wieldable>();
            currentWieldableItemWithinRange.OnDetachObject += HolsterItem;
            currentWieldableItemWithinRange.mat.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (currentWieldableItemWithinRange != null)
        {
            currentWieldableItemWithinRange.GetComponent<Wieldable>().mat.color = Color.red;
            currentWieldableItemWithinRange.OnDetachObject -= HolsterItem;
        }

        HolsteredItem = null;
    }
    
}
