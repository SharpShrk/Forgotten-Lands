using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private List<Weapons> _weapons;
    [SerializeField] private PlayerLevel _playerLevel;
    [SerializeField] private Player _player;
    [SerializeField] private CardWiev _cardWiev;
    [SerializeField] private WeaponLevelUpPanel _weaponLevelUpPanel;
    [SerializeField] private EquippedItems _equippedItems;
    [SerializeField] private ObjectPool _enemyPool;

    private void OnEnable()
    {
        _shop.GameRestarted += RestartGame;
    }

    private void OnDisable()
    {
        _shop.GameRestarted -= RestartGame;        
    }

    private void RestartGame()
    {       
        foreach (var weapon in _weapons)
        {
            weapon.Restart();
        }

        _playerLevel.Restart();
        _player.Restart();
        _weaponLevelUpPanel.OpenPanel();
        _cardWiev.Restart();
        _equippedItems.DeactivateWeapon();
        _enemyPool.DeactivateAllObjects();
    }
}
