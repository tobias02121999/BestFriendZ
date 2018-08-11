using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_menuController : MonoBehaviour {

    // Initialize the public variables
    public int menuIndex;
    public GameObject startMenu;
    public GameObject playerSetupMenu;
    public Text playerSetupText;

    [HideInInspector]
    public static int player0InputType;
    [HideInInspector]
    public static int player1InputType;
    [HideInInspector]
    public static int player2InputType;
    [HideInInspector]
    public static int player3InputType;

    // Initialize the private variables
    private int playerIndex;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		// Display the appropriate elements according to the menu index
        switch (menuIndex)
        {
            case 0:
                // Check for any key pressed, if so continue to the next menu index
                if (Input.anyKeyDown)
                    menuIndex++;
                break;

            case 1:
                // Disable the old menu and enable the new one
                startMenu.SetActive(false);
                playerSetupMenu.SetActive(true);

                playerSetupText.text = "PLAYER " + (playerIndex + 1) + " - PRESS ANY OF THE FOLLOWING";

                // 
                if (Input.GetKeyDown("up"))
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 0;
                            break;

                        case 1:
                            player1InputType = 0;
                            break;

                        case 2:
                            player2InputType = 0;
                            break;

                        case 3:
                            player3InputType = 0;
                            break;
                    }

                if (Input.GetKeyDown("w"))
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 1;
                            break;

                        case 1:
                            player1InputType = 1;
                            break;

                        case 2:
                            player2InputType = 1;
                            break;

                        case 3:
                            player3InputType = 1;
                            break;
                    }

                if (Input.GetButtonDown("Gamepad 0 Button A"))
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 2;
                            break;

                        case 1:
                            player1InputType = 2;
                            break;

                        case 2:
                            player2InputType = 2;
                            break;

                        case 3:
                            player3InputType = 2;
                            break;
                    }
                }

                if (Input.GetKeyDown("up") || Input.GetKeyDown("w") || Input.GetButtonDown("Gamepad 0 Button A"))
                {
                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        SceneManager.LoadScene("sce_game");
                }    
                break;
        }
	}
}
