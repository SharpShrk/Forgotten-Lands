using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyPerRound;
    [SerializeField] private TMP_Text _moneyMoneyTotal;
    [SerializeField] private PlayerBalance _playerBalance;
    [SerializeField] private ShopBalance _shopBalance;

    private void OnEnable()
    {
        _playerBalance.BalanceChanged += OnPlayerBalanceChanged;
        _shopBalance.BalanceChanged += OnShopBalanceChanged;
    }

    private void OnDisable()
    {
        _playerBalance.BalanceChanged -= OnPlayerBalanceChanged;
        _shopBalance.BalanceChanged -= OnShopBalanceChanged;
    }

    private void Start()
    {
        _moneyPerRound.text = _playerBalance.Balance.ToString();
        _moneyMoneyTotal.text = _shopBalance.Balance.ToString();
    }

    private void OnPlayerBalanceChanged(int value)
    {
        _moneyPerRound.text = value.ToString();
    }

    private void OnShopBalanceChanged(int value)
    {
        _moneyMoneyTotal.text = value.ToString();
    }
}
