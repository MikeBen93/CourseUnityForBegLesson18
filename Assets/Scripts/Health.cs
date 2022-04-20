using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private Animator _animatorController;

    private float _currentHealth;
    private bool _isDead;
    private GameController _gameController;

    public bool Dead
    {
        get { return _isDead; }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _gameController = GameController.instance;
        _animatorController = GetComponent<Animator>();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;

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

        if (gameObject.CompareTag("Player"))
        {
            _gameController.EndGame();
        }

        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}

