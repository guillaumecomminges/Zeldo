using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    [SerializeField]
    Collider2D colliderHouseIn;
    [SerializeField]
    Transform HouseSpawn;
    [SerializeField]
    Transform playerPosition;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<Rigidbody2D>()) {
			playerPosition.transform.position = HouseSpawn.transform.position;
		}
    }
}