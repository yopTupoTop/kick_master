using System;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class MoneyManager : MonoBehaviour
    {
        private static MoneyManager _instance;
        public static MoneyManager Instance => _instance;
        private int _count = 0;

        public delegate void ReturnVoid();

        public event ReturnVoid OnChange;

        public void Init(int money)
        {
            Count = money;
            _instance = this;
        }

        public int Count
        {
            get => _count;
            private set
            {
                if (value < 0) _count = 0;
                else _count = value;
            }
        }

        public void AddMoney(int count)
        {
            Count += count;
            OnChange?.Invoke();
        }

        public int GetMoney(int count)
        {
            return Count;
        }

        public bool CheckMoney(int count)
        {
            return count >= Count;
        }

        public void RemoveMoney(int count)
        {
            Count -= count;
            OnChange?.Invoke();
        }
    }
}