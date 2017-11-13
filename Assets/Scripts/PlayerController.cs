﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //public permette modifiche al programmatore dall ide unity
    public float speed = 1;					 //velocita con cui si muove il player
	public float jumpIntensity = 0; 		//intensita salto
    private bool isOnGround = true; 		//controllo se sta attaccato al terreno
    public int health = 3; 					//vite giocatore
	private GameController gameController;	//variabile che utilizzo per verifiche incrociate coi dati di gioco 
    private Rigidbody rb; 					//variabile che definisce le proprietà di corpo rigido 
	public Renderer rend;

	// Use this for initialization call one a time
	void Start ()
    {
		rend = GetComponent<Renderer> ();			  //occorre recuperare il Rendered per operare sull'aspetto grafico
		rend.material.SetColor ("_Color",Color.blue); //Si usa color perchè RGBA è compreso tra 0 e 1
		rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();


    }

    // Update is called once per frame
    void FixedUpdate () {
		float jump = Input.GetAxis ("Jump"); // jump cos'è?

		if (isOnGround) {
			Vector3 jumpVector = new Vector3 (0.0f, jump, 0.0f);
			rb.AddForce (jumpVector * jumpIntensity, ForceMode.Impulse);
		}

        float movementHorizontal = Input.GetAxis("Horizontal"); //da -1 a 1  ( da tastiera -1 sinistra, 1 destra)
        float movementVertical = Input.GetAxis("Vertical");     //da -1 a 1 ( da tastiera : -1 giù , 1 su )

        //3 dimensioni quindi vector 3
        Vector3 movement = new Vector3(movementHorizontal, 0.0f , movementVertical); //0.0f per non far fare cast al compilatore

        rb.AddForce(movement*speed);        //prodotto scalare movement * speed

		//cambia colore in base al numero di cubi raccolti
		if (gameController.getScore () >= 2) {
			rend.material.SetColor("_Color", Color.yellow);//i colori devono avere la stessa stringa come tag
		}
	}

    public void OnCollisionEnter(Collision other)
    {
        //Collisione col nemico
        if (other.gameObject.CompareTag("Enemy"))
           this.gameController.LoseLife();

        //Collisione con il fondo della mappa
        if (other.gameObject.CompareTag("BottomPlane"))
            this.gameController.OutOfMap();

        // Collisione col terreno per salto
        // Se collide col terreno può saltare
        if (other.gameObject.CompareTag("Ground"))
            isOnGround = true;
    }

	public void OnCollisionExit(Collision other)
    {
        // Collisione con terreno per salto
        // Se non collide col terreno non può saltare
		if (other.gameObject.CompareTag ("Ground"))
			isOnGround = false;
	}

}
