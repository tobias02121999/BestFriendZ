using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_gameControllerZombifier : MonoBehaviour {

    // Initialize the public variables
    public GameObject[] players;
    public Text timerText;
    public Text gameOverText;
    public float timerDuration;
    public float rotateDegrees;
    public Transform pointLightPivotTransform;

    // Initialize the private variables
    private float timer;
    private int i;
    private bool gameOver;

	// Use this for initialization
	void Start ()
    {
        // Choose one random player and turn him into a zombie
        players[Mathf.RoundToInt(Random.Range(0f, players.Length - 1f))].GetComponent<scr_playerMain>().isZombie = true;

        // Set the timer to equal the given timer duration
        timer = timerDuration;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Decrease the timer duration over time in seconds
        timer -= Time.deltaTime;

        if (!gameOver)
            timerText.text = Mathf.Round(timer).ToString();
        else
            timerText.text = "";

        // Check for human and zombie win conditions if a game over has not yet been triggered
        if (!gameOver)
        {
            // Check if the timer has reached 0
            if (timer <= 0f)
            {
                // The humans have won the match
                gameOverText.text = "humans win!";
                gameOver = true;
            }

            // Check if there are still humans left
            if (i < players.Length)
            {
                // If the current player being checked is human, reset the indicator
                if (players[i].GetComponent<scr_playerMain>().isZombie == false)
                    i = 0;
                else
                    i++;
            }
            else
            {
                // The zombies have won the match
                gameOverText.text = "zombies win!";
                gameOver = true;
            }

            // Cycle through night and day, rotate the sun and moon the given amount of degrees
            pointLightPivotTransform.Rotate(rotateDegrees / (timerDuration / Time.deltaTime), 0f, 0f);
        }
	}
}
