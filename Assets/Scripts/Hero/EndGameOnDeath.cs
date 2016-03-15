using UnityEngine;

public class EndGameOnDeath : MonoBehaviour
{
    private LifeController LifeController;

    void Awake()
    {
        LifeController = GetComponent<LifeController>();
        LifeController.Died += OnDied;
    }

    void OnDestroy()
    {
        LifeController.Died -= OnDied;
    }

    private void OnDied()
    {
        MyDispatcher.Dispatch(GameEvents.END_GAME);
    }
}
