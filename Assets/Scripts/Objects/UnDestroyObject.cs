using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class UnDestroyObject : SpawnObject
{
    public Rigidbody Rigidbody;
    public float Force;
    public bool IsFlying;
    public float MinSpeed;
    public int Damage;

    public override void Kick(Vector3 force)
    {
        if (IsEnable)
        {
            Debug.Log(name);
            Rigidbody.AddForce(force * Force);
        }
    }

    private void Update()
    {
        IsFlying = (Rigidbody.velocity.magnitude > MinSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HealthController healthController = collision.gameObject.GetComponent<HealthController>();
        if (healthController && IsFlying)
            healthController.Damage(Damage);
    }
}