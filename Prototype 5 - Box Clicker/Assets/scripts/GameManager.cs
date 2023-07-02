using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject gameOverScreen;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(score);
        gameOverScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        titleScreen.gameObject.SetActive(true);
    }

    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver(){
        gameOverScreen.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);        
        isGameActive = false;
    }
    
    public void StartGame(int difficulty){
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        spawnRate /= difficulty;

        isGameActive = true;
        score = 0;
        UpdateScore(score);
        StartCoroutine(SpawnTarget());
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        titleScreen.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);
        }
    }
}
