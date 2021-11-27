using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public UnityEvent OnDead;
    public int Health;
    public bool IsDead = false;

    public void Damage(int damageCount)
    {
        Health -= damageCount;

        if (Health <= 0)
        {
            OnDead?.Invoke();
            IsDead = true;
        }

    }
}
