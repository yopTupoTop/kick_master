using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RoomSO", order = 1)]
public class RoomSO : ScriptableObject
{
    public static GameObject roomPrefab;


    /*public static Dictionary<RoomSO, int> rooms = new Dictionary<RoomSO, int>
        {
            { new RoomSO(RoomType.FirstRoom), 1 },
            { new RoomSO(RoomType.SecondRoom), 2 },
            { new RoomSO(RoomType.ThirdRoom), 3 },
            { new RoomSO(RoomType.FourthRoom), 4 },
            { new RoomSO(RoomType.FifthRoom), 5 }
        };
    */
    private void Awake()
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

}
