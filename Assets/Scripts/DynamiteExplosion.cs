using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteExplosion : MonoBehaviour
{
    [SerializeField] private PointEffector2D pointerEffect;
    [SerializeField] private GameObject explosionEffect;

    private void Awake()
    {
        pointerEffect.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        pointerEffect.enabled = true;

        yield return new WaitForSeconds(0.25f);

        gameObject.SetActive(false);

        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);

        Debug.Log("Destroy(effect);");
        Destroy(effect, 3f);
        Debug.Log("Destroy(gameObject);");
        Destroy(gameObject);
    }
}
