using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessAura : Weapons
{
    [SerializeField] private float _armorReductionValue;
    [SerializeField] private float _reductionMultiplier; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ReduceArmor(_armorReductionValue);          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ReturnArmor();
        }
    }

    public void SetArmorReductionValue()
    {
        _armorReductionValue = _level * _reductionMultiplier;
    }
}
