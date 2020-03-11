using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class Spawning : MonoBehaviour
{
    // Start is called before the first frame update
    public int PossibleDirection;
    public int RoomId;
    public List<GameObject> Freres;
    public int RoomPosX;
    public int RoomPosY;
    private RoomTemplate template;
    private Random rnd = new Random();
    private bool is_spawned = false;

    private void Awake()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.2f);
    }

    private void Spawn()
    {
        if (is_spawned == false)
        {
            if (PossibleDirection == 3)
            {
                //Top
                if (template.NeedMoreRooms)
                {
                    int a = rnd.Next(template.multtopRooms.Length - 1);
                    Instantiate(template.multtopRooms[a], transform.position, template.multtopRooms[a].transform.rotation);
                }
                else
                {
                    Instantiate(template.justTop[0], transform.position, template.justTop[0].transform.rotation);
                }
            }
            if (PossibleDirection == 4)
            {
                //Right
                if (template.NeedMoreRooms)
                {
                    int a = rnd.Next(template.multrightRooms.Length - 1);
                    Instantiate(template.multrightRooms[a], transform.position, template.multrightRooms[a].transform.rotation);
                }
                else
                {
                    Instantiate(template.justRight[0], transform.position, template.justRight[0].transform.rotation);
                }
            }

            if (PossibleDirection == 1)
            {
                //Bottom
                if (template.NeedMoreRooms)
                {
                    int a = rnd.Next(template.multbottomRooms.Length - 1);
                    Instantiate(template.multbottomRooms[a], transform.position, template.multbottomRooms[a].transform.rotation);
                }
                else
                {
                    Instantiate(template.justBottom[0], transform.position, template.justBottom[0].transform.rotation);
                }
            }

            if (PossibleDirection == 2)
            {
                //Left
                if (template.NeedMoreRooms)
                {
                    int a = rnd.Next(template.multleftRooms.Length - 1);
                    Instantiate(template.multleftRooms[a], transform.position, template.multleftRooms[a].transform.rotation);
                }
                else
                {
                    Instantiate(template.justLeft[0], transform.position, template.justLeft[0].transform.rotation);
                }
            }
            is_spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       /* if (PossibleDirection == 3 && other.GetComponent<Spawning>().RoomId != 11000 && other.GetComponent<Spawning>().RoomId != 11030 && other.GetComponent<Spawning>().RoomId != 11034 && other.GetComponent<Spawning>().RoomId != 11230 && other.GetComponent<Spawning>().RoomId != 11004 && other.GetComponent<Spawning>().RoomId != 11204 && other.GetComponent<Spawning>().RoomId != 11200 && other.GetComponent<Spawning>().RoomId != 11234)
         {
             //Bot //11___
             Instantiate(template.BoucheBot[0], new Vector2(transform.position.x, transform.position.y-11f), Quaternion.identity);
         }
         if (PossibleDirection == 4 && other.GetComponent<Spawning>().RoomId != 10234 && other.GetComponent<Spawning>().RoomId != 10230 && other.GetComponent<Spawning>().RoomId != 10204 && other.GetComponent<Spawning>().RoomId != 10200 && other.GetComponent<Spawning>().RoomId != 11200 && other.GetComponent<Spawning>().RoomId != 11204 && other.GetComponent<Spawning>().RoomId != 11230 && other.GetComponent<Spawning>().RoomId != 11234)
         {
             //Left //1_2__
             Instantiate(template.BoucheLeft[0], new Vector2(transform.position.x-11f, transform.position.y), Quaternion.identity);
         }
         if (PossibleDirection == 1 && other.GetComponent<Spawning>().RoomId != 10030 && other.GetComponent<Spawning>().RoomId != 10230 && other.GetComponent<Spawning>().RoomId != 10234 && other.GetComponent<Spawning>().RoomId != 10034 && other.GetComponent<Spawning>().RoomId != 11230 && other.GetComponent<Spawning>().RoomId != 11034 && other.GetComponent<Spawning>().RoomId != 11030 && other.GetComponent<Spawning>().RoomId != 11234)
         {
             //Top //1__3_
             Instantiate(template.BoucheTop[0], new Vector2(transform.position.x, transform.position.y+11f), Quaternion.identity);
         }
         if (PossibleDirection == 2 && other.GetComponent<Spawning>().RoomId != 10234 && other.GetComponent<Spawning>().RoomId != 10004 && other.GetComponent<Spawning>().RoomId != 10034 && other.GetComponent<Spawning>().RoomId != 10204 && other.GetComponent<Spawning>().RoomId != 11034 && other.GetComponent<Spawning>().RoomId != 11004 && other.GetComponent<Spawning>().RoomId != 11204 && other.GetComponent<Spawning>().RoomId != 11234)
         {
             //Right //1___4
             Instantiate(template.BoucheRight[0], new Vector2(transform.position.x+11f, transform.position.y), Quaternion.identity);
         }*/
         
        if (PossibleDirection == 0 && other.CompareTag("SpawnPoint") && other.GetComponent<Spawning>().is_spawned )
        {
            if (other.GetComponent<Spawning>().PossibleDirection == 1)
            {
                RoomPosX = other.GetComponent<Spawning>().RoomPosX;
                RoomPosY = other.GetComponent<Spawning>().RoomPosY + 1;
                for (int i = 0; i < Freres.Count; i++)
                {
                    Freres[i].GetComponent<Spawning>().RoomPosX = RoomPosX;
                    Freres[i].GetComponent<Spawning>().RoomPosY = RoomPosY;
                }
            }
            if (other.GetComponent<Spawning>().PossibleDirection == 2)
            {
                RoomPosY = other.GetComponent<Spawning>().RoomPosY;
                RoomPosX = other.GetComponent<Spawning>().RoomPosX + 1;
                for (int i = 0; i < Freres.Count; i++)
                {
                    Freres[i].GetComponent<Spawning>().RoomPosX = RoomPosX;
                    Freres[i].GetComponent<Spawning>().RoomPosY = RoomPosY;
                }
            }
            if (other.GetComponent<Spawning>().PossibleDirection == 3)
            {
                RoomPosX = other.GetComponent<Spawning>().RoomPosX;
                RoomPosY = other.GetComponent<Spawning>().RoomPosY - 1;
                for (int i = 0; i < Freres.Count; i++)
                {
                    Freres[i].GetComponent<Spawning>().RoomPosX = RoomPosX;
                    Freres[i].GetComponent<Spawning>().RoomPosY = RoomPosY;
                }
            }
            if (other.GetComponent<Spawning>().PossibleDirection == 4)
            {
                RoomPosY = other.GetComponent<Spawning>().RoomPosY;
                RoomPosX = other.GetComponent<Spawning>().RoomPosX - 1;
                for (int i = 0; i < Freres.Count; i++)
                {
                    Freres[i].GetComponent<Spawning>().RoomPosX = RoomPosX;
                    Freres[i].GetComponent<Spawning>().RoomPosY = RoomPosY;
                }
            }
            Destroy(other.gameObject);
        }
        if (PossibleDirection != 0 && other.CompareTag("SpawnPoint") && other.GetComponent<Spawning>().is_spawned)
        { 
            Destroy(gameObject);
        
             /*if (other.GetComponent<Spawning>().is_spawned == false && is_spawned == false)
             {
                 Instantiate(template.closedRoom[0], transform.position, Quaternion.identity);
                 is_spawned = true;
             }*/
        }
    }
}

