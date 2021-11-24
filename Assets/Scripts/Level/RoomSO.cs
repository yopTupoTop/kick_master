using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoomSO", order = 1)]
public class RoomSO : ScriptableObject
{
    public GameObject roomPrefab;

   

   /* private void Awake()
    {
        UnityEngine.Object prefabRef = Resources.Load("FirstRoom.prefab");
        GameObject gameObjectRef = Instantiate(prefabRef) as GameObject;
        gameObjectRef.transform.parent = roomPrefab.transform;

    }

    private void OnEnable()
    {
        roomPrefab = new GameObject();
    }

    public static void RoomSpawnProbability()
    {
        UnityEngine.Object prefabRef = Resources.Load("FirstRoom");
        GameObject gameObjectRef = Instantiate(prefabRef) as GameObject;
        gameObjectRef.transform.parent = roomPrefab.transform;
    }
   */
}
