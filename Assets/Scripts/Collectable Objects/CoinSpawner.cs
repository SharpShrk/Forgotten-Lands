using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;

    public void SpawnCoin(Vector3 position)
    {
        GameObject coin = Instantiate(_coinPrefab, position, Quaternion.identity);
    }
}
