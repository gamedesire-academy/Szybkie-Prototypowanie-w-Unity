using UnityEngine;

public class EndGameController : MonoBehaviour
{
    [SerializeField]
    private GameObject View;

    void Awake()
    {
        MyDispatcher.AddListener(GameEvents.END_GAME, OnEndGame);
    }

    void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.END_GAME, OnEndGame);
    }

    private void OnEndGame(object e)
    {
        Time.timeScale = 0f;
        View.SetActive(true);
    }
}
