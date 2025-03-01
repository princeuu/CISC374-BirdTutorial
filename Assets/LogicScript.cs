using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    private bool isGameOver = false; // Flag to track game state
    public Text highScoreText; // UI for high score

    public AudioSource scoreSound;
    void Start()
    {
        // Load high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateHighScoreUI();
        Debug.Log("Loaded High Score: " + highScore);
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd) {

        if (isGameOver) return; // Prevent score from increasing after game over

        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();

        if (scoreSound != null)
        {
            scoreSound.Play(); // Play score sound effect
        }

        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Save high score
            PlayerPrefs.Save();
            UpdateHighScoreUI();
            Debug.Log("New High Score Saved: " + highScore);
        }
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        isGameOver = true; // Set the game over flag
        gameOverScreen.SetActive(true);
    }
    private void UpdateHighScoreUI()
    {
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }

}
