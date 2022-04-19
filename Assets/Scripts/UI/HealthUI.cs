using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image _healthBarImage;
    [SerializeField] private Health _playerHealth;

    // Update is called once per frame
    void Update()
    {
        SetHealthBar();
    }

    private void SetHealthBar()
    {
        _healthBarImage.fillAmount = _playerHealth.GetHealthRatio();
    }
}
