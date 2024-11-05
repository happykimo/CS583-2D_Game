using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road_Movement : MonoBehaviour
{
    public Renderer meshRenderer; // Renderer to access the material's texture offset
    public float speed = 1f; // Initial speed of the road movement
    public float speedIncreaseInterval = 1f; // Interval for increasing the speed (in seconds)
    public float lastSpeedIncreaseTime; // Last time the speed was increased

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f; // Set the initial speed
        lastSpeedIncreaseTime = Time.time; // Initialize the last speed increase time to the current time
    }

    // Update is called once per frame
    void Update()
    {
        // Increase speed every speedIncreaseInterval seconds
        if (Time.time - lastSpeedIncreaseTime >= speedIncreaseInterval)
        {
            speed += 0.1f; // Increase the speed
            lastSpeedIncreaseTime = Time.time; // Reset the last speed increase time
        }

        // Move the texture offset of the material to create the road movement effect
        meshRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
