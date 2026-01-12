using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    // Имя сцены, куда мы перейдем после финиша
    public string resultsSceneName = "LevelMenu";

    // Имя ключа PlayerPrefs, где хранятся монеты
    private const string COIN_KEY = "coins";

    // Замечание: Мы используем OnTriggerEnter2D, так как твой скрипт Bonus использует 2D коллайдеры.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, что в триггер вошел именно игрок с тегом "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок достиг финиша!");

            // 1. Получаем общее количество монет, которое игрок собрал (глобально через PlayerPrefs)
            int totalCoinsAtFinish = PlayerPrefs.GetInt(COIN_KEY, 0);

            // 2. Сохраняем это значение для передачи на сцену результатов
            ResultsDataHolder.LastLevelScore = totalCoinsAtFinish;

            // 3. Сохраняем название текущей сцены, чтобы можно было вернуться
            ResultsDataHolder.CurrentLevelName = SceneManager.GetActiveScene().name;

            // 4. Загружаем сцену результатов
            SceneManager.LoadScene(resultsSceneName);
        }
    }
}