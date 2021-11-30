using Money;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerUI : MonoBehaviour
{

    public Text MoneyText;
    public MoneyManager MoneyManager;

    void Start()
    {
        MoneyText.text = MoneyManager.Count.ToString();
        MoneyManager.OnChange += ChangeMoneyUI;
    }

    public void ChangeMoneyUI()
    {
        MoneyText.text = MoneyManager.Count.ToString();
    }

    public void OnDestroy()
    {
        MoneyManager.OnChange -= ChangeMoneyUI;
    }
}
