using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseEvent : MonoBehaviour
{
    [SerializeField] private Pause pause;
    [SerializeField] private GameObject pauseCanvas;
    private void Awake()
    {
        if (pause != null)  // Проверяем, что ссылка на Pause не пуста
        {
            pause.onKeyPressed.AddListener(OnPauseGame);
            Debug.Log("Слушатель для onKeyPressed добавлен.");
        }
        else
        {
            Debug.LogError("Pause не присвоен в Inspector!");
        }
    }

    private void Start()
    {
        pauseCanvas.SetActive(false);
    }

    private void OnDestroy()
    {
        if (pause != null)  // Проверяем, что ссылка на Pause не пуста
        {
            pause.onKeyPressed.RemoveListener(OnPauseGame);
            Debug.Log("Слушатель для onKeyPressed удален.");
        }
    }

    private void OnPauseGame()
    {
        Debug.Log("Пауза активирована!");
        if (pauseCanvas != null)  // Проверяем, что ссылка на канвас не пуста
        {
            Debug.Log("PAUSE: Событие сработало!");
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Канвас включен и время остановлено.");
        }
        else
        {
            Debug.LogError("PauseCanvas не присвоен в Inspector!");
        }
    }
}
