using System.Collections.Generic;
using UnityEngine;

public class CardWiev : MonoBehaviour
{
    [SerializeField] private List<WeaponCard> _allCards;
    [SerializeField] private List<Weapons> _allWeapons;
    [SerializeField] private CardUI _card1;
    [SerializeField] private CardUI _card2;
    
    private List<Weapons> _currentWeapons;

    private void OnEnable()
    {
        _card1.WeaponLevelRaised += RemoveCardMaxLevel;
        _card2.WeaponLevelRaised += RemoveCardMaxLevel;
    }

    private void OnDisable()
    {
        _card1.WeaponLevelRaised -= RemoveCardMaxLevel;
        _card2.WeaponLevelRaised -= RemoveCardMaxLevel;
    }

    private void Awake()
    {
        _currentWeapons = _allWeapons;
    }

    public void Restart()
    {
        _currentWeapons = _allWeapons;
        RandomCardsSelection();
    }

    public void RandomCardsSelection()
    {
        List<WeaponCard> availableCards = new List<WeaponCard>();

        for (int i = 0; i < _currentWeapons.Count; i++)
        {
            for(int j = 0; j < _allCards.Count; j++)
            {
                if(_allCards[j].ID == _currentWeapons[i].ID && _allCards[j].Level == _currentWeapons[i].Level + 1)
                {
                    availableCards.Add(_allCards[j]);
                }
            }
        }

        int firstCardIndex = Random.Range(0, availableCards.Count);
        int secondCardIndex = Random.Range(0, availableCards.Count);

        if (firstCardIndex == secondCardIndex)
        {
            if(secondCardIndex == availableCards.Count)
            {
                secondCardIndex = 0;
            }
            else
            {
                secondCardIndex++;
            }
        }

        _card1.TakeCardInfo(availableCards[firstCardIndex]);
        _card2.TakeCardInfo(availableCards[secondCardIndex]);
    }

    private void RemoveCardMaxLevel(WeaponCard weaponCard)
    {
        foreach (var weapon in _currentWeapons)
        {
            if (weapon.ID == weaponCard.ID && weapon.Level == weapon.MaxLevel)
            {
                _currentWeapons.Remove(weapon);
            }
        }
        
    }
}
