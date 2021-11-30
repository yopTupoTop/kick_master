using System.Collections;
using System.Collections.Generic;
using Money;
using UnityEngine;
using Money;
using SaveLoad;
using Sirenix.Utilities;

public class ShopManager : MonoBehaviour
{

    [HideInInspector]
    public string nameItem;
    [HideInInspector]
    public int priceItem;
    public PlayerPrefsSLM<MoneyManager> PlayerPrefsSLM;

    public delegate void OnBuy(string nameItem, int price);

    public event OnBuy OnBuyEvent;


    public ItemManager[] allItems;

    public void Init(List<string> Items)
    {
        
        foreach (var Item in Items)
        {
            Debug.Log($"{Item}");
            foreach (var allItem in allItems)
            {
                if (allItem.nameItem == Item)
                {
                    allItem.textItem.text = "Bought";
                    allItem.isBuy = true;
                }
            }
        }
    }

    /*private void LoadGame()
    {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("SaveGame"));

        for(var i = 0; i < dataPlayer.buyItem.Count; i++)
        {
            for (var j = 0; j < allItem.Length; j++)
            {
                
               
            }
        }
    }*/

    public void BuyItem()
    {
        if (MoneyManager.Instance.Count >= priceItem)
        {
            
            OnBuyEvent?.Invoke(nameItem, priceItem);
            
        }
        else
        {
            Debug.Log(("Not enough money"));
        }
    }

    public void ItemIsBrought(string nameItem)
    {
        foreach (var allItem in allItems)
        {
            if (allItem.nameItem == nameItem)
            {
                allItem.textItem.text = "Bought";
                allItem.isBuy = true;
            }
            
        } 
    }
        
}
