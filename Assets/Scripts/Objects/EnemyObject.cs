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
        [Range(0,1f)]public float MinForce, MaxForce;
        public float PrefixForse = 0.5f;

        private void Awake()
        {
            foreach (Rigidbody rig in RagdollController.Rigidbodies)
            {
                rig.GetComponent<SpawnObject>().isEnable = false;
            }
        }

        public override void Kick(Vector3 force)
        {
            Debug.Log("Kick");
            RagdollController.Enable();
            Animator.enabled = false;
            CharacterController.enabled = false;
            foreach (Rigidbody rig in RagdollController.Rigidbodies)
            {
                rig.AddForce(force * (Random.Range(MinForce, MaxForce) * PrefixForse));
                rig.GetComponent<SpawnObject>().isEnable = true;
            }
        }
    }
}
