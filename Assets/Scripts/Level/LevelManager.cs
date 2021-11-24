using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int roomCount;
    [SerializeField] private RoomSO roomPrefab;

    public int spawnProbability;

    private RoomSO startRoom;

   /* private void Start()
    {
        startRoom = Instantiate(roomPrefab);
        roomCount = Random.Range(2, 6);

        for (var i = 0; i < roomCount; i++)
        {
            spawnProbability = Random.Range(1, 6);
            RoomSO.RoomSpawnProbability();
            var room = RoomSO.roomPrefab;
            var spawnRoom = Instantiate(room, transform.position, transform.rotation);
        }
    }
    private void Update()
    {

    }
   */
}
