using System.Collections;
using System.Collections.Generic;
using Level;
using Money;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelManager LevelManager;
    public Player.Player Player;
    public MoneyManager MoneyManager;
    void Start()
    {
        LevelManager.Spawn();
        Player.OnEnd+=PlayerOnOnEnd;
    }

    private void PlayerOnOnEnd()
    {
        MoneyManager.AddMoney(LevelManager.Count * 25);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
