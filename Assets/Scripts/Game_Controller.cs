using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public Text scoreText; // UI Text element to display the current score
    public Text highScoreText; // UI Text element to display the high score

    public int score; // Variable to store the current score
    public int highScore; // Variable to store the high score

    public Score_Manager score_manager; // Reference to the Score_Manager script

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be added here if needed
    }

    // Update is called once per frame
    void Update()
    {
        highScore = PlayerPrefs.GetInt("high_score"); // Retrieve the high score from PlayerPrefs
        score = score_manager.score; // Get the current score from the Score_Manager script

        scoreText.text = "Score: " + score.ToString(); // Update the score text UI
        highScoreText.text = "HighScore: " + highScore; // Update the high score text UI
    }

    // Method to restart the game by loading the "Game" scene
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    // Method to go back to the main menu by loading the "Start" scene and resuming time if paused
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1; // Ensure the game time is running normally
    }
}
