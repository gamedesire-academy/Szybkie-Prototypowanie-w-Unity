using System;
using System.Collections.Generic;
using UnityEngine;

class RandomLootDrop : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> dropPrefabs;

    private DropLootOnDeath dropLootOnDeath;

    void Awake()
    {
        dropLootOnDeath = GetComponent<DropLootOnDeath>();
        if (dropPrefabs.Count > 0)
        {
            var itemPrefab = dropPrefabs[UnityEngine.Random.Range(0, dropPrefabs.Count)];
            dropLootOnDeath.dropPrefab = itemPrefab;
        }
    }
}
