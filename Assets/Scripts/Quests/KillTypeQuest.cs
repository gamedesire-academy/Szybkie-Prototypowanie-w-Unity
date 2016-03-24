using System;
using UnityEngine;

class KillTypeQuest : QuestBase
{
    [SerializeField]
    private CharacterType EnemyType;
    [SerializeField]
    private int NumberToKill;

    private int RemainingToKill;

    void Awake()
    {
        RemainingToKill = NumberToKill;
        OnStart += QuestStarted;
        OnDone += QuestStoped;
    }

    void OnDestroy()
    {
        OnStart -= QuestStarted;
        OnDone -= QuestStoped;
    }

    private void QuestStarted()
    {
        MyDispatcher.AddListener(GameEvents.NOTIFY_KILL, onKilled);
    }

    private void QuestStoped()
    {
        MyDispatcher.RemoveListener(GameEvents.NOTIFY_KILL, onKilled);
        Destroy(gameObject);
    }

    private void onKilled(object e)
    {
        if ((CharacterType)e == EnemyType)
        {
            RemainingToKill -= 1;
        }
    }

    public override bool Done()
    {
        return RemainingToKill <= 0;
    }

    public override string EndConditions()
    {
        return String.Format("Kill {0}: Remaining: {1}", EnemyType, RemainingToKill);
    }
}
