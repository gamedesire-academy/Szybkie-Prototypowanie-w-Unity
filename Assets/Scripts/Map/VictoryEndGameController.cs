using UnityEngine;

public class VictoryEndGameController : MonoBehaviour
{
    [SerializeField]
    private GameObject View;

    void Awake()
    {
        MyDispatcher.AddListener(GameEvents.END_GAME_VICTORY, OnEndGame);
    }

    void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.END_GAME_VICTORY, OnEndGame);
    }

    private void OnEndGame(object e)
    {
        Time.timeScale = 0f;
        View.SetActive(true);
    }
}
