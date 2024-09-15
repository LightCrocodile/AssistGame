using UnityEngine;
using UnityEngine.EventSystems;

public class Box : MonoBehaviour, IDropHandler
{
    private Item currentItem = null;
    public Slot parentSlot; // Assigned manually or automatically

    private void Awake()
    {
        if (parentSlot == null)
        {
            parentSlot = GetComponentInParent<Slot>(); // Automatically find parent Slot
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Item item = eventData.pointerDrag.GetComponent<Item>();

            if (item != null)
            {
                RectTransform itemRect = eventData.pointerDrag.GetComponent<RectTransform>();
                RectTransform boxRect = GetComponent<RectTransform>();

                itemRect.position = boxRect.position;
                itemRect.SetParent(transform);
                currentItem = item;

                item.SetValidDrop(true);

                // Notify the parent slot to check the state after the item is dropped
                if (parentSlot != null)
                {
                    parentSlot.CheckAndClearIfMatching();
                }
                else
                {
                    Debug.LogWarning("Parent Slot is not assigned for box: " + gameObject.name);
                }
            }
        }
    }

    public bool IsFilled()
    {
        return currentItem != null;
    }

    public int GetItemID()
    {
        if (currentItem != null)
        {
            return currentItem.ItemId;
        }
        return -1; // Return -1 if no item is in the box
    }

    public void ClearItem()
    {
        if (currentItem != null)
        {
            Destroy(currentItem.gameObject);
            currentItem = null;
        }
    }
}
