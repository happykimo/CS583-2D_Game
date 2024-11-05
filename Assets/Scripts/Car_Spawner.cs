using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Spawner : MonoBehaviour
{
    public GameObject[] cars; // Array of car prefabs to spawn
    public float[] possibleXPos = { -2.0f, -1.35f, -0.7f, 0.0f, 0.7f, 1.35f, 2.0f }; // Array of possible X positions for spawning cars

    public float spawnTime = 2f; // Initial spawn time interval
    public float spawnIncreaseInterval = 5f; // Interval in seconds to reduce the spawn time
    private float lastSpawnIncreaseTime; // Tracks the last time the spawn interval was increased

    // Start is called before the first frame update
    void Start()
    {
        lastSpawnIncreaseTime = Time.time; // Initialize the last spawn increase time to the current time
        StartCoroutine(SpawnCars()); // Start the coroutine to spawn cars
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to decrease the spawn interval
        if (Time.time - lastSpawnIncreaseTime >= spawnIncreaseInterval && spawnTime > 0.5f)
        {
            spawnTime -= 0.1f; // Decrease the spawn interval
            lastSpawnIncreaseTime = Time.time; // Reset the last spawn increase time
        }
    }

    // Function to spawn a car at a random position
    void Cars()
    {
        int randomCarsIndex = Random.Range(0, cars.Length); // Randomly select a car prefab
        int randomSpawnIndex = Random.Range(0, possibleXPos.Length); // Randomly select a spawn position
        Instantiate(
            cars[randomCarsIndex], // Car prefab to spawn
            new Vector3(possibleXPos[randomSpawnIndex], 10, 0), // Spawn position
            Quaternion.Euler(0, 0, 90) // Spawn rotation
        );
    }

    // Coroutine to continuously spawn cars at intervals
    IEnumerator SpawnCars()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime); // Wait for the current spawn interval
            Cars(); // Spawn a car
        }
    }
}
