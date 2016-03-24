using UnityEngine;

public class NotifyOnDeath : MonoBehaviour
{
    private LifeController lifeController;
    private CharacterType CharacterType;

    public void Start()
    {
        CharacterType = GetComponent<CharacterTypeController>().EnemyType;

        lifeController = GetComponent<LifeController>();
        lifeController.Died += NotifyKill;
    }

    public void OnDestroy()
    {
        lifeController.Died -= NotifyKill;
    }

    public void NotifyKill()
    {
        MyDispatcher.Dispatch(GameEvents.NOTIFY_KILL, CharacterType);
    }
}