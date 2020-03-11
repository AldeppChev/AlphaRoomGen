using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sendCol : MonoBehaviour
{
    public int Direction;
    public bool isNorth = false;
    public bool isEast = false;
    public bool isSouth = false;
    public bool isWest = false;

    public void Collider2D(GameObject other)
    {
        if (Direction == 1 && other.CompareTag("SpawnPoint"))
        {
            isNorth = true;
        }

        if (Direction == 2 && other.CompareTag("SpawnPoint"))
        {
            isEast = true;
        }

        if (Direction == 3 && other.CompareTag("SpawnPoint"))
        {
            isSouth = true;
        }

        if (Direction == 4 && other.CompareTag("SpawnPoint"))
        {
            isWest = true;
        }

        if (other.CompareTag("Che"))
        {
            Destroy(other.transform.parent);
        }
            
    }
}
