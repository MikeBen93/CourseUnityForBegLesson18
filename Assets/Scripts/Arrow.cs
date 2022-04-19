using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _arrowDamage = 10.0f;
    private float _arrowSpeed;
    private Rigidbody2D _arrowRG;
    private void Awake()
    {
        _arrowRG = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponentInParent<Health>().TakeDamage(_arrowDamage);
        }
        Destroy(gameObject);
    }

    public void SetArrowSpeed(float speed)
    {
        _arrowSpeed = speed;
        _arrowRG.velocity = new Vector2(_arrowSpeed, 0);

    }
}
