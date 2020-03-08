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
    private RoomTemplate template;
    private Random rnd = new Random();
    private bool is_spawned = false;

    private void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
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
        if (other.CompareTag("SpawnPoint") && other.GetComponent<Spawning>().is_spawned)
        {
            if (other.GetComponent<Spawning>().is_spawned == false && is_spawned == false)
            {
                Instantiate(template.closedRoom[0], transform.position, Quaternion.identity);
                is_spawned = true;
            }
            Destroy(gameObject);
        }
    }
}
