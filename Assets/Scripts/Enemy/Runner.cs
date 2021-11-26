using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : Enemy
{
    [Header("Runner Settings"), Space(5)]
    public float AttackRadius;
    public override void Attack()
    {
        if (Vector3.Distance(Player.Player.Instance.transform.position, transform.position) <= AttackRadius)
        {
            Animator.SetBool("Attack", true);
            Animator.SetBool("Walk", false);
        }
        else
        {
            Animator.SetBool("Attack", false);
            Animator.SetBool("Walk", true);
            transform.LookAt(GetZVector(Player.Player.Instance.transform.position, transform.position.y));
        }
    }

    public Vector3 GetZVector(Vector3 pos, float y)
    {
        return new Vector3(pos.x, y, pos.z);
    }
}
