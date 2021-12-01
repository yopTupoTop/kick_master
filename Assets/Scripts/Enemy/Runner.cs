using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Enemy
{
    [Header("Runner Settings"), Space(5)] public float AttackRadius;

    public GameObject Cube;
    public int Damage;

    public override void Attack()
    {
        if (Vector3.Distance(PlayerController.PlayerController.Instance.transform.position, transform.position) <= AttackRadius)
        {
            Animator.SetBool(OnAttack, true);
            Animator.SetBool(Walk, false);
        }
        else
        {
            Animator.SetBool(OnAttack, false);
            Animator.SetBool(Walk, true);
            transform.LookAt(GetYVector(PlayerController.PlayerController.Instance.transform.position, transform.position.y));
        }
    }

    public Vector3 GetYVector(Vector3 pos, float y)
    {
        return new Vector3(pos.x, y, pos.z);
    }

    public void IsAttacked()
    {
        var transform1 = Cube.transform;
        Collider[] colliders = Physics.OverlapBox(transform1.position, transform1.localScale / 2, transform1.rotation);
        foreach (Collider collider1 in colliders)
        {
            PlayerController.PlayerController player = collider1.GetComponent<PlayerController.PlayerController>();
            if (player)
            {
                Debug.Log($"Plyer {player}");
                HealthController healthController = collider1.GetComponent<HealthController>();
                if (healthController)
                    healthController.Damage(Damage);
            }
        }
    }
}