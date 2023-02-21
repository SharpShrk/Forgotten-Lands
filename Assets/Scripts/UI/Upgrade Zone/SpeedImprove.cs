using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedImprove : ImprovedParameters
{
    private float _currenSpeedBonus = 0;
    private float _speedBonus = 0.5f;

    public float SpeedBonus => _currenSpeedBonus;

    protected override void UpgradeParameter()
    {
        _currenSpeedBonus += _speedBonus;
    }
}
