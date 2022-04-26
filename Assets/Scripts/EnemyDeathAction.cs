using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathAction : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.DeathNotifier += EnemyDeath;
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
