using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour[] behaviours;
    
    void Update()
    {
        foreach(var behaviour in behaviours)
        {
            if(behaviour.CanPerform())
            {
                behaviour.Perform();
                break;
            }
        }
    }
}
