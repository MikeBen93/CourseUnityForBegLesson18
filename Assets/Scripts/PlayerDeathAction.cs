using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAction : MonoBehaviour
{
    private GameController _gameController;
    private Health _health;

    private void Start()
    {
        _gameController = GameController.instance;
        _health = GetComponent<Health>();
        _health.DeathNotifier += PlayerDeath;
    }

    private void PlayerDeath()
    {
        _gameController.EndGame();
    }
}
