using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int money;
    public Text moneyText;

    private void Start()
    {
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = money.ToString();
        PlayerPrefs.SetInt("Money", money);
    }

    private void Update()
    {
        
    }
    public void GetMoney()
    {
      
    }
}
