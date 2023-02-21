using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyImprove : ImprovedParameters
{
    private float _currenMoneyBonus = 1;
    private float _moneyBonus = 0.25f;

    public float MoneyBonus => _currenMoneyBonus;

    protected override void UpgradeParameter()
    {
        _currenMoneyBonus += _moneyBonus;
    }
}
