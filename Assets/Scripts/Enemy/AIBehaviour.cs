using UnityEngine;

public abstract class AIBehaviour : MonoBehaviour
{
    public abstract bool CanPerform();
    public abstract void Perform();
}
