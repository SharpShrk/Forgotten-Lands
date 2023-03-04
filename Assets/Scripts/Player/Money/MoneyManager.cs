using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private MoneyImprove _moneyImprove;    
    [SerializeField] private Player _player;
    [SerializeField] private PlayerBalance _playerBalance;
    [SerializeField] private ShopBalance _shopBalance;

    private void OnEnable()
    {
        _player.GameOver += AddShopMoney;
    }

    private void OnDisable()
    {
        _player.GameOver -= AddShopMoney;
    }

    public void AddPlayerMoney(int money)
    {
        _playerBalance.AddMoney(money);
    }

    private void AddShopMoney()
    {
        float moneyBonus = 0;
        moneyBonus = _playerBalance.Balance * _moneyImprove.MoneyBonus;
        _shopBalance.AddMoney((int)moneyBonus);
        _playerBalance.SubtractMoney((int)moneyBonus);
    }
}
