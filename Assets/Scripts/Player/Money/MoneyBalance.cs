using UnityEngine;
using UnityEngine.Events;

public abstract class MoneyBalance : MonoBehaviour
{
    protected int balance;

    public int Balance => balance;

    public event UnityAction<int> BalanceChanged;

    private void Start()
    {
        balance = 0;
        BalanceChanged?.Invoke(balance);
    }

    public void AddMoney(int amount)
    {
        balance += amount;
        BalanceChanged?.Invoke(balance);
    }

    public void SubtractMoney(int amount)
    {
        balance -= amount;
        BalanceChanged?.Invoke(balance);
    }
}
