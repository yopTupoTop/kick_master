using UnityEngine;

namespace Objects
{
    public abstract class SpawnObject : MonoBehaviour
    {
        public bool isEnable = true;
        public abstract void Kick(Vector3 force);
    }
}
