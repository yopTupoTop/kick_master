using System;
using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace PlayerController
{
    public delegate void ReturnVoid();

    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _instance;
        public static PlayerController Instance => _instance;
        public event ReturnVoid OnEnd;
        public event ReturnVoid OnDie;
        public HealthController HealthController;

        [Header("Force")] public Transform PointToForce;
        public float Force;
        [Header("Player"), Space(5)] public Joystick Joystick;
        public float MoveSpeed = 2;
        public Rigidbody Rigidbody;
        public GameObject Cube;
        [Header("Animation"), Space(5)] public Animator LegAnim;

        private bool _isMove;

        private void Awake()
        {
            _instance = this;
            HealthController.OnDead.AddListener(Die);
        }

        public void EndGame()
        {
            OnEnd?.Invoke();
        }

        void Update()
        {
            if (Joystick.Vertical == 0 && Joystick.Horizontal == 0)
            {
                if (_isMove)
                {
                    Kick();
                    _isMove = false;
                }
            }
            else
            {
                _isMove = true;
                Rigidbody.velocity = GetYVector(transform.forward * (Joystick.Vertical * MoveSpeed) +
                                                transform.right * (Joystick.Horizontal * MoveSpeed),
                    Rigidbody.velocity.y);
            }
        }

        void Kick()
        {
            LegAnim.SetTrigger("Kick");
            var transform1 = Cube.transform;
            Collider[] colliders =
                Physics.OverlapBox(transform1.position, transform1.localScale / 2, transform1.rotation);
            foreach (Collider collider1 in colliders)
            {
                SpawnObject spawnObject = collider1.GetComponent<SpawnObject>();
                if (spawnObject)
                {
                    spawnObject.Kick(transform.forward *
                                     (Force * Vector3.Distance(PointToForce.position, collider1.transform.position)));
                }
            }
        }

        public void Die()
        {
            OnDie?.Invoke();
            Debug.Log("Dead");
        }

        public Vector3 GetYVector(Vector3 pos, float y)
        {
            return new Vector3(pos.x, y, pos.z);
        }
    }
}