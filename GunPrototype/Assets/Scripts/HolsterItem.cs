using UnityEngine;

public enum ItemType { Gun, Pepper };

[RequireComponent(typeof(Wieldable))]
public class HolsterItem : MonoBehaviour
{
    public ItemType Type;
    public bool inRangeOfHolsterSlot;
    public HolsterSlot holsterSlot;

    private bool inRageOfHolster = false;
    private bool isHolstered = true;
    private Wieldable wieldable;

    private void Awake()
    {
        wieldable = GetComponent<Wieldable>();
        wieldable.OnDetachObject += CheckAndHolsterItem;
        wieldable.OnAttachObject += CheckAndHolsterItem;
    }

    private void CheckAndHolsterItem()
    {
        if (inRangeOfHolsterSlot && Type == holsterSlot.Type && !isHolstered)
        {
            holsterSlot.HolsterItem(gameObject);
            isHolstered = true;
        }
        else if (isHolstered)
        {
            isHolstered = false;
            holsterSlot.UnHolsterItem(gameObject);
        }
    }

    public void ReadyItemToHolster()
    {

    }

    public void ReadyItemToUnHolster()
    {

    }

    //if the item is released, we are in range of the holster and we are of the itemtype is correct we can holster.
}
