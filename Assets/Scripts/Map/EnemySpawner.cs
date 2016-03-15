using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn = null;

    [SerializeField]
    private float cooldown = 3f;

    [SerializeField]
    private int numberOfEnemiesToSpawn = 2;

    private float remainingCooldown;

    private List<GameObject> spawnedGameObjects = new List<GameObject>();

    public void Start()
    {
        remainingCooldown = cooldown;
    }

    public void Update()
    {
        spawnedGameObjects = spawnedGameObjects.Where(x => x != null).ToList();

        if (spawnedGameObjects.Count < numberOfEnemiesToSpawn)
        {
            if (remainingCooldown > 0)
            {
                remainingCooldown -= Time.deltaTime;
            }
            else
            {
                if (prefabToSpawn != null)
                {
                    var spawnedGameObject = GameObject.Instantiate(prefabToSpawn);
                    spawnedGameObject.transform.position = this.transform.position;
                    spawnedGameObjects.Add(spawnedGameObject);
                    remainingCooldown = cooldown;
                }
            }
        }
    }
}