using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pool<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> _storage = new List<T>(0);
    private List<T> _releasedStorage = new List<T>(0);
    private int _capacity = 10;

    public T Content { get; private set; }
    public int Count => _storage.Count;

    public void Init(T prefab)
    {
        Content = prefab;

        for (int i = 0; i < _capacity; i++)
        {
            T newCreature = Instantiate(prefab);
            newCreature.gameObject.SetActive(false);
            _storage.Add(newCreature);
        }
    }

    public T Release()
    {
        if (_storage.Count == 0)
            return null;

        T releaseCreature = _storage[_storage.Count - 1];
        releaseCreature.gameObject.SetActive(true);

        _storage.Remove(releaseCreature);
        _releasedStorage.Add(releaseCreature);

        return releaseCreature;
    }

    public void Storing(T storingCreature)
    {
        storingCreature.gameObject.SetActive(false);

        _releasedStorage.Remove(storingCreature);
        _storage.Add(storingCreature);
    }

    public List<T> GetReleasedStorage()
    {
        return _releasedStorage;
    }

    public bool IsRealeseResource(T landMark)
    {
        foreach (T content in _releasedStorage) 
        {
            if (content == landMark) 
            {
                return true;
            }
        }

        return false;
    }
}