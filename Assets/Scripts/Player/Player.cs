using System;
using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

namespace Player
{
    public delegate void ReturnVoid();
    public class Player : MonoBehaviour
    {
        private static Player _instance;
        public static Player Instance => _instance;
        public event ReturnVoid OnEnd;
        public event ReturnVoid OnDie;
        public HealthController healthController;

        [Header("Force")]
        public Transform pointToForce;
        public float Force;
        [Header("Player"), Space(5)]
        public Joystick Joystick;
        public float MoveSpeed = 2;
        public Rigidbody Rigidbody;
        public GameObject cube;
        [Header("Animation"), Space(5)] 
        public Animator LegAnim;
        
        private bool isMove;

        private void Awake()
        {
            _instance = this;
            healthController.OnDead.AddListener(Death);
        }

        public void EndGame()
        {
            OnEnd?.Invoke();
        }
        void Update()
        {
            if (Joystick.Vertical == 0 && Joystick.Horizontal == 0)
            {
                if (isMove)
                {
                    Kick();
                    isMove = false;
                }
            }
            else
            {
                isMove = true;
                Rigidbody.velocity = GetYVector(transform.forward * (Joystick.Vertical * MoveSpeed)  +
                                      transform.right * (Joystick.Horizontal * MoveSpeed), Rigidbody.velocity.y);
            }
        }
        void Kick()
        {
            LegAnim.SetTrigger("Kick");
            var transform1 = cube.transform;
            Collider[] colliders = Physics.OverlapBox(transform1.position, transform1.localScale / 2, transform1.rotation);
            foreach (Collider collider1 in colliders)
            {
                SpawnObject spawnObject = collider1.GetComponent<SpawnObject>();
                if (spawnObject)
                {
                    spawnObject.Kick(transform.forward * (Force * Vector3.Distance(pointToForce.position, collider1.transform.position)));
                }
            }
        }

        public void Death()
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