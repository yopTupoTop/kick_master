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
    public void Update()
    {
        if (Vector3.Distance(transform.position, Player.Player.Instance.transform.position) < Radius)
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
