using UnityEngine;

public class ChangeAliancesOnDone : MonoBehaviour
{
    [SerializeField]
    private QuestBase Quest;
    [SerializeField]
    private DeclarateWarData DeclarateWarData;

    void Awake()
    {
        Quest.OnDone += OnDone;
    }

    void OnDestroy()
    {
        Quest.OnDone -= OnDone;
    }

    private void OnDone()
    {
        MyDispatcher.Dispatch(GameEvents.DECLARE_WAR, DeclarateWarData);
    }
}
