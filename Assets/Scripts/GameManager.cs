using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //try not to keep everything public
    public static GameManager instance; // Singleton instance
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;
    int score = 0;
    public GameOverScreen gameOverScreen;

    bool isGameOver = false; // Flag to check if the game is over

    void Awake()
    {instance=this;
       Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !gameStarted)
        {
           Play();
        }
    }

    public void Play(){
        if(gameStarted) return;
         StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);
    } 


    public void StartSpawning()
    {   // Prevent multiple invocations
         InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }


    public void SpawnBlock()
    {  
        if(isGameOver) return;
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {   gameStarted = false; // Stop tzhe gameZ
      //  gameOverScreen.Setup(score); // Call Setup on the GameOverScreen
       // Invoke("RestartGame", 2f); // Restart the game after 2 seconds
    }

   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TriggerGameOver()
    {
        Debug.Log("Game Over triggered");
       // gameOverScreen.Setup(score); // Call Setup on the GameOverScreen
        gameStarted = false; // Stop the game
      // Invoke("RestartGame", 2f);
    }
    public int GetScore()
    {
        return score;
    }

    public void SetGameOver(bool isGameOver)
    {
        this.isGameOver = isGameOver;}
        public bool IsGameOver(){
            return isGameOver;
        }
        
}
