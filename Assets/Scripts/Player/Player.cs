using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private FixedJoystick joystick;

    [SerializeField] private float moveSpeed;

    private void FixedUpdate()
    {
       transform.Translate(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, 0, joystick.Vertical * moveSpeed * Time.fixedDeltaTime);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
    }
}
