using System.Collections.Generic;
using UnityEngine;

public class AlianceController : MonoBehaviour
{
    private CharacterTypeController CharacterTypeController;

    [SerializeField]
    private List<CharacterType> MyEnemies;

    public void Awake()
    {
        CharacterTypeController = GetComponent<CharacterTypeController>();
        MyDispatcher.AddListener(GameEvents.DECLARE_WAR, onDeclareWar);
    }

    void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.DECLARE_WAR, onDeclareWar);
    }

    private void onDeclareWar(object e)
    {
        DeclarateWarData types = (DeclarateWarData)e;
        if (types.Agressor == CharacterTypeController.CharacterType)
        {
            if (!MyEnemies.Contains(types.Target))
            {
                MyEnemies.Add(types.Target);
            }
        }
    }

    public void AddEnemies(List<CharacterType> enemies)
    {
        foreach(CharacterType t in enemies)
        {
            if (!MyEnemies.Contains(t))
            {
                MyEnemies.Add(t);
            }
        }
    }

    public CharacterType GetCharacterType()
    {
        return CharacterTypeController.CharacterType;
    }

    public bool IsMyEnemy(CharacterType other)
    {
        return MyEnemies.Contains(other);
    }

    public bool IsMyFriend(CharacterType other)
    {
        return other == CharacterTypeController.CharacterType;
    }
}