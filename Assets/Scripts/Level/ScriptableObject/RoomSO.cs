using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Level.ScriptableObject
{
    [CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/RoomSettings", order = 1)]
    [Serializable] public class RoomSO : SerializedScriptableObject 
    {
        public Room Prefab; 
        [OdinSerialize] public List<NextRoom> NextRooms = new List<NextRoom>();
    }
    [Serializable]public class NextRoom
    {
        public RoomSO Key;
        public int Value;
    }
}
