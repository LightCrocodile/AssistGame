using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class Slot : MonoBehaviour
{
    public event Action Levelend;
    [SerializeField] private List<Box> boxes = new List<Box>();
    public int Check = 0;

    public bool AreAllBoxesMatching()
    {
        if (boxes.Count == 0) return false;

        int firstItemID = -1;
        int matchingItems = 0;

        foreach (Box box in boxes)
        {
            if (!box.IsFilled())
                return false;

            int currentItemID = box.GetItemID();

            if (firstItemID == -1)
            {
                firstItemID = currentItemID;
            }

            if (currentItemID == firstItemID)
            {
                matchingItems++;
            }
        }

        return matchingItems == boxes.Count && matchingItems == 3;
    }

    public void ClearSlot()
    {
        foreach (Box box in boxes)
        {
            box.ClearItem();
        }
    }

    public void CheckAndClearIfMatching()
    {
        
        if (AreAllBoxesMatching())
        {
            ClearSlot();
           
            Debug.Log("All matching items in slot cleared.");

            
        }
    }

    public int GetFilledBoxesCount()
    {
        int count = 0;

        foreach (Box box in boxes)
        {
            if (box.IsFilled())
            {
                count++;
            }
        }

        return count;
    }
}
