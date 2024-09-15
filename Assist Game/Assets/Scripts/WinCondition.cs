using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private List<Slot> slots = new List<Slot>();
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject levelScene; // Add this field to reference the level scene GameObject

    private void Update()
    {
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {

        foreach (Slot slot in slots)
        {
            if (slot.Check==1)
            {
                Debug.Log("next lvl");
            }
        }

       
    }
}
