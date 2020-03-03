using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float Health;
    public ParticleSystem Shotgun;
    public Action<float, float> ChangeHealth;

    private float _currentHealth;
    private Animator _animator;

    void Start()
    {
        _currentHealth = Health;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shotgun.Play();
            _animator.Play("Shoot");
        }
    }

    public void Attack(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, Health);
        ChangeHealth?.Invoke(_currentHealth, Health);
        if (_currentHealth == 0)
            Destroy(gameObject);
    }
}
