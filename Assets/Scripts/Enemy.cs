using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public int AttackDamage;
    public float AttackDelay;
    public float AttackRange;
    public float Speed;
    public float Health;
    public float ParticleDamage;
    public int Reward;
    public event UnityAction<int> OnEnemyDie;

    private Player _target;
    private float _lastAttackTime;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        AttackRange = Random.Range(AttackRange - 0.5f, AttackRange + 0.5f);
    }

    void Update()
    {
        if (_target == null)
            return;

        if (Vector2.Distance(transform.position, _target.transform.position) <= AttackRange)
        {
            if (_lastAttackTime <= 0)
            {
                _animator.Play("Attack");
                _lastAttackTime = AttackDelay;
                _target.Attack(AttackDamage);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, Speed * Time.deltaTime);
        }

        _lastAttackTime -= Time.deltaTime;
    }

    public void SetTarget(Player target)
    {
        _target = target;
    }

    private void OnParticleCollision(GameObject other)
    {
        Health -= ParticleDamage;
        if (Health <= 0)
        {
            OnEnemyDie?.Invoke(Reward);
            Destroy(gameObject);
        }
    }
}
