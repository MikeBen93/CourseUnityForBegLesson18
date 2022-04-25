using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private Health _playerHealth;

    private void Awake()
    {
        _playerHealth.HealthNotifier += SetHealthBar;
    }

    private void SetHealthBar(float ratio)
    {
        _healthBarImage.fillAmount = ratio;
    }
}
