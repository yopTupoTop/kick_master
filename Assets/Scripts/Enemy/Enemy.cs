using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public Animator Animator;
    public float Radius;
    private bool _isAttack = false;

    [SerializeField] protected string Walk;
    [SerializeField] protected string OnAttack;
    [SerializeField] protected string Throw;

    public virtual void Update()
    {
        if (Vector3.Distance(transform.position, PlayerController.PlayerController.Instance.transform.position) < Radius)
        {
            _isAttack = true;
        }

        if (_isAttack)
        {
            Attack();
        }
    }

    public abstract void Attack();
}