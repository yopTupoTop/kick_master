using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class Thrower : Enemy
{
    public Transform SpawnObject;
    public float AttackRadius;

    [OdinSerialize] public List<ThrowingObject> SpawnObjects;

    //[SerializeField] public UnDestroyObject ThrowingObject;
    public float Force;

    public override void Attack()
    {
        if (Vector3.Distance(PlayerController.PlayerController.Instance.transform.position, transform.position) <= AttackRadius)
        {
            Animator.SetBool(Throw, true);
        }
    }

    public override void Update()
    {
        transform.LookAt(GetZVector(PlayerController.PlayerController.Instance.transform.position, transform.position.y));
        base.Update();
    }

    public Vector3 GetZVector(Vector3 pos, float y)
    {
        return new Vector3(pos.x, y, pos.z);
    }

    public void Throwing()
    {
        Spawn((PlayerController.PlayerController.Instance.transform.position - SpawnObject.position).normalized);
        //Debug.DrawRay(SpawnObject.position, Player.Player.Instance.transform.position - SpawnObject.position, Color.red);
        //Debug.LogError("Test");
    }

    public UnDestroyObject GetThrowingObject(List<ThrowingObject> spawnObjects)
    {
        int maxCount = 0;
        foreach (var spawnObject in spawnObjects)
        {
            maxCount += spawnObject.Value;
        }

        int r = UnityEngine.Random.Range(0, maxCount);
        Debug.Log($"r = {r}");
        int k = 0;
        foreach (var spawnObject in spawnObjects)
        {
            k += spawnObject.Value;
            if (r <= k)
            {
                Debug.Log($"Key = {spawnObject.Key}");

                return spawnObject.Key;
            }
        }

        Debug.LogError($"Key not found");

        return null;
    }

    private void Spawn(Vector3 force)
    {
        UnDestroyObject throwing = GetThrowingObject(SpawnObjects);
        UnDestroyObject obj = Instantiate(throwing, SpawnObject.position, Quaternion.identity);
        obj.Kick(Force * force);
    }
}

[Serializable]
public class ThrowingObject
{
    public UnDestroyObject Key;
    public int Value;
}