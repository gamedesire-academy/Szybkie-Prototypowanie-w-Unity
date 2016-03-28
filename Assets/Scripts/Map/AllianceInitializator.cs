using System;
using System.Collections.Generic;
using UnityEngine;

public class AllianceInitializator : MonoBehaviour
{
    [SerializeField]
    private AllianceManager AllianceManager;

    private EnemySpawner EnemySpawner;

    void Awake()
    {
        EnemySpawner = GetComponent<EnemySpawner>();
        EnemySpawner.OnCreated += OnCrated;
    }

    public void OnDestroy()
    {
        EnemySpawner.OnCreated -= OnCrated;
    }

    private void OnCrated(GameObject obj)
    {
        AlianceController controller = obj.GetComponent<AlianceController>();
        if (controller != null)
        {
            CharacterType characterType = controller.GetCharacterType();
            List<CharacterType> list = AllianceManager.GetEnemiesFor(characterType);

            if (list != null)
            {
                controller.AddEnemies(list);
            }
        }
    }
}

