using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AltraPalla : MonoBehaviour {

	//public permette modifiche al programmatore dall ide unity
	public float speed = 20;
	private float startHealthWidth = 0.6f;
	//variabile per applicare velocità alla fisica
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
	void Update () {
		
	}

	void OnCollisionEnter(Collision player){

		if (player.gameObject.CompareTag ("Giocatore")) {
			if (player.gameObject.GetComponent<PlayerController> ().health == 0) {
				player.gameObject.SetActive (false);
			} else {
				PlayerController pl = player.gameObject.GetComponent<PlayerController> ();
				pl.health--;
				startHealthWidth = startHealthWidth - 0.2f;
				pl.img.uvRect = new Rect(1f,1f,startHealthWidth,1f);
				pl.img.SetNativeSize ();
			}
		}
	}
}
