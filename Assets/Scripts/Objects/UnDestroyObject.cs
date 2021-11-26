using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class UnDestroyObject : SpawnObject
{
    public Rigidbody Rigidbody;
    public float Force;

    public override void Kick(Vector3 force)
    {
        if (isEnable)
        {
            Debug.Log(name);
            Rigidbody.AddForce(force * Force);
        }
    }
}
