using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorImprove : ImprovedParameters
{
    private float _currenArmorBonus = 0;
    private float _armorBonus = 3;

    public float ArmorBonus => _currenArmorBonus;

    protected override void UpgradeParameter()
    {
        _currenArmorBonus += _armorBonus;
    }
}
