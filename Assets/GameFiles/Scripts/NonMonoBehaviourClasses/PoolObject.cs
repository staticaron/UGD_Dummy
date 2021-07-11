using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolObject
{
    public string poolObjectName;
    public GameObject poolObject;
    public List<GameObject> poolObjectVariations;
    public int poolSize;

    public void SetPoolObjectVariation()
    {
        int numberOfVariations = poolObjectVariations.Count;
        int randomVariation = UnityEngine.Random.Range(0, numberOfVariations);
        poolObject = poolObjectVariations[randomVariation];
    }

}