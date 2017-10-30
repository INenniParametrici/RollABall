using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour
{
    private GameController gameController;

	// Use this for initialization
	void Start ()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			gameController.incrementScore();
		}
	}
}
