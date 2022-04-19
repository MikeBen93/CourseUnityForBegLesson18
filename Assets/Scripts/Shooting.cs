using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    private sbyte _bulletDirection = 1;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

        if (_playerMovement.IsFacingRight)
        {
            _bulletDirection = 1;
        }
        else
        {
            _bulletDirection = -1;
        }

        bulletGO.GetComponent<Arrow>().SetArrowSpeed(bulletSpeed * _bulletDirection);
    }
}
