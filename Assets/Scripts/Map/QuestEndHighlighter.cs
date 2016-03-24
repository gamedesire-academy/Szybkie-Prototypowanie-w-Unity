using UnityEngine;

class QuestEndHighlighter : MonoBehaviour
{
    [SerializeField]
    private QuestBase QuestBase;
    [SerializeField]
    private string textToDisplay = "Quest Completed";

    void Awake()
    {
        QuestBase.OnDone += onDone;
    }

    void OnDestroy()
    {
        QuestBase.OnDone -= onDone;
    }

    private void onDone()
    {
        MyDispatcher.Dispatch(GameEvents.CREATE_HIGHLIGHTER, new HighligtData(transform.position, textToDisplay));
    }
}
