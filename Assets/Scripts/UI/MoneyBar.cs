using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyPerRound;
    [SerializeField] private TMP_Text _moneyMoneyTotal;
    [SerializeField] private PlayerInventory _playerInventory;

    private void OnEnable()
    {
        _playerInventory.MoneyPerRoundChanged += OnMoneyPerRoundChanged;
        _playerInventory.MoneyTotaChanged += OnMoneyTotalChanged;
    }

    private void OnDisable()
    {
        _playerInventory.MoneyPerRoundChanged -= OnMoneyPerRoundChanged;
        _playerInventory.MoneyTotaChanged -= OnMoneyTotalChanged;
    }

    private void Start()
    {
        _moneyPerRound.text = _playerInventory.MoneyPlayer.ToString();
        _moneyMoneyTotal.text = _playerInventory.MoneyShop.ToString();
    }

    private void OnMoneyPerRoundChanged(int value)
    {
        _moneyPerRound.text = value.ToString();
    }

    private void OnMoneyTotalChanged(int value)
    {
        _moneyMoneyTotal.text = value.ToString();
    }
}
