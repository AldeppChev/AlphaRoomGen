using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] BoucheTop;
    public GameObject[] BoucheRight;
    public GameObject[] BoucheBot;
    public GameObject[] BoucheLeft;
    
    public GameObject[] multtopRooms;
    public GameObject[] multrightRooms;
    public GameObject[] multbottomRooms;
    public GameObject[] multleftRooms;
    
    public GameObject[] justTop;
    public GameObject[] justRight;
    public GameObject[] justBottom;
    public GameObject[] justLeft;

    public GameObject Spawnard;
    public GameObject[] closedRoom;
    public List<GameObject> RoomList;
    public GameObject boss;
    public GameObject spawn;
    public int minrange;
    public int maxrange;
    private bool is_spawned_boss;
    public float WaitTime;
    public bool NeedMoreRooms = true;
    private Random rnd;

    public int Rando()
    {
        int rand = rnd.Next(minrange, maxrange);
        return rand;
    }

    private void Start()
    {
        Instantiate(spawn, RoomList[0].transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (WaitTime <= 0 && is_spawned_boss == false)
        {
            for (int i = 0; i < RoomList.Count; i++)
            {
                if (i == RoomList.Count - 1)
                {
                    Instantiate(boss, RoomList[i].transform.position, Quaternion.identity);
                    is_spawned_boss = true;
                    foreach (var boomix in RoomList)
                    {
                        foreach (var boomys in RoomList)
                        {
                            if (boomix != boomys)
                            {
                                if (boomix.transform.position == boomys.transform.position)
                                {
                                    Destroy(boomys);
                                    // Creer un gameobject checker, compose de 5 nodes,au milieu et 4 autour, et vont verfiier avec le collider, qu'elles entrent en collision
                                    // et devront renvoyer la valeur de "possible direction" et enverront a la node principale en fct des valeur donc des sorties spawn bonne salle.
                                    // peut etre nessecite de creer une liste de toutes les templates permettant d'aller chercher la bonne salle avec son nom.
                                    Instantiate(Spawnard, boomix.transform.position, Quaternion.identity);
                                    Destroy(boomix);
                                }
                            }
                        }
                    }
                }
            } 
        }
        else
        {
            WaitTime -= Time.deltaTime;
        }

        if (RoomList.Count < minrange)
        {
            NeedMoreRooms = true;
        }

        if (RoomList.Count > maxrange)
        {
            NeedMoreRooms = false;
        }
        /*
        foreach (var boomix in RoomList)
        {
            foreach (var boomys in RoomList)
            {
                if (boomix != boomys)
                {
                    if (boomix.transform.position == boomys.transform.position)
                    {
                        Destroy(boomys);
                    }
                }
            }
        }*/
    }
}
