using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public Text gameTimer;
    public float secondsLeft;
    public GameObject endGame;
    public Text gameOverText;
    public Text gameOverSeconds;

	// Use this for initialization
	void Start () {
        endGame.SetActive(false);
        gameTimer.text = secondsLeft.ToString("F0");
	}

    public void OnEnable()
    {
        NewEventManager.StartListening("win", youWin);
    }

    public void OnDisable()
    {
        NewEventManager.StopListening("win", youWin);
    }

    // Update is called once per frame
    void Update () {
        secondsLeft -= Time.deltaTime;
        gameTimer.text = secondsLeft.ToString("F0");

		if(secondsLeft<=0)
        {
            endGame.SetActive(true);
            gameOverText.text = "You failed to get Eric to the afterlife in time";
            gameOverSeconds.text = "";
        }
        else if(secondsLeft<30)
        {
            gameTimer.color = Color.red;
        }        
	}

    public void youWin()
    {
        endGame.SetActive(true);
        gameOverText.text = "You helped Eric pass on to the next life in";
        gameOverSeconds.text = secondsLeft.ToString();
    }

}
