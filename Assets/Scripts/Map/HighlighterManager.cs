using UnityEngine;

public class HighligtData
{
    public Vector3 Position;
    public string Text;

    public HighligtData(Vector3 Position, string Text)
    {
        this.Position = Position;
        this.Text = Text;
    }
}

public class HighlighterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject TextHighlighterPrefab;

    void Awake()
    {
        MyDispatcher.AddListener(GameEvents.CREATE_HIGHLIGHTER, OnCreateHighlighter);
    }

    void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.CREATE_HIGHLIGHTER, OnCreateHighlighter);
    }

    private void OnCreateHighlighter(object e)
    {
        HighligtData data = (HighligtData)e;

        var newHighlighter = GameObject.Instantiate(TextHighlighterPrefab);
        newHighlighter.transform.position = data.Position;
        newHighlighter.GetComponent<TextHighlighterController>().SetText(data.Text);
    }
}

