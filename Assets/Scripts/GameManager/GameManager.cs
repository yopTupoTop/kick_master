using System;
using System.Collections;
using System.Collections.Generic;
using Level;
using Money;
using SaveLoad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public Player.Player Player;
    public MoneyManager MoneyManager;
    public UnityEvent OnDeath;
    public Room nextRoomPrefab;
    public PlayerData dataPlayer;
    public ShopManager ShopManager;

    [SerializeField] private Button ContinueButton;
    private int health;
    private PlayerPrefsSLM<PlayerData> PlayerPrefsSlm;

    private void Awake()
    {
        
        dataPlayer = new PlayerData();
        PlayerPrefsSlm = new PlayerPrefsSLM<PlayerData>("DataPlayer");
        if (PlayerPrefsSlm.HasPath())
        {
            dataPlayer = PlayerPrefsSlm.Load();
        }
        else
        {
            dataPlayer.Money = 200;
        }

        foreach (var b in dataPlayer.buyItem)
        {
            Debug.Log(b);
        }
        PlayerPrefsSlm.Save(dataPlayer);
        MoneyManager.Init(dataPlayer.Money);
        ShopManager.Init(dataPlayer.buyItem);
    }

    void Start()
    {
        
        LevelManager.Spawn();
        Player.OnEnd+=PlayerOnOnEnd;
        Player.OnDie += PlayerDeath;
        MoneyManager.OnChange += BuySomething;
        ShopManager.OnBuyEvent += BuySomething;

    }

    private void PlayerOnOnEnd()
    {
        MoneyManager.AddMoney(LevelManager.Count * 25);
        Debug.Log("OnEnd");

    }

    private void PlayerDeath()
    {
        Time.timeScale = 0.01f;
        //PlayerOnOnEnd();
        OnDeath?.Invoke();
        ContinueButton.GetComponent<Button>().interactable = MoneyManager.Count >= 200;
        Debug.Log($"Death {MoneyManager.Count} >= 200 = {MoneyManager.Count >= 200}/n {ContinueButton.GetComponent<Button>().interactable}");

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        if (MoneyManager.Count >= 200)
        {
            Time.timeScale = 1f;
            ContinueButton.GetComponent<Button>().interactable = true;
            //LevelManager.Instantiate(nextRoomPrefab);
            HealthController.HealthRecovery(health);
            MoneyManager.Instance.RemoveMoney(200);
        }
    }

    public void BuySomething()
    {
        dataPlayer.Money = MoneyManager.Count;
        PlayerPrefsSlm.Save(dataPlayer);
    }

    public void BuySomething(string nameItem, int priceItem)
    {
        if (!dataPlayer.buyItem.Contains(nameItem))
        {
            dataPlayer.buyItem.Add(nameItem);
            MoneyManager.Instance.RemoveMoney(priceItem);
        }
        
        ShopManager.ItemIsBrought(nameItem);
        
        PlayerPrefsSlm.Save(dataPlayer);
    }

    private void OnDestroy()
    {
        ShopManager.OnBuyEvent -= BuySomething;
    }
}
