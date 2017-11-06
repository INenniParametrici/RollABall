using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private RawImage img;
    private float startHealthWidth = 0.6f;
    private PlayerController playerController;
    private Text endText;
    private Text scoreText;
    private int score = 0;


	//serve per cambiare colore al player
	public int getScore(){
		return this.score;
	}

    void Start()
    {
        this.playerController = GameObject.FindGameObjectWithTag("Giocatore").GetComponent<PlayerController>();
        this.img = GameObject.FindObjectOfType<RawImage>();
        this.endText = GameObject.Find("EndText").GetComponent<Text>();
        this.scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update ()
    {
        this.scoreText.text = "Score: "+this.score; // è più veloce la concatenazione o il ToString()?????
	}

    public void incrementScore()
    {
        this.score++;
        if (this.score == 4) this.WinGame();
    }

    public void LoseLife()
    {
        startHealthWidth = startHealthWidth - 0.2f;
        this.img.uvRect = new Rect(1f, 1f, startHealthWidth, 1f);
        this.img.SetNativeSize();

        playerController.health--;

        if (playerController.health == 0)
            this.LoseGame();
    }

    // Se il giocatore cade fuori dalla mappa il gioco termina
    public void OutOfMap() { this.LoseGame();  }

    void LoseGame()
    {
        endText.text = "Hai perso!";
        GameObject.FindGameObjectWithTag("Giocatore").SetActive(false);
    }

    void WinGame()
    {
        endText.text = "Hai vinto!";
        GameObject.FindGameObjectWithTag("Giocatore").SetActive(false);
    }
}
