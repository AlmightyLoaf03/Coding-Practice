using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int lives = 3;
    private static int savedLives = 3;

    [Header("UI References")]
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            lives = savedLives;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);

        UpdateLivesUI();
    }

    public void LoseLife()
    {
        lives--;
        savedLives = lives;
        UpdateLivesUI();

        if (lives <= 0)
        {
            ShowGameOver();
        }
        else
        {
            Invoke("ReloadScene", 1.5f);
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartGame()
    {
        savedLives = 3;
        Time.timeScale = 1f;

        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }
}
