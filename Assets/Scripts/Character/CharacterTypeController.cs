using UnityEngine;

public enum CharacterType { PLAYER = 0, SKELETON = 1, RED_SKELETON = 2 };

public class CharacterTypeController : MonoBehaviour
{
    public CharacterType EnemyType;
}
