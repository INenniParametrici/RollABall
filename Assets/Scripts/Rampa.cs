using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rampa : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionDetected(PlayerController other){
		if (other.gameObject.CompareTag ("Giocatore"))
			other.speed = 20;
	}
}
