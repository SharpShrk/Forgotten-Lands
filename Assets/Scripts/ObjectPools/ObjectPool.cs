using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour 
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private int _count;
    [SerializeField] private Transform _parent;

    private List<GameObject> _pool;

    private void Start()
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < _count; i++)
        {
            GameObject obj = _prefabs[Random.Range(0, _prefabs.Length)];
            obj = Instantiate(obj);
            obj.SetActive(false);
            obj.transform.SetParent(_parent, false);

            _pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        if (_pool.Count == 0)
        {
            GameObject obj = _prefabs[Random.Range(0, _prefabs.Length)];
            obj = Instantiate(obj);
            obj.transform.SetParent(_parent, false);

            _pool.Add(obj);
        }

        GameObject pooledObject = _pool[0];
        _pool.RemoveAt(0);

        if (!pooledObject.activeSelf)
        {
            pooledObject.SetActive(true);
        }

        return pooledObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Insert(0, obj);        
    }

    public void DeactivateAllObjects()
    {
        foreach(GameObject obj in _pool)
        {
            obj.SetActive(false);
        }
    }
}
