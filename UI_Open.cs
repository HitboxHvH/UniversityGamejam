using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject settingsPanel;
    public Button firstSelectedButton;
    
    [Header("Input Settings")]
    public KeyCode openKey = KeyCode.Escape; // Меняйте эту переменную!

    private bool isSettingsOpen = false;

    void Update()
    {
        // Отслеживаем нажатие заданной кнопки
        if (Input.GetKeyDown(openKey))
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        isSettingsOpen = !isSettingsOpen;
        settingsPanel.SetActive(isSettingsOpen);
        
        if (isSettingsOpen && firstSelectedButton != null)
        {
            firstSelectedButton.Select();
        }
        
        Time.timeScale = isSettingsOpen ? 0f : 1f;
        Cursor.visible = isSettingsOpen;
        Cursor.lockState = isSettingsOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }
}