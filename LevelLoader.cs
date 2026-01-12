using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Sprite levelImage; // Скриншот уровня
    public string levelName; // Название уровня
    public string levelDescription; // Описание уровня
    public string sceneName; // Название сцены уровня

    public void LoadLevelDescription()
    {
        // Сохраняем данные уровня (лучше использовать PlayerPrefs, но для простоты пока так)
        LevelDataHolder.LevelImage = levelImage;
        LevelDataHolder.LevelName = levelName;
        LevelDataHolder.LevelDescription = levelDescription;
        LevelDataHolder.SceneName = sceneName;
        Debug.Log("Level Name: " + levelName);
        Debug.Log("Scene Name: " + sceneName);

        SceneManager.LoadScene("LevelDescription");
    }

    //Этот метод больше не используется напрямую
    //public void LoadLevel(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    Debug.Log("Загрузка уровня: " + sceneName); // Для отладки
    //}
}