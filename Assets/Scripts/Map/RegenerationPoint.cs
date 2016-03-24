using UnityEngine;

public class RegenerationPoint : MonoBehaviour
{
    private CharacterTypeController typeController;

    void Awake()
    {
        typeController = GetComponent<CharacterTypeController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        var characterType = collider.gameObject.GetComponent<CharacterTypeController>();

        if (characterType != null && characterType.EnemyType == typeController.EnemyType)
        {
            collider.gameObject.GetComponent<LifeController>().Heal();
        }
    }
}
