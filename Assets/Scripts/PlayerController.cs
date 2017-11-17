﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    //public permette modifiche al programmatore dall ide unity
    public float speed = 1; 
	private bool isSpeedMultiplied = false; // serve per evitare un incremento costante di speed quando score > 2
	public float jumpIntensity = 0;
    private bool isOnGround = true;
    public int health = 3;
    private ParticleSystem playerCollisionParticles;
	private GameController gameController; //variabile che utilizzo per verifiche incrociate coi dati di gioco 
    private Rigidbody rb; //variabile che definisce le proprietà di corpo rigido 
	public Renderer rend;
	// Use this for initialization call one a time
	void Start ()
    {
		rend = GetComponent<Renderer> (); //occorre recuperare il Rendered per operare sull'aspetto grafico
		rend.material.SetColor ("_Color",Color.blue); //Si usa color perchè RGBA è compreso tra 0 e 1
		rb = GetComponent<Rigidbody>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playerCollisionParticles = GameObject.FindGameObjectWithTag("PlayerCollisionSparks").GetComponent<ParticleSystem>();

    }

    public bool getIsOnGround()
    {
        return isOnGround;
    }

    // Update is called once per frame
    void FixedUpdate () {
		float jump = Input.GetAxis ("Jump");

		if (isOnGround && rb.useGravity == true) {
			Vector3 jumpVector = new Vector3 (0.0f, jump, 0.0f);
			rb.AddForce (jumpVector * jumpIntensity, ForceMode.Impulse);
		}

		if (isOnGround && rb.useGravity == false) {
			Vector3 jumpVector = new Vector3 (0.0f, jump, 0.0f);
			jumpIntensity = 10;
			rb.AddForce (jumpVector * jumpIntensity, ForceMode.Impulse);
		}
		
		

        float movementHorizontal = Input.GetAxis("Horizontal"); //da -1 a 1  ( da tastiera -1 sinistra, 1 destra)
        float movementVertical = Input.GetAxis("Vertical");     //da -1 a 1 ( da tastiera : -1 giù , 1 su )

        //3 dimensioni quindi vector 3
        Vector3 movement = new Vector3(movementHorizontal, 0.0f , movementVertical); //0.0f per non far fare cast al compilatore

        rb.AddForce(movement*speed);        //prodotto scalare movement * speed

		//cambia colore in base al numero di cubi raccolti
		if (gameController.getScore () >= 4) {
			rend.material.SetColor("_Color", Color.yellow);//i colori devono avere la stessa stringa come tag
			if (isSpeedMultiplied == false) {
				this.speed = this.speed * 2;
				isSpeedMultiplied = true;
			}
		}
	}

    public void OnCollisionEnter(Collision other)
    {
        //Collisione col nemico
        if (other.gameObject.CompareTag("Enemy"))
           this.gameController.LoseLife();
        if (other.gameObject.CompareTag("Enemy2"))
            this.gameController.LoseLife();

        //Collisione con il fondo della mappa
        if (other.gameObject.CompareTag("BottomPlane"))
            this.gameController.OutOfMap();

        // Collisione col terreno per salto
        // Se collide col terreno può saltare
        if (other.gameObject.CompareTag("Ground"))
            isOnGround = true;

		//Se collide con il disattivatore di gravità
		//si può salire nel tunnel verso l'alto 
		if (other.gameObject.CompareTag ("GravityInverter")) {
			//rb.useGravity = false;
			rb.AddForce(new Vector3 (0.0f, 60.0f, 0.0f));


			//Bisogna aggiungere una forza verso l'alto qui per velocizzare la salita
			//meglio usare una forza esplosiva per non doverla rimuovere quando si esce col collider
			Debug.Log ("CI SIAMO");
		}

		//Se collide con l'attivatore di gravità
		//si può salire nel tunnel verso l'alto 

		if (other.gameObject.CompareTag ("GravityEneabler")) {
			rb.useGravity = true;
			jumpIntensity = 1; 
			Debug.Log ("CI SIAMO");
		}


        playerCollisionParticles.transform.position = other.contacts[0].point;
        playerCollisionParticles.Play();
    }

	public void OnCollisionExit(Collision other)
    {
        // Collisione con terreno per salto
        // Se non collide col terreno non può saltare
		if (other.gameObject.CompareTag ("Ground"))
			isOnGround = false;
	}

}
