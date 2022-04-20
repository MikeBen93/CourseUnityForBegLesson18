using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private LayerMask _enemyLayers;
    [SerializeField] private Animator _enemyAnimatorController;
    [SerializeField] private float _meleeAttackRange;
    [SerializeField] private float _damageAmount;
    [SerializeField] private float _attackFrequency;

    private bool _automaticAttackIsOn = false;
    private float _timeFromLastAttack = 0;
    private Health _health;
    private Health _enemyHealth;

    public LayerMask LayerToAttackValue
    {
        get
        {
            return _enemyLayers.value;
        }
    }

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (_health.Dead)
        {
            return;
        }

        if(!_automaticAttackIsOn)
        {
            return;
        }

        AutomaticAttack();
    }

    private void AutomaticAttack()
    {
        if(_timeFromLastAttack < _attackFrequency)
        {
            _timeFromLastAttack += Time.deltaTime;

            return;
        }

        _timeFromLastAttack = 0;

        _enemyAnimatorController.SetTrigger("Attack");
    }

    private void Attack()
    {
        if (_health.Dead)
        {
            return;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _meleeAttackRange, _enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            _enemyHealth = enemy.GetComponentInParent<Health>();

            if (!_enemyHealth.Dead)
            {
                _enemyHealth.TakeDamage(_damageAmount);
            }
                
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(_attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(_attackPoint.position, _meleeAttackRange);
    }

    public void SetAutomaticAttack(bool automaticAttackState)
    {
        _automaticAttackIsOn = automaticAttackState;
    }

    
}
