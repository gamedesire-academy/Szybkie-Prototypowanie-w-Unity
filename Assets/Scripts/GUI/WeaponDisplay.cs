using System;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    private CharacterWeapons CharacterWeapons;

    private Text Text;

    void Awake()
    {
        Text = GetComponent<Text>();
    }

    void Update()
    {
		Text.text = String.Format("Power: {0:N2} Speed: {1:N2} Defense: {2:N2}", CharacterWeapons.CurrentWeapon.Power, CharacterWeapons.CurrentWeapon.Speed, CharacterWeapons.CurrentArmor.Defense);
    }
}
