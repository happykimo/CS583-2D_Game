using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car_Movement : MonoBehaviour
{
    public float startingSpeed; // Initial speed of the car
    public float speed = 4f; // Current speed of the car
    public float speedIncreaseInterval = 5f; // Interval in seconds to increase the speed
    public float lastSpeedIncreaseTime; // Tracks the last time the speed was increased

    // Start is called before the first frame update
    void Start()
    {
        speed = startingSpeed; // Set the initial speed to the starting speed
        lastSpeedIncreaseTime = Time.time; // Initialize the last speed increase time to the current time
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the time since the last speed increase has exceeded the interval
        if (Time.time - lastSpeedIncreaseTime >= speedIncreaseInterval)
        {
            speed += 2f; // Increase the speed
            lastSpeedIncreaseTime = Time.time; // Reset the last speed increase time
        }

        // Move the car downwards based on the current speed
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

        // Destroy the car if it moves off the bottom of the screen
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
