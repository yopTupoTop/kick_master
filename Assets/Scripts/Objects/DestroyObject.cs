using System.Collections;
using System.Collections.Generic;
using Objects;
using UnityEngine;

public class DestroyObject : SpawnObject
{
    public GameObject NormalObject;
    public GameObject DestroyedObject;
    public List<SpawnObject> Objects;

    public override void Kick(Vector3 force)
    {
        NormalObject.SetActive(false);
        DestroyedObject.SetActive(true);
        DestroyedObject.transform.position = NormalObject.transform.position;
        foreach (SpawnObject spawn in Objects)
        {
            if(isEnable) spawn.Kick(force);
        }
    }
}
