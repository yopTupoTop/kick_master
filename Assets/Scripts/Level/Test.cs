using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    /* [SerializeField]
     public Dictionary<RoomSO, int> rooms;
    */
   
    [SerializeField]
    public List<Data> datas;
    [System.Serializable] public class Data
    {
        public int id;
        public RoomSO room;
    }

    void SpawnObjects()
    {
        for (int i = 0; i < datas.Count; i++)
        {
            var a = Instantiate(datas[i].room.roomPrefab, new Vector3(0,0,i), Quaternion.identity);
        }
    }

    private void Start()
    {
        SpawnObjects();
    }
}
