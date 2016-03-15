using UnityEngine;

public class DestroyOnDeath : MonoBehaviour
{
    private LifeController LifeController;

    public void Awake()
    {
        LifeController = GetComponent<LifeController>();
        LifeController.Died += OnDied;
    }

    public void OnDestroy()
    {
        LifeController.Died -= OnDied;
    }

    private void OnDied()
    {
        Destroy(gameObject);
    }
}
