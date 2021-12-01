using UnityEngine;

namespace SaveLoad
{
    public class PlayerPrefsSLM<T> : SaveLoadManager<T>
    {
        public override void Save(T value)
        {
            PlayerPrefs.SetString(_path, JsonUtility.ToJson(value));
            Debug.Log(JsonUtility.ToJson(value));
        }

        public override T Load()
        {
            return JsonUtility.FromJson<T>(PlayerPrefs.GetString(_path));
        }

        public override bool HasPath()
        {
            return PlayerPrefs.HasKey(_path);
        }

        public PlayerPrefsSLM(string path) : base(path)
        {
        }
    }
}