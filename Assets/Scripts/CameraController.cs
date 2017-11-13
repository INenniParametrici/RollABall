using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //far comunicare game Object tra loro 
    public GameObject player;

    //differenza tra posizioni per controllare la camera
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Giocatore");
        offset = transform.position - player.transform.position;                 //(sottointende il this )
	}
	
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
