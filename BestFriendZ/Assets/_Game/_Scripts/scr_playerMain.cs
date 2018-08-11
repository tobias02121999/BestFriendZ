using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMain : MonoBehaviour {

    // Initialize the public variables
    public int playerID;
    public bool isZombie;
    public float movementSpeed;
    public float movementSpeedZombie;
    public Transform cameraTransform;
    public GameObject playerHumanModel;
    public GameObject playerZombieModel;
    public Light playerLight;
    public AudioSource audioSource;

    // Initialize the private variables
    private float movementAxisX;
    private float movementAxisY;
    private float rotationY;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Store the player input in variables
        switch (playerID)
        {
            case 0:
                switch (scr_menuController.player0InputType)
                {
                    case 0:
                        movementAxisX = Input.GetAxis("Arrow Keys Horizontal");
                        movementAxisY = Input.GetAxis("Arrow Keys Vertical");
                        break;

                    case 1:
                        movementAxisX = Input.GetAxis("WASD Horizontal");
                        movementAxisY = Input.GetAxis("WASD Vertical");
                        break;

                    case 2:
                        movementAxisX = Input.GetAxis("Gamepad 0 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 0 Vertical");
                        break;

                    case 3:
                        movementAxisX = Input.GetAxis("Gamepad 1 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 1 Vertical");
                        break;

                    case 4:
                        movementAxisX = Input.GetAxis("Gamepad 2 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 2 Vertical");
                        break;

                    case 5:
                        movementAxisX = Input.GetAxis("Gamepad 3 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 3 Vertical");
                        break;
                }

                playerLight.color = Color.blue;
                break;

            case 1:
                switch (scr_menuController.player1InputType)
                {
                    case 0:
                        movementAxisX = Input.GetAxis("Arrow Keys Horizontal");
                        movementAxisY = Input.GetAxis("Arrow Keys Vertical");
                        break;

                    case 1:
                        movementAxisX = Input.GetAxis("WASD Horizontal");
                        movementAxisY = Input.GetAxis("WASD Vertical");
                        break;

                    case 2:
                        movementAxisX = Input.GetAxis("Gamepad 0 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 0 Vertical");
                        break;

                    case 3:
                        movementAxisX = Input.GetAxis("Gamepad 1 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 1 Vertical");
                        break;

                    case 4:
                        movementAxisX = Input.GetAxis("Gamepad 2 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 2 Vertical");
                        break;

                    case 5:
                        movementAxisX = Input.GetAxis("Gamepad 3 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 3 Vertical");
                        break;
                }

                playerLight.color = Color.red;
                break;

            case 2:
                switch (scr_menuController.player2InputType)
                {
                    case 0:
                        movementAxisX = Input.GetAxis("Arrow Keys Horizontal");
                        movementAxisY = Input.GetAxis("Arrow Keys Vertical");
                        break;

                    case 1:
                        movementAxisX = Input.GetAxis("WASD Horizontal");
                        movementAxisY = Input.GetAxis("WASD Vertical");
                        break;

                    case 2:
                        movementAxisX = Input.GetAxis("Gamepad 0 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 0 Vertical");
                        break;

                    case 3:
                        movementAxisX = Input.GetAxis("Gamepad 1 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 1 Vertical");
                        break;

                    case 4:
                        movementAxisX = Input.GetAxis("Gamepad 2 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 2 Vertical");
                        break;

                    case 5:
                        movementAxisX = Input.GetAxis("Gamepad 3 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 3 Vertical");
                        break;
                }

                playerLight.color = Color.green;
                break;

            case 3:
                switch (scr_menuController.player3InputType)
                {
                    case 0:
                        movementAxisX = Input.GetAxis("Arrow Keys Horizontal");
                        movementAxisY = Input.GetAxis("Arrow Keys Vertical");
                        break;

                    case 1:
                        movementAxisX = Input.GetAxis("WASD Horizontal");
                        movementAxisY = Input.GetAxis("WASD Keys Vertical");
                        break;

                    case 2:
                        movementAxisX = Input.GetAxis("Gamepad 0 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 0 Vertical");
                        break;

                    case 3:
                        movementAxisX = Input.GetAxis("Gamepad 1 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 1 Vertical");
                        break;

                    case 4:
                        movementAxisX = Input.GetAxis("Gamepad 2 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 2 Vertical");
                        break;

                    case 5:
                        movementAxisX = Input.GetAxis("Gamepad 3 Horizontal");
                        movementAxisY = Input.GetAxis("Gamepad 3 Vertical");
                        break;
                }

                playerLight.color = Color.yellow;
                break;
        }

        // Change the players mesh to make him look like a zombie, if necessary
        if (isZombie && !playerZombieModel.activeSelf)
        {
            playerHumanModel.SetActive(false);
            playerZombieModel.SetActive(true);
            movementSpeed = movementSpeedZombie;
        }
    }

    // FixedUpdate is called once per fixed frame
    void FixedUpdate()
    {
        // Move around according to the player input
        transform.position += cameraTransform.right * movementSpeed * movementAxisX * Time.deltaTime;
        transform.position += cameraTransform.forward * movementSpeed * movementAxisY * Time.deltaTime;

        if (movementAxisX != 0f || movementAxisY != 0f)
            rotationY = Mathf.Atan2(movementAxisX, movementAxisY);

        transform.rotation = Quaternion.Euler(0f, rotationY * Mathf.Rad2Deg, 0f);
    }

    // OnCollisionEnter is called once collision is detected
    void OnCollisionEnter(Collision collision)
    {
        if (isZombie && !collision.gameObject.GetComponent<scr_playerMain>().isZombie)
        {
            audioSource.Play();
            collision.gameObject.GetComponent<scr_playerMain>().isZombie = true;
        }
    }
}
