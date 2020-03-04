using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    public event UnityAction<Weapon> OnButtonClick;

    [HideInInspector] public Weapon Weapon;
    [Header("Item")]
    public TMP_Text Label, Price;
    public Image Icon;
    public Button Button;


    private void Start()
    {
        Button.onClick.AddListener(() => OnButtonClick?.Invoke(Weapon));
        Button.onClick.AddListener(() => CheckWeaponState());

        Label.text = Weapon.Label;
        Price.text = Weapon.Price.ToString();
        Icon.sprite = Weapon.Icon;
    }

    private void CheckWeaponState()
    {
        if (Weapon.IsBuy)
        {
            Button.interactable = false;
        }
    }
}
