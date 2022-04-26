using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private Animator _animatorController;

    private float _currentHealth;
    private bool _isDead;

    public delegate void HealthHandler(float healthRatio);
    public event HealthHandler HealthNotifier;

    public delegate void DeathHandler();
    public event DeathHandler DeathNotifier;

    public bool Dead
    {
        get { return _isDead; }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _animatorController = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        HealthNotifier?.Invoke(_currentHealth / _maxHealth);

        //play hurt animation

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public float GetHealthRatio()
    {
        if (_currentHealth < 0)
        {
            return 0;
        }

        return _currentHealth / _maxHealth;
    }

    private void Die()
    {
        _isDead = true;
        _animatorController.SetBool("Dead", true);

        StartCoroutine(EndAction());
    }

    private IEnumerator EndAction()
    {
        yield return new WaitForSeconds(2f);

        DeathNotifier?.Invoke();
    }
}

