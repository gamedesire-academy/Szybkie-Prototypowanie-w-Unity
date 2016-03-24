using System;
using UnityEngine;

public class LootDropController : MonoBehaviour
{
    public Action LootCollected;

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

