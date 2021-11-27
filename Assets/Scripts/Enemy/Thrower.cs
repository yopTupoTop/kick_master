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
    [OdinSerialize] public List<ThrowingObject> spawnObjects;
    public override void Attack()
    {
        if (Vector3.Distance(Player.Player.Instance.transform.position, transform.position) <= AttackRadius)
        {
            Animator.SetBool(Throw, true);
        }

    }

    public void Throwing()
    {

    }

    public UnDestroyObject GetRoomSO(List<ThrowingObject> spawnObjects)
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

   
}

[Serializable]
public class ThrowingObject
{
    public UnDestroyObject Key;
    public int Value;
}
