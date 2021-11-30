using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public List<Rigidbody> Rigidbodies;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        foreach (Rigidbody rigidbody1 in Rigidbodies)
        {
            rigidbody1.isKinematic = false;
        }
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody1 in Rigidbodies)
        {
            rigidbody1.isKinematic = true;
        }
    }
}
