using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = System.Random;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] rightRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    
    public GameObject[] multtopRooms;
    public GameObject[] multrightRooms;
    public GameObject[] multbottomRooms;
    public GameObject[] multleftRooms;
    
    public GameObject[] justTop;
    public GameObject[] justRight;
    public GameObject[] justBottom;
    public GameObject[] justLeft;

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
    }
}
