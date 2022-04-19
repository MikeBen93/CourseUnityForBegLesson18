using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.instance;
    }

    public void RestartGame()
    {
        _gameController.Restart();
    }
}
