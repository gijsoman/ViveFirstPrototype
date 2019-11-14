using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class HolsterSlot : MonoBehaviour
{
    public ItemType HolsterItemType;
    public GameObject HolsteredItem;

    public void HolsterItem(GameObject _itemToHolster)
    {
        if (HolsteredItem == null)
        {
            HolsteredItem = _itemToHolster;
            _itemToHolster.transform.SetParent(transform);
            _itemToHolster.transform.localPosition = Vector3.zero;
        }
    }

    public void UnHolsterItem(GameObject _itemToUnHolster)
    {
        if (HolsteredItem != null)
        {
            _itemToUnHolster.transform.SetParent(null);
            HolsteredItem = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
