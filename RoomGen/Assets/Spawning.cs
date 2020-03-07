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
                int a = rnd.Next(template.topRooms.Length - 1);
                Instantiate(template.topRooms[a], transform.position, template.topRooms[a].transform.rotation);
            }

            if (PossibleDirection == 4)
            {
                //Right
                int a = rnd.Next(template.rightRooms.Length - 1);
                Instantiate(template.rightRooms[a], transform.position, template.rightRooms[a].transform.rotation);
            }

            if (PossibleDirection == 1)
            {
                //Bottom
                int a = rnd.Next(template.bottomRooms.Length - 1);
                Instantiate(template.bottomRooms[a], transform.position, template.bottomRooms[a].transform.rotation);
            }

            if (PossibleDirection == 2)
            {
                //Left
                int a = rnd.Next(template.leftRooms.Length - 1);
                Instantiate(template.leftRooms[a], transform.position, template.leftRooms[a].transform.rotation);
            }

            is_spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<Spawning>().is_spawned)
        {
            Destroy(gameObject);
        }
    }
}
