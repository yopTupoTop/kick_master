using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public ShopManager shopManager;

    public string nameItem;
    public int priceItem;

    public Text textItem;

    public bool isBuy;

    public void BuyItem()
    {
        if (!isBuy)
        {
            shopManager.nameItem = nameItem;
            shopManager.priceItem = priceItem;

            shopManager.BuyItem();
        }
    }
}
