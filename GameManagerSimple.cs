using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerSimple : MonoBehaviour
{
    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    
    [Header("Coin System")]
    public Text coinCountText; 
    public int startCoins = 0; 

    void Start()
    {
       
        ResetGameState();
        
      
        InitializeCoins();
    }
    
    void ResetGameState()
    {
        Time.timeScale = 1f;
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }
    
    void InitializeCoins()
    {

        PlayerPrefs.SetInt("coins", startCoins);
        

        UpdateCoinUI();
        
        Debug.Log($"Монеты сброшены. Стартовое количество: {startCoins}");
    }
    
    void UpdateCoinUI()
    {
        if (coinCountText != null)
        {
            int currentCoins = PlayerPrefs.GetInt("coins", startCoins);
            coinCountText.text = currentCoins.ToString();
        }
    }
    
    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        
        Debug.Log("Game Over!");
    }
    
    public void RestartGame()
    {
        Debug.Log("Перезапуск игры! Монеты сброшены.");
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}