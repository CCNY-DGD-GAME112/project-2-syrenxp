using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public float timer = 60f;
    public TextMeshProUGUI timerText;

    public GameObject gameOverCanvas;
    public GameObject winCanvas;

    private bool isGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F0");

        if (timer <=0)
        {
            GameOver();
        }
    }

    public void AddTime(float amount)
    {
        timer += amount;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        isGameOver= true;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        isGameOver = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void WinGame()
    {
       
        isGameOver = true;
        Debug.Log("You Win");
        winCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
      
    }

