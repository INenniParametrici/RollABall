﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //public permette modifiche al programmatore dall ide unity
    public float speed = 0;
	public float jumpIntensity = 0;
	public int health = 3;
	public  RawImage img;
	public bool isOnGround = true;
    //variabile per applicare velocità alla fisica
    private Rigidbody rb;



	// Use this for initialization call one a time
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void FixedUpdate () {
		float jump = Input.GetAxis ("Jump");

		if (isOnGround) {
			Vector3 jumpVector = new Vector3 (0.0f, jump, 0.0f);
			rb.AddForce (jumpVector * jumpIntensity, ForceMode.Impulse);
		}

        float movementHorizontal = Input.GetAxis("Horizontal"); //da -1 a 1  ( da tastiera -1 sinistra, 1 destra)
        float movementVertical = Input.GetAxis("Vertical");     //da -1 a 1 ( da tastiera : -1 giù , 1 su )

        //3 dimensioni quindi vector 3
        Vector3 movement = new Vector3(movementHorizontal, 0.0f , movementVertical); //0.0f per non far fare cast al compilatore

        rb.AddForce(movement*speed);        //prodotto scalare movement * speed
		}
		
		public void OnCollisionEnter(Collision other){
			if (other.gameObject.CompareTag ("Ground"))
					isOnGround = true;
		}

		public void OnCollisionExit(Collision other){
			if (other.gameObject.CompareTag ("Ground"))
				isOnGround = false;
		}

}
