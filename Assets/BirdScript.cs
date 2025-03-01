using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
   

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    public AudioSource jumpSound; // Sound for jumping
    public AudioSource hitSound;  // Sound for collision
    public AudioSource scoreSound;  //

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!birdIsAlive) return;


        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);


        if (viewPos.y < 0 || viewPos.y > 1)
        {
            logic.gameOver();
            birdIsAlive = false;
        }


        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            if (jumpSound != null) 
            {
                jumpSound.Play();
            }
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameOver();
    }

    void gameOver(){
        if (!birdIsAlive) return; 

        birdIsAlive = false;
        logic.gameOver();

        if (hitSound != null)
        {
            hitSound.Play(); // Play collision sound
        }
    }
}
