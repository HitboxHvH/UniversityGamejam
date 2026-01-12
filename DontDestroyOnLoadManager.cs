using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour
{
    // Статическая переменная для хранения единственного экземпляра.
    // null означает, что экземпляр еще не создан.
    private static DontDestroyOnLoadManager instance;

    void Awake()
    {
        // Проверяем, существует ли уже экземпляр
        if (instance == null)
        {
            // Если экземпляра нет, то этот объект становится единственным.
            instance = this; // Сохраняем ссылку на текущий объект.
            DontDestroyOnLoad(gameObject); // Делаем GameObject постоянным.
        }
        else
        {
            // Если экземпляр уже существует, значит, этот текущий объект - дубликат.
            // Уничтожаем этот дубликат.
            Destroy(gameObject);
        }
    }
}