using System;
using System.Collections;
using System.Collections.Generic;
using Level;
using Money;
using SaveLoad;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public PlayerController.PlayerController Player;
    public MoneyManager MoneyManager;
    public UnityEvent OnDeath;
    public Room NextRoomPrefab;
    public PlayerData DataPlayer;
    public ShopManager ShopManager;

    [SerializeField] private Button _continueButton;
    private int _health;
    private PlayerPrefsSLM<PlayerData> _playerPrefsSlm;

    private void Awake()
    {
        DataPlayer = new PlayerData();
        _playerPrefsSlm = new PlayerPrefsSLM<PlayerData>("DataPlayer");
        if (_playerPrefsSlm.HasPath())
        {
            DataPlayer = _playerPrefsSlm.Load();
        }
        else
        {
            DataPlayer.Money = 200;
        }

        foreach (var b in DataPlayer.BuyItem)
        {
            Debug.Log(b);
        }

        _playerPrefsSlm.Save(DataPlayer);
        MoneyManager.Init(DataPlayer.Money);
        ShopManager.Init(DataPlayer.BuyItem);
    }

    void Start()
    {
        LevelManager.Spawn();
        Player.OnEnd += PlayerOnOnEnd;
        Player.OnDie += PlayerDeath;
        MoneyManager.OnChange += BuySomething;
        ShopManager.OnBuy += BuySomething;
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
        _continueButton.GetComponent<Button>().interactable = MoneyManager.Count >= 200;
        Debug.Log(
            $"Death {MoneyManager.Count} >= 200 = {MoneyManager.Count >= 200}/n {_continueButton.GetComponent<Button>().interactable}");
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
            _continueButton.GetComponent<Button>().interactable = true;
            //LevelManager.Instantiate(nextRoomPrefab);
            HealthController.HealthRecovery(_health);
            MoneyManager.Instance.RemoveMoney(200);
        }
    }

    public void BuySomething()
    {
        DataPlayer.Money = MoneyManager.Count;
        _playerPrefsSlm.Save(DataPlayer);
    }

    public void BuySomething(string nameItem, int priceItem)
    {
        if (!DataPlayer.BuyItem.Contains(nameItem))
        {
            DataPlayer.BuyItem.Add(nameItem);
            MoneyManager.Instance.RemoveMoney(priceItem);
        }

        ShopManager.ItemIsBrought(nameItem);

        _playerPrefsSlm.Save(DataPlayer);
    }

    private void OnDestroy()
    {
        ShopManager.OnBuy -= BuySomething;
    }
}