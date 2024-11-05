using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    // Variables to hold the score, high score, and last score
    public int score = 0; // Current score
    public int highScore; // High score
    public static int lastScore = 0; // Last score from the previous game
    public Text scoreText; // UI Text element to display the score
    public Text highScoreText; // UI Text element to display the high score

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Score()); // Start the coroutine to update the score periodically
        //StartCoroutine(Reload()); // (Commented out) Start the coroutine to reload the scene after a delay

        highScore = PlayerPrefs.GetInt("high_score", 1000); // Get the high score from PlayerPrefs, or default to 1000
        Debug.Log("Highscore Stored: " + PlayerPrefs.GetInt("high_score")); // Log the stored high score
        Debug.Log("Highscore Get: " + highScore); // Log the retrieved high score

        highScoreText.text = "HighScore: " + highScore.ToString(); // Update the high score text UI
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the score text UI
        highScoreText.text = "HighScore: " + highScore; // Update the high score text UI

        // Check if the current score exceeds the high score
        if (score > highScore)
        {
            highScore = score; // Update the high score
            PlayerPrefs.SetInt("high_score", highScore); // Save the new high score to PlayerPrefs
            Debug.Log("Highscore: " + highScore); // Log the new high score
        }
    }

    // Coroutine to periodically update the score
    IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f); // Wait for 0.8 seconds
            score += 100; // Increase the score by 100
            lastScore = score; // Update the last score
            // Debug.Log("Score: " + score); // (Commented out) Log the current score
        }
    }

    // Coroutine to reload the scene after a delay (currently not used)
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(10); // Wait for 10 seconds
        SceneManager.LoadScene("Game"); // Reload the "Game" scene
    }

    // Allows resetting the high score in PlayerPrefs through the Unity Editor
    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false; // Flag to trigger resetting the high score

    // This method is called when the Unity Editor draws Gizmos
    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false; // Reset the flag
            PlayerPrefs.SetInt("high_score", 1000); // Reset the high score to 1000 in PlayerPrefs
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000."); // Log a warning message
        }
    }
}
