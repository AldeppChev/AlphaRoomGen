using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheck : MonoBehaviour
{
    public int Direction;
    public int Id;

    [SerializeField] private GameObject[] Freres; //N E S W
    [SerializeField] private GameObject[] roomTemplates;
    
    private void Start()
    {
        Invoke("Spawnatin", 0.2f);
    }
    
    public void Spawnatin()
    {
        for (int i = 0; i < Freres.Length; i++)
        {
            if (Direction == 1 && Freres[i].GetComponent<sendCol>().isNorth)
            {
                Id += 1000;
            }
            if (Direction == 2 && Freres[i].GetComponent<sendCol>().isEast)
            {
                Id += 100;
            }
            if (Direction == 3 && Freres[i].GetComponent<sendCol>().isSouth)
            {
                Id += 10;
            }
            if (Direction == 4 && Freres[i].GetComponent<sendCol>().isWest)
            {
                Id += 1;
            }
        }

        if (Id == 10000)
        {
            Destroy(this.gameObject);
        }
    }
}
