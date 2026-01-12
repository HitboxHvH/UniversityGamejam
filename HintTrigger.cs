using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    [Tooltip("Ссылка на GameObject с UI-элементами подсказки (HintUI)")]
    public GameObject hintUI;

    private bool isTriggered = false; // Чтобы подсказка не показывалась несколько раз

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;

            // Активируем UI элемент с подсказкой
            if (hintUI != null) // Проверка на null
            {
                hintUI.SetActive(true);
                Debug.Log("Показана подсказка: " + hintUI.name);
            }
            else
            {
                Debug.LogError("HintUI не назначен в HintTrigger на объекте: " + gameObject.name);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isTriggered)
        {
            // Скрываем UI элемент с подсказкой
            if (hintUI != null)
            {
                hintUI.SetActive(false);
                Debug.Log("Скрыта подсказка");
            }
            isTriggered = false; // Раскомментируй, если хочешь, чтобы подсказка появлялась снова при повторном входе
        }
    }
}