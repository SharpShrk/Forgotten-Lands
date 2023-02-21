using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpImprove : ImprovedParameters
{
    private float _currenExpBonus = 1;
    private float _expBonus = 0.25f;

    public float ExpBonus => _currenExpBonus;

    protected override void UpgradeParameter()
    {
        _currenExpBonus += _expBonus;
    }
}
