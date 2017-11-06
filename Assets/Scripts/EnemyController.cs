using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	//public permette modifiche al programmatore dall ide unity
	public float speed = 20; // variabile per applicare velocità alla fisica
	private Rigidbody rb;

	// Use this for initialization call one a time
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void FixedUpdate () {

		float movementHorizontal = Random.Range(-1.0f,1.0f); //da -1 a 1  ( da tastiera -1 sinistra, 1 destra)
		float movementVertical = Random.Range(-1.0f,1.0f);     //da -1 a 1 ( da tastiera : -1 giù , 1 su )

		//3 dimensioni quindi vector 3
		Vector3 movement = new Vector3 (movementHorizontal, 0.0f, movementVertical); //0.0f per non far fare cast al compilatore

		rb.AddForce (movement * speed);        //prodotto scalare movement * speed
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

}
