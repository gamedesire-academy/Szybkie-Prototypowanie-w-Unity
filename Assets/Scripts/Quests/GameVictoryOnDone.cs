
using UnityEngine;

public class GameVictoryOnDone : MonoBehaviour
{
    [SerializeField]
    private QuestBase Quest;

    void Awake()
    {
        Quest.OnDone += onDone;
    }

    void OnDestroy()
    {
        Quest.OnDone -= onDone;
    }

    private void onDone()
    {
        MyDispatcher.Dispatch(GameEvents.END_GAME_VICTORY);
    }
}
