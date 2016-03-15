using System;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public event Action Died;

    private CharacterWeapons CharacterWeapons;
    [SerializeField]
    private float maxLife = 100f;

    public float MaxLife { get { return maxLife; } }
    private float life = 1f;
    public float Life { get { return life; } }

    void Awake()
    {
        CharacterWeapons = GetComponent<CharacterWeapons>();
        life = maxLife;
    }

    public void Heal()
    {
        life = maxLife;
    }

    public void Minus(CharacterWeapons weapon)
    {
        life -= Math.Max(0, weapon.CurrentWeapon.Power - CharacterWeapons.CurrentArmor.Defense);
        if (life <= 0f)
        {
            if (Died != null)
                Died();
        }
    }
}
