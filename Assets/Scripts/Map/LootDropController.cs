using System;
using UnityEngine;

public class LootDropController : MonoBehaviour
{
    [SerializeField]
    private float DestroyAfterTime = 20f;

    public Action LootCollected;

    void Awake()
    {
        Destroy(gameObject, DestroyAfterTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LootCollected != null)
                LootCollected();

            Destroy(gameObject);
        }
    }
}

