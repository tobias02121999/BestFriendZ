using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_gameControllerZombifier : MonoBehaviour {

    // Initialize the public variables
    public GameObject[] players;
    public Text timerText;
    public Text gameOverText;
    public float startTimerDuration;
    public float timerDuration;
    public float rotateDegrees;
    public Transform pointLightPivotTransform;
    public AudioSource audioSourceMenu;
    public AudioSource audioSourceTheme;

    // Initialize the private variables
    private float startTimer;
    private float timer;
    private int i;
    private bool gameOver;
    private bool zombieIsChosen;

	// Use this for initialization
	void Start ()
    {
        // Set the timer to equal the given timer duration
        startTimer = startTimerDuration;
        timer = timerDuration;
	}
	
	// Update is called once per frame
	void Update ()
    {
        startTimer -= Time.deltaTime;
        
        if (startTimer >= Time.deltaTime)
            timerText.text = Mathf.Round(startTimer).ToString();
        else
        {
            audioSourceMenu.enabled = false;
            audioSourceTheme.enabled = true;

            if (!zombieIsChosen)
            {
                // Choose one random player and turn him into a zombie
                players[Mathf.RoundToInt(Random.Range(0f, players.Length - 1f))].GetComponent<scr_playerMain>().isZombie = true;
                zombieIsChosen = true;
            }

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
                    gameOverText.text = "HUMANS WIN! - PRESS SPACEBAR TO RESTART";
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
                    gameOverText.text = "ZOMBIES WIN! - PRESS SPACEBAR TO RESTART";
                    gameOver = true;
                }

                // Cycle through night and day, rotate the sun and moon the given amount of degrees
                pointLightPivotTransform.Rotate(rotateDegrees / (timerDuration / Time.deltaTime), 0f, 0f);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                    SceneManager.LoadScene("sce_game");
            }
        }

        if (Input.GetKeyDown("escape"))
            SceneManager.LoadScene("sce_menu");
    }
}
