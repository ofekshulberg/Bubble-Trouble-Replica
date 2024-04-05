using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    private int activeBalls; // Number of currently active balls

    private bool gameOver = false;

    void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this method when a ball is split or created
    public void BallCreated()
    {
        activeBalls++;
    }

    // Call this method when a ball is destroyed
    public void BallDestroyed()
    {
        activeBalls--;

        // Check if there are no more active balls
        if (activeBalls <= 0)
        {
            // All balls are destroyed, trigger game over
            GameOver();
        }
    }


    void Update()
    {
        // Check for game over condition
        if (!gameOver && AreAllBallsDestroyed())
        {
            // All balls are destroyed, trigger game over
            GameOver();
        }
    }
    bool AreAllBallsDestroyed()
    {
        // Check if there are no active balls
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        return balls.Length == 0;
    }

    // Game over logic
    void GameOver()
    {
        Debug.Log("Game Over!");
        // You can add additional game over logic here if needed
        gameOver = true;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
