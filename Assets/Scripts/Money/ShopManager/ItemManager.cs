using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ShopManager ShopManager;

    public string NameItem;
    public int PriceItem;

    public Text TextItem;

    public bool IsBuy;

    public void BuyItem()
    {
        if (!IsBuy)
        {
            ShopManager.NameItem = NameItem;
            ShopManager.PriceItem = PriceItem;

            ShopManager.BuyItem();
        }
    }
}