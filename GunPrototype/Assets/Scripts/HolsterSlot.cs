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
        if (HolsteredItem == null)
        {
            HolsteredItem = _itemToHolster;
            _itemToHolster.transform.SetParent(transform);
            _itemToHolster.transform.localPosition = Vector3.zero;
        }
    }

    public void UnHolsterItem(GameObject _itemToUnHolster)
    {
        _itemToUnHolster.transform.SetParent(null);
        HolsteredItem = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        HolsterItem holsterItem;

        if (other.GetComponent<HolsterItem>() != null)
        {
            holsterItem = other.GetComponent<HolsterItem>();
            holsterItem.ReadyItemToHolster();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        HolsterItem holsterItem;

        if (other.GetComponent<HolsterItem>() != null)
        {
            holsterItem = other.GetComponent<HolsterItem>();
            holsterItem.ReadyItemToUnHolster();
        }
    }
}
