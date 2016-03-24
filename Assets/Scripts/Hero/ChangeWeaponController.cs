using UnityEngine;

public class ChangeWeaponController : MonoBehaviour
{
    private CharacterWeapons CharacterWeapons;

    void Awake()
    {
        CharacterWeapons = GetComponent<CharacterWeapons>();

        MyDispatcher.AddListener(GameEvents.CHANGE_WEAPON, OnChangeWeapon);
        MyDispatcher.AddListener(GameEvents.CHANGE_ARMORY, OnChangeArmor);
    }

    public void OnDestroy()
    {
        MyDispatcher.RemoveListener(GameEvents.CHANGE_WEAPON, OnChangeWeapon);
        MyDispatcher.RemoveListener(GameEvents.CHANGE_ARMORY, OnChangeArmor);
    }

    private void OnChangeWeapon(object e)
    {
        Weapon weapon = (Weapon)e;
        if (weapon > CharacterWeapons.CurrentWeapon)
        {
            CharacterWeapons.CurrentWeapon = weapon;
        }
    }

    private void OnChangeArmor(object e)
    {
        Armor armor = (Armor)e;
        if (armor > CharacterWeapons.CurrentArmor)
        {
            CharacterWeapons.CurrentArmor = armor;
        }
    }
}

