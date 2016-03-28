using UnityEngine;

public class RegenerationPoint : MonoBehaviour
{
    [SerializeField]
    private CharacterType type;

    void OnTriggerStay(Collider collider)
    {
        var characterType = collider.gameObject.GetComponent<CharacterTypeController>();
        var lifeController = collider.gameObject.GetComponent<LifeController>();

        if (characterType != null && lifeController != null && characterType.CharacterType == type)
        {
            lifeController.Heal();
        }
    }
}
