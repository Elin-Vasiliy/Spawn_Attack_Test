using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<Weapon> Weapons;
    public Items Items;

    [SerializeField] private Player _player;

    private void Start()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Items.AddItem(Weapons[i]);
        }

        Items.OnWeaponBuy += BuyWeapon;
    }

    public void BuyWeapon(Weapon weapon)
    {
        if (_player.Money >= weapon.Price)
        {
            weapon.IsBuy = true;
            _player.GetWeapon(weapon);
            _player.Money -= weapon.Price;
        }
    }
}
