using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : Bar
{
    private void OnEnable()
    {
        Player.HealthChanged += OnValueChanged;
        Slider.fillAmount = 1;
        Points.text = $"{Player.MaxHealth} / {Player.MaxHealth}";
    }

    private void OnDisable()
    {
        Player.HealthChanged -= OnValueChanged;
    }
}
