using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultsScreenManager : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI coinText; // Ссылка на текст, где будут монеты
    public Button mainMenuButton;
    public Button retryButton;

    void Start()
    {
        // 1. Устанавливаем текст
        titleText.text = "Уровень Пройден!";

        // Отображаем общее количество монет, которое мы получили из FinishTrigger
        coinText.text = "Всего монет: " + ResultsDataHolder.LastLevelScore.ToString();

        // 2. Настраиваем кнопки
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        retryButton.onClick.AddListener(RetryLevel);
    }

    void LoadMainMenu()
    {
        // Загружаем сцену Главного Меню
        SceneManager.LoadScene("LevelMenu");
    }

    void RetryLevel()
    {
        // Загружаем сцену, с которой пришли (хранится в ResultsDataHolder)
        SceneManager.LoadScene(ResultsDataHolder.CurrentLevelName);
    }
}