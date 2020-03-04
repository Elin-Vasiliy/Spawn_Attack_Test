using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Items : MonoBehaviour
{
    public event UnityAction<Weapon> OnWeaponBuy;

    [SerializeField] private Item _template;

    public Item AddItem(Weapon weapon)
    {
        Item item;
        item = Instantiate(_template, transform);
        item.Weapon = weapon;
        item.OnButtonClick += (X) => OnWeaponBuy?.Invoke(X);
        item.name = _template.name + (transform.childCount + 1);
        return item;
    }
}
