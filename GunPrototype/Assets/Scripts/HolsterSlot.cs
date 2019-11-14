using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HolsterSlot : MonoBehaviour
{
    public ItemType Type;
    public GameObject HolsteredItem;

    private SphereCollider holsterRange;

    private void Awake()
    {
        holsterRange = GetComponent<SphereCollider>();
    }

    public void HolsterItem(GameObject _itemToHolster)
    {
        //holster the item if it is released within the holster range.
    }

    private void UnHolsterItem(HolsterItem _itemToUnHolster)
    {
        //unholster the item if it is grabbed.
    }

    private void OnTriggerEnter(Collider other)
    {
        HolsterItem holsterItem;

        if (other.GetComponent<HolsterItem>() != null)
        {
            holsterItem = other.GetComponent<HolsterItem>();
            holsterItem.inRangeOfHolsterSlot = true;
            holsterItem.holsterSlotInRangeOf = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HolsterItem holsterItem;

        if (other.GetComponent<HolsterItem>() != null)
        {
            holsterItem = other.GetComponent<HolsterItem>();
            holsterItem.inRangeOfHolsterSlot = false;
            holsterItem.holsterSlotInRangeOf = null;
        }
    }
}
