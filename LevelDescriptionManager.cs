using UnityEngine;
using UnityEngine.UI;
using TMPro; // Required for TextMeshPro
using UnityEngine.SceneManagement;

public class LevelDescriptionManager : MonoBehaviour
{
    public Image levelImage;
    public TextMeshProUGUI levelNameText;
    public TextMeshProUGUI levelDescriptionText;
    public string levelToLoad;

    void Start()
    {
        // Получаем данные из LevelDataHolder
        levelImage.sprite = LevelDataHolder.LevelImage;
        levelNameText.text = LevelDataHolder.LevelName;
        levelDescriptionText.text = LevelDataHolder.LevelDescription;
        levelToLoad = LevelDataHolder.SceneName;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}