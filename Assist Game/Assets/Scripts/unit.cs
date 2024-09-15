using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    private int slots;  // Stores the number of slots for this unit
   
    // Returns the current position of the unit
    public Vector3 GetPosition()
    {
        return transform.position;
    }

    // Sets the position of the unit to the provided Vector3 value
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

   

    
}


