using Object = UnityEngine.Object;

namespace SaveLoad
{
    public abstract class SaveLoadManager <T>
    {
        protected string _path;
        public SaveLoadManager(string path)
        {
            _path = path;
        }
        public abstract void Save(T value);
        public abstract T Load();
        public abstract bool HasPath();
    }
}

