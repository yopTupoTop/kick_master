using System.Collections;
using System.Collections.Generic;
using Money;
using UnityEngine;
using Money;
using SaveLoad;
using Sirenix.Utilities;

public class ShopManager : MonoBehaviour
{
    [HideInInspector] public string NameItem;
    [HideInInspector] public int PriceItem;

    public delegate void ReturnVoid(string nameItem, int price);

    public event ReturnVoid OnBuy;


    public ItemManager[] AllItems;

    public void Init(List<string> items)
    {
        foreach (var item in items)
        {
            Debug.Log($"{item}");
            foreach (var allItem in AllItems)
            {
                if (allItem.NameItem == item)
                {
                    allItem.TextItem.text = "Bought";
                    allItem.IsBuy = true;
                }
            }
        }
    }

    public void BuyItem()
    {
        if (MoneyManager.Instance.Count >= PriceItem)
        {
            OnBuy?.Invoke(NameItem, PriceItem);
        }
        else
        {
            Debug.Log(("Not enough money"));
        }
    }

    public void ItemIsBrought(string nameItem)
    {
        foreach (var allItem in AllItems)
        {
            if (allItem.NameItem == nameItem)
            {
                allItem.TextItem.text = "Bought";
                allItem.IsBuy = true;
            }
        }
    }
}