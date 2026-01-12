using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Укажи название сцены главного меню
    }
    public void LoadLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu"); // Укажи название сцены главного меню
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings"); // Укажи название сцены главного меню
    }
    public void LoadAudioSettings()
    {
        SceneManager.LoadScene("AudioSettings"); // Укажи название сцены главного меню
    }
    public void ExitGame()
    {
        // Эта команда работает как в Unity Editor, так и в собранном билде.
        // В редакторе она просто останавливает игру.
        // В собранном приложении она закрывает окно игры.

#if UNITY_EDITOR
            // Если мы в редакторе Unity, останавливаем игру
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Если мы в собранном приложении, закрываем игру
        Application.Quit();
#endif

        Debug.Log("Игра закрывается."); // Для отладки
    }
}