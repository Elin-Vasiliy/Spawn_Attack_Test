using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player Player;

    private Slider _slider;

    void Start()
    {
        Player.ChangeHealth += ChangeHealth;
        _slider = GetComponentInChildren<Slider>();
        _slider.value = 1;
    }

    void Update()
    {
        
    }

    private void ChangeHealth(float currentHealth, float maxHealth)
    {
        _slider.value = currentHealth / maxHealth;
    }

    private void OnDestroy()
    {
        Player.ChangeHealth -= ChangeHealth;
    }
}
