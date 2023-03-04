using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    
    private MoneyManager _moneyManager;
    private Shop _shop;

    private void OnEnable()
    {
        _shop = FindObjectOfType<Shop>();
        _moneyManager = FindObjectOfType<MoneyManager>();
        _shop.GameRestarted += DestroyCoin;
    }

    private void OnDisable()
    {
        _shop.GameRestarted -= DestroyCoin;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _moneyManager.AddPlayerMoney(_value);
            DestroyCoin();
        }
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
