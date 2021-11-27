using System.Collections;
using System.Collections.Generic;
using Level;
using Money;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public Player.Player Player;
    public MoneyManager MoneyManager;
    public UnityEvent OnDeath;
    void Start()
    {
        LevelManager.Spawn();
        Player.OnEnd+=PlayerOnOnEnd;
        Player.OnDie += PlayerDeath;
       
    }

    private void PlayerOnOnEnd()
    {
        MoneyManager.AddMoney(LevelManager.Count * 25);
        
    }

    private void PlayerDeath()
    {
        PlayerOnOnEnd();
        OnDeath?.Invoke();
        //Player.Death();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
