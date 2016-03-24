using UnityEngine;

public class TextHighlighterController : MonoBehaviour
{
    [SerializeField]
    private TextMesh TextMesh;
    [SerializeField]
    private float AnimationTime = 1f;
    [SerializeField]
    private Vector3 AnimationEndPositon = new Vector3(0f, 2f, 0f);

    private float actualTime;
    private Color color;

    public void SetText(string text)
    {
        TextMesh.text = text;
        color = TextMesh.color;
    }

    void Start()
    {
        Update();
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        float percent = Mathf.Clamp01(actualTime / AnimationTime);

        TextMesh.transform.localPosition = Vector3.Lerp(Vector3.zero, AnimationEndPositon, percent);
        color.a = Mathf.Sin(percent * Mathf.PI);
        TextMesh.color = color;

        if (percent >= 1)
        {
            Destroy(gameObject);
        }
    }
}

