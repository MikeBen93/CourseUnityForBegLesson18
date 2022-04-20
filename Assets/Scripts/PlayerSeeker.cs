using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSeeker : MonoBehaviour
{
    [SerializeField] private Attacking _attacking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetMaskOfCollsion(collision) == _attacking.LayerToAttackValue)
        {
            _attacking.SetAutomaticAttack(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GetMaskOfCollsion(collision) == _attacking.LayerToAttackValue)
        {
            _attacking.SetAutomaticAttack(false);
        }
    }

    private int GetMaskOfCollsion(Collider2D inputCollision)
    {
        var gameObjectLayer = inputCollision.gameObject.layer;

        var layername = LayerMask.LayerToName(gameObjectLayer);

        return LayerMask.GetMask(layername);
    }
}
