using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;
    
    private Shop _shop;

    private void OnEnable()
    {
        GameObject shopObject = GameObject.FindWithTag("Shop");
        _shop = shopObject.GetComponent<Shop>();
        _shop.GameRestarted += DestroyCoin;
    }

    private void OnDisable()
    {
        _shop.GameRestarted -= DestroyCoin;        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInventory>(out PlayerInventory player))
        {
            player.AddMoneyInsideRound(_value);
            Destroy(gameObject);
        }
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
