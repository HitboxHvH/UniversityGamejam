using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Для использования IEnumerator

public class SplashScreenManager : MonoBehaviour
{
    public string mainMenuSceneName = "MainMenu"; // Имя сцены главного меню
    public float displayTime = 3f; // Время отображения заставки в секундах

    void Start()
    {
        // Запускаем корутину, которая будет ждать displayTime и затем переходить к главному меню
        StartCoroutine(LoadMainMenuAfterDelay());
    }

    IEnumerator LoadMainMenuAfterDelay()
    {
        // Ждем указанное время
        yield return new WaitForSeconds(displayTime);

        // Загружаем сцену главного меню
        SceneManager.LoadScene(mainMenuSceneName);
    }
}