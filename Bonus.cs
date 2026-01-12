using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bonus : MonoBehaviour
{
    public string bonusName;
    public Text coinCount;
    public int value = 1;

    void Start()
    {
        if (coinCount == null)
        {
            coinCount = GameObject.Find("CoinCountText")?.GetComponent<Text>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (bonusName)
            {
                case "coin":
                    int coins = PlayerPrefs.GetInt("coins", 0);
                    int newCoins = coins + value;

                    PlayerPrefs.SetInt("coins", newCoins);

                    if (coinCount != null)
                        coinCount.text = newCoins.ToString();

                    Debug.Log($"Собрана монета! Всего: {newCoins}");

                    if (value > 0)
                        Destroy(gameObject);
                    break;
            }
        }

        // Clear Money
        if (other.gameObject.name == "Player")
        {
            switch (bonusName)
            {
                case "Finish":
                    int coins = PlayerPrefs.GetInt("coins");
                    PlayerPrefs.SetInt("coins", coins - coins);
                    coinCount.text = (coins - coins).ToString();
                    break;
            }
        }
        
        // Financial rain
        if (other.gameObject.name == "Player")
        {
            switch (bonusName)
            {
                case "Fin_rain":
                    int coins = PlayerPrefs.GetInt("coins");
                    PlayerPrefs.SetInt("coins", coins - coins);
                    coinCount.text = (coins - coins).ToString();                    
                    break;
            }
        }
        

    }
}