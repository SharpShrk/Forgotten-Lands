using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private MoneyImprove _moneyImprove;

    private Player _player;
    private float _moneyBonus;

    public int MoneyPlayer { get; private set; }
    public int MoneyShop { get; private set; }

    public event UnityAction<int> MoneyPerRoundChanged;
    public event UnityAction<int> MoneyTotaChanged;

    private void OnEnable()
    {
        MoneyPlayer = 0;
        MoneyShop = 0;
        _player = GetComponent<Player>();
        _player.GameOver += AddTotalMoney;
    }

    private void OnDisable()
    {
        _player.GameOver -= AddTotalMoney;
    }

    public void AddMoneyInsideRound(int money)
    {
        MoneyPlayer += money;
        MoneyPerRoundChanged?.Invoke(MoneyPlayer);
    }

    public void SubtractTotalMoney(int money)
    {
        MoneyShop -= money;
        MoneyTotaChanged?.Invoke(MoneyShop);
    }

    private void AddTotalMoney()
    {
        _moneyBonus = 0;
        _moneyBonus = MoneyPlayer * _moneyImprove.MoneyBonus;
        MoneyShop += (int)_moneyBonus;
        MoneyPlayer = 0;
        MoneyPerRoundChanged?.Invoke(MoneyPlayer);
        MoneyTotaChanged?.Invoke(MoneyShop);
    }
}
