using System.Collections.Generic;
using UnityEngine;

public class AllianceManager : MonoBehaviour
{
    private Dictionary<CharacterType, List<CharacterType>> Relations = new Dictionary<CharacterType, List<CharacterType>>();

    public void Awake()
    {
        MyDispatcher.AddListener(GameEvents.DECLARE_WAR, onDeclareWar);
    }

    void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.DECLARE_WAR, onDeclareWar);
    }

    private void onDeclareWar(object e)
    {
        DeclarateWarData data = (DeclarateWarData)e;
        if(!Relations.ContainsKey(data.Agressor))
        {
            Relations.Add(data.Agressor, new List<CharacterType>());
        }

        Relations[data.Agressor].Add(data.Target);
    }

    public List<CharacterType> GetEnemiesFor(CharacterType type)
    {
        if(Relations.ContainsKey(type))
        {
            return Relations[type];
        }

        return null;
    }
}

