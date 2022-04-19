using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeeker : MonoBehaviour
{
    [SerializeField] private Attacking _attacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == _attacking.LayerToAttackValue)
        {
            _attacking.SetAutomaticAttack(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == _attacking.LayerToAttackValue)
        {
            Debug.Log("Lost player");
            _attacking.SetAutomaticAttack(false);
        }
    }
}
