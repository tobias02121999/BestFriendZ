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
    public GameObject gameStartMenu;

    public GameObject setPlayer1;
    public GameObject setPlayer2;
    public GameObject setPlayer3;
    public GameObject setPlayer4;

    public GameObject player1ArrowUpImage;
    public GameObject player1KeyWImage;
    public GameObject player1ButtonAImage;

    public GameObject player2ArrowUpImage;
    public GameObject player2KeyWImage;
    public GameObject player2ButtonAImage;

    public GameObject player3ArrowUpImage;
    public GameObject player3KeyWImage;
    public GameObject player3ButtonAImage;

    public GameObject player4ArrowUpImage;
    public GameObject player4KeyWImage;
    public GameObject player4ButtonAImage;

    public GameObject quitGameText;

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

    private bool inputType0IsUsed;
    private bool inputType1IsUsed;
    private bool inputType2IsUsed;
    private bool inputType3IsUsed;
    private bool inputType4IsUsed;
    private bool inputType5IsUsed;

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
                if (Input.GetKey("escape"))
                    Application.Quit();
                else
                    if (Input.anyKeyDown)
                        menuIndex++;
                break;

            case 1:
                // Disable the old menu and enable the new one
                startMenu.SetActive(false);
                playerSetupMenu.SetActive(true);
                
                if (Input.GetKeyDown("escape"))
                    SceneManager.LoadScene("sce_menu");

                playerSetupText.text = "PLAYER " + (playerIndex + 1) + " - PRESS ANY OF THE FOLLOWING";

                // 
                if (Input.GetKeyDown("up") && !inputType0IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 0;
                            player1ArrowUpImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 0;
                            player2ArrowUpImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 0;
                            player3ArrowUpImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 0;
                            player4ArrowUpImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType0IsUsed = true;
                }

                if (Input.GetKeyDown("w") && !inputType1IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 1;
                            player1KeyWImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 1;
                            player2KeyWImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 1;
                            player3KeyWImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 1;
                            player4KeyWImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType1IsUsed = true;
                }

                if (Input.GetButtonDown("Gamepad 0 Button A") && !inputType2IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 2;
                            player1ButtonAImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 2;
                            player2ButtonAImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 2;
                            player3ButtonAImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 2;
                            player4ButtonAImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType2IsUsed = true;
                }

                if (Input.GetButtonDown("Gamepad 1 Button A") && !inputType3IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 3;
                            player1ButtonAImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 3;
                            player2ButtonAImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 3;
                            player3ButtonAImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 3;
                            player4ButtonAImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType3IsUsed = true;
                }

                if (Input.GetButtonDown("Gamepad 2 Button A") && !inputType4IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 4;
                            player1ButtonAImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 4;
                            player2ButtonAImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 4;
                            player3ButtonAImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 4;
                            player4ButtonAImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType4IsUsed = true;
                }

                if (Input.GetButtonDown("Gamepad 3 Button A") && !inputType5IsUsed)
                {
                    switch (playerIndex)
                    {
                        case 0:
                            player0InputType = 5;
                            player1ButtonAImage.SetActive(true);
                            break;

                        case 1:
                            player1InputType = 5;
                            player2ButtonAImage.SetActive(true);
                            break;

                        case 2:
                            player2InputType = 5;
                            player3ButtonAImage.SetActive(true);
                            break;

                        case 3:
                            player3InputType = 5;
                            player4ButtonAImage.SetActive(true);
                            break;
                    }

                    if (playerIndex <= 2)
                        playerIndex++;
                    else
                        menuIndex++;

                    inputType5IsUsed = true;
                }

                if (playerIndex >= 1)
                    setPlayer1.SetActive(true);

                if (playerIndex >= 2)
                    setPlayer2.SetActive(true);

                if (playerIndex >= 3)
                    setPlayer3.SetActive(true);
                break;

            case 2:
                // Disable the old menu and enable the new one
                playerSetupMenu.SetActive(false);
                gameStartMenu.SetActive(true);
                quitGameText.SetActive(false);

                setPlayer4.SetActive(true);

                // Check for any key pressed, if so start the match
                if (Input.anyKeyDown)
                    SceneManager.LoadScene("sce_game");
                break;
        }
    }
}
