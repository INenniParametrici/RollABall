using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectObjects : MonoBehaviour {
	public int count = 0;
	public Text score;
	public Text victoryText;
	// Use this for initialization
	void Start () {
		score.text = "Score : " + count;
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 4) {
			victoryText.text = "You Win !!!";
		} else {
			score.text = "Score : " + count;
		}


	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
		}
	}
}
