using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthImprove : ImprovedParameters
{
    private float _currentHealthBonus = 0;
    private float _healthBonus = 10;

    public float HealthBonus => _currentHealthBonus;

    protected override void UpgradeParameter()
    {
        _currentHealthBonus += _healthBonus;
    }
}
