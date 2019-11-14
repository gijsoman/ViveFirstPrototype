using UnityEngine;

public enum ItemType { Gun, Pepper };

[RequireComponent(typeof(Wieldable))]
public class HolsterItem : MonoBehaviour
{
    public ItemType Type;
    public bool inRangeOfHolsterSlot;
    public HolsterSlot holsterSlotInRangeOf;

    private bool inRageOfHolster = false;
    private bool isHolstered = true;
    private Wieldable wieldable;

    private void Awake()
    {
        wieldable = GetComponent<Wieldable>();
        wieldable.OnDetachObject += CheckAndHolsterItem;
    }

    private void CheckAndHolsterItem()
    {
        if (inRangeOfHolsterSlot && Type == holsterSlotInRangeOf.Type)
        {
            holsterSlotInRangeOf.HolsterItem(gameObject);
        }        
    }

    //if the item is released, we are in range of the holster and we are of the itemtype is correct we can holster.
}
