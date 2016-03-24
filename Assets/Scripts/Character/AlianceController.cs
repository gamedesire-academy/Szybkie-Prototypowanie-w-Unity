using System.Collections.Generic;
using UnityEngine;

public class AlianceController : MonoBehaviour
{
    private CharacterTypeController CharacterTypeController;

    public void Awake()
    {
        CharacterTypeController = GetComponent<CharacterTypeController>();
    }

    [SerializeField]
    private List<CharacterType> MyEnemies;

    public CharacterType GetCharacterType()
    {
        return CharacterTypeController.EnemyType;
    }

    public bool IsMyEnemy(CharacterType other)
    {
        return MyEnemies.Contains(other);
    }

    public bool IsMyFriend(CharacterType other)
    {
        return other == CharacterTypeController.EnemyType;
    }
}