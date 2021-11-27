using System;
using UnityEngine;
using UnityEngine.UI;

namespace Money
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private Text _moneyText;
        private static MoneyManager _instance;
        public static MoneyManager Instance => _instance;
        private int _count = 0;

        private void Start()
        {
            _moneyText.text = _count.ToString();
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
        private void Awake()
        {
            _instance = this;
        }

        public void AddMoney(int count)
        {

            Debug.Log("ADD MONEY");
            Count += count;
        }
        public int GetMoney(int count)
        {
            return _count;
        }
        public bool CheckMoney(int count)
        {
            return count >= Count;
        }
        public void RemoveMoney(int count)
        {
            Count -= count;
        }
    }
}
