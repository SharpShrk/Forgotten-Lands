using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _level;
    [SerializeField] private Button _buttonLevelUp;

    private WeaponCard _weaponCard;

    public event UnityAction<WeaponCard> WeaponLevelRaised;
    public event UnityAction WeaponLevelButtonClicked;

    private void Start()
    {
        _buttonLevelUp.onClick.AddListener(OnLevelUpButtonClick);
    }

    public void TakeCardInfo(WeaponCard weaponCard)
    {
        _icon.sprite = weaponCard.Icon;
        _label.text = weaponCard.Label;
        _description.text = weaponCard.Description;
        _level.text = weaponCard.Level.ToString();

        _weaponCard = weaponCard;
    }

    private void OnLevelUpButtonClick()
    {        
        WeaponLevelRaised?.Invoke(_weaponCard);
        WeaponLevelButtonClicked?.Invoke();
    }
}
