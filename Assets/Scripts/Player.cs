using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    public float Health;
    public ParticleSystem ShootEffect;
    public Action<float, float> ChangeHealth;
    public int Money;
    public List<Weapon> Weapons;

    private int _currentWeaponNumber = 0;
    private Weapon _currentWeapon;
    private float _currentHealth;
    private Animator _animator;

    void Start()
    {
        ChangeWeapon(Weapons[0]);
        _currentHealth = Health;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootEffect.Play();
                _animator.Play("Shoot");
            }
        }
    }

    public void Attack(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, Health);
        ChangeHealth?.Invoke(_currentHealth, Health);
        if (_currentHealth == 0)
            Destroy(gameObject);
    }

    public void GetRewardMoney(int reward)
    {
        Money += reward;
    }

    public void GetWeapon(Weapon weapon)
    {
        Weapons.Add(weapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == Weapons.Count - 1)
        {
            _currentWeaponNumber = 0;
        }
        else
        {
            _currentWeaponNumber++;
        }

        ChangeWeapon(Weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
        {
            _currentWeaponNumber = Weapons.Count - 1;
        }
        else
        {
            _currentWeaponNumber--;
        }

        ChangeWeapon(Weapons[_currentWeaponNumber]);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        ShootEffect = weapon.ShootEffect;
    }
}
