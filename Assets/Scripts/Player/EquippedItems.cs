using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquippedItems : MonoBehaviour
{
    [SerializeField] private List<Weapons> _allWeapons;
    [SerializeField] private CardUI _cardUI1;
    [SerializeField] private CardUI _cardUI2;
    [SerializeField] private DarknessAura _darknessAura;
    [SerializeField] private GameObject _darknessAuraObject;

    private Weapons _currentWeapon;

    private void OnEnable()
    {
        _darknessAuraObject.SetActive(false);

        _cardUI1.WeaponLevelRaised += WeaponLevelUp;
        _cardUI2.WeaponLevelRaised += WeaponLevelUp;
        _darknessAura.WeaponEquiped += SetActiveWeapon;
    }

    private void OnDisable()
    {
        _cardUI1.WeaponLevelRaised -= WeaponLevelUp;
        _cardUI2.WeaponLevelRaised -= WeaponLevelUp;
        _darknessAura.WeaponEquiped -= SetActiveWeapon;
    }

    private void WeaponLevelUp(WeaponCard weaponCard)
    {
        foreach (var weapon in _allWeapons)
        {
            if (weapon.ID == weaponCard.ID)
            {
                _currentWeapon = weapon;
                _currentWeapon.LevelUp();
                _currentWeapon = null;
                break;
            }           
        }
    }

    private void SetActiveWeapon()
    {
        _darknessAuraObject.SetActive(true);
    }

    public void DeactivateWeapon()
    {
        _darknessAuraObject.SetActive(false);
    }
}
