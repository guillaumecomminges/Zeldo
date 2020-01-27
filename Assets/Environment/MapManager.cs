﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    [SerializeField]
    Transform Spawn = null; 
    [SerializeField]
    Transform playerPosition = null;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Rigidbody2D>()) {
			playerPosition.transform.position = Spawn.transform.position;
		}
    }
}