using System.Collections.Generic;
using Level.ScriptableObject;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Level
{
    public class LevelManager : SerializedMonoBehaviour
    {
        [Required] [OdinSerialize]public List<NextRoom> Rooms;
        public int MinCount = 2, MaxCount = 5;
        public Room StartRoom;
        public Room EndRoomPrefab;
        private List<Room> spawnedRoom = new List<Room>();
        [Required] private Room _lastRoom;// по началу здесь будет стартовая комната. Настроена через инспектор
        public int Count
        {
            private set;
            get;
        }
        [Button("Spawn")]
        public void Spawn()
        {
            _lastRoom = StartRoom;
            Count = Random.Range(MinCount, MaxCount);
            Debug.Log($"Count = {Count}");
            List<NextRoom> rooms = Rooms;
            for (int i = 0; i < Count; i++)
            {
                RoomSO roomSo = GetRoomSO(rooms);
                rooms = roomSo.NextRooms;
                this.Instantiate(roomSo.Prefab);
            }
            this.Instantiate(EndRoomPrefab);
        }
        [Button("ReSpawn")]
        public void ReSpawn()
        {
            foreach (Room room in spawnedRoom)
            {
                Destroy(room.gameObject);
            }
            spawnedRoom.Clear();
            Spawn();
        }

        public void Instantiate(Room nextRoomPrefab)
        {
            Room room = Instantiate(nextRoomPrefab, _lastRoom.NextRoomTransform.position, Quaternion.identity);
            _lastRoom = room;
            spawnedRoom.Add(_lastRoom);
        }
        public RoomSO GetRoomSO(List<NextRoom> rooms)
        {
            int maxCount = 0;
            foreach (var room in rooms)
            {
                maxCount += room.Value;
            }

            int r = Random.Range(0, maxCount);
            Debug.Log($"r = {r}");
            int k = 0;
            foreach (var room in rooms)
            {
                k += room.Value; 
                if (r <= k)
                {
                    Debug.Log($"Key = {room.Key}");

                    return room.Key;
                }
            }
            Debug.LogError($"Key not found");

            return null;
        }
    }
}
