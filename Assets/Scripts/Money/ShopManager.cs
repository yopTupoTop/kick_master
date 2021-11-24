using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private ShopManager.DataPlayer dataPlayer = new ShopManager.DataPlayer();

    [HideInInspector]
    public string nameItem;
    [HideInInspector]
    public int priceItem;

    public GameObject[] allItem;
    public class DataPlayer
    {
        public int money;

        public List<string> buyItem = new List<string>();
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("SaveGame"))
            LoadGame();
        else
        {
            dataPlayer.money = 0;
            SaveGame();
            LoadGame();
        }
    }
    private void SaveGame()
    {
        
        PlayerPrefs.SetString("SaveGame", JsonUtility.ToJson(dataPlayer));
    }

    private void LoadGame()
    {
        dataPlayer = JsonUtility.FromJson<DataPlayer>(PlayerPrefs.GetString("SaveGame"));

        for(var i = 0; i < dataPlayer.buyItem.Count; i++)
        {
            for (var j = 0; j < allItem.Length; j++)
            {
                if (allItem[j].GetComponent<ItemManager>().nameItem == dataPlayer.buyItem[i])
                {
                    allItem[j].GetComponent<ItemManager>().textItem.text = "Bought";
                    allItem[j].GetComponent<ItemManager>().isBuy = true;
                }
            }
        }
    }

    public void BuyItem()
    {
        if (dataPlayer.money >= priceItem)
        {
            dataPlayer.buyItem.Add(nameItem);
            dataPlayer.money = dataPlayer.money - priceItem;

            SaveGame();
            LoadGame();
        }
    }
}
