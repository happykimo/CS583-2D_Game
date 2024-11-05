using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public static bool GameInPlay;
    public float speed = 3f; // Initial speed of the player
    public float speedIncreaseInterval = 5f; // Interval in seconds to increase speed
    public float lastSpeedIncreaseTime; // Last time the speed was increased

    // public float rotationSpeed = 100f; // (Commented out) Variable for rotation speed, not used

    public Score_Manager scoreValue; // Reference to the Score_Manager script

    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public GameObject startPanel; // Reference to the Start UI panel

    Audio_Manager audioManager;
    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        GameInPlay = true;
        gameOverPanel.SetActive(false); // Ensure the Game Over panel is hidden at the start
        Time.timeScale = 1; // Set the game time scale to normal
        lastSpeedIncreaseTime = Time.time; // Initialize the last speed increase time to the current time
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); // Handle player movement
        Clamp(); // Clamp the player's position within the allowed boundaries
    }

    // Handle player movement
    void Movement()
    {
        // Increase speed every speedIncreaseInterval seconds
        if (Time.time - lastSpeedIncreaseTime >= speedIncreaseInterval && speed < 10f)
        {
            speed++; // Increase the speed
            lastSpeedIncreaseTime = Time.time; // Reset the last speed increase time
        }

        // Move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        // Move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        // Move up
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        // Clamp the y position to prevent moving too far up
        if (transform.position.y > 4.2f)
        {
            transform.position = new Vector3(transform.position.x, 4.2f, transform.position.z);
        }

        // Move down
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        // Clamp the y position to prevent moving too far down
        if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, transform.position.z);
        }
    }

    // Clamp the player's position within the horizontal boundaries
    void Clamp()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -2.05f, 2.05f); // Clamp the x position between -2.05 and 2.05
        transform.position = pos; // Apply the clamped position
    }

    // Handle collision with other objects
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with a GameObject tagged "Cars"
        if (collision.gameObject.tag == "Cars")
        {
            audioManager.PlaySFX(audioManager.explosion);
            Time.timeScale = 0; // Pause the game
            speed = 3f; // Reset the speed
            gameOverPanel.SetActive(true); // Show the Game Over panel
        }
    }
}
