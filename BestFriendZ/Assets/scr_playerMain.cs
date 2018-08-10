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
                movementAxisX = Input.GetAxis("P0 Horizontal");
                movementAxisY = Input.GetAxis("P0 Vertical");
                break;

            case 1:
                movementAxisX = Input.GetAxis("P1 Horizontal");
                movementAxisY = Input.GetAxis("P1 Vertical");
                break;

            case 2:
                movementAxisX = Input.GetAxis("P2 Horizontal");
                movementAxisY = Input.GetAxis("P2 Vertical");
                break;

            case 3:
                movementAxisX = Input.GetAxis("P3 Horizontal");
                movementAxisY = Input.GetAxis("P3 Vertical");
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
            collision.gameObject.GetComponent<scr_playerMain>().isZombie = true;
    }
}
