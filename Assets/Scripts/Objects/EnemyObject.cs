using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    public class EnemyObject : SpawnObject
    {
        public RagdollController RagdollController;
        public CharacterController CharacterController;
        public Animator Animator;
        [Range(0, 1f)] public float MinForce, MaxForce;
        public float PrefixForse = 0.5f;
        public Vector3 Force;

        private void Awake()
        {
            foreach (Rigidbody rigidbody in RagdollController.Rigidbodies)
            {
                rigidbody.GetComponent<SpawnObject>().IsEnable = false;
            }
        }

        public override void Kick(Vector3 force)
        {
            Debug.Log("Kick");
            RagdollController.Enable();
            Animator.enabled = false;
            CharacterController.enabled = false;
            foreach (Rigidbody rigidbody in RagdollController.Rigidbodies)
            {
                rigidbody.AddForce(force * (Random.Range(MinForce, MaxForce) * PrefixForse));
                rigidbody.GetComponent<SpawnObject>().IsEnable = true;
            }
        }

        public void EnemyDie()
        {
            Kick(Force);
        }
    }
}