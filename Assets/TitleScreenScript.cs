using UnityEngine;

public class TitleScreenScript : MonoBehaviour
{

    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0; // Pause the game until the player clicks "Start"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        titleScreen.SetActive(false); // Hide title screen
        Time.timeScale = 1; // Resume game
    }
}
