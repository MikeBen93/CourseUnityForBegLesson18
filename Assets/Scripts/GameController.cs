using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector]
    public static GameController instance;

    [SerializeField] private GameObject _endGameWindow;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameController in scene");
            return;
        }
        instance = this;
    }

    public void EndGame()
    {
        Time.timeScale = 0.0f;
        _endGameWindow.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}