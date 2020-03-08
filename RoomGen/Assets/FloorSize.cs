using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSize : MonoBehaviour
{
    private RoomTemplate template;

    private void Start()
    {
        template = GameObject.FindWithTag("Rooms").GetComponent<RoomTemplate>();
        template.RoomList.Add(this.gameObject);
    }
}
