using System.Collections;
using System.Collections.Generic;
using Level;
using Money;
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

    [SerializeField] private Button ContinueButton;
    private int health;

    void Start()
    {
        LevelManager.Spawn();
        Player.OnEnd+=PlayerOnOnEnd;
        Player.OnDie += PlayerDeath;
       
    }

    private void PlayerOnOnEnd()
    {
        MoneyManager.AddMoney(LevelManager.Count * 25);
        Debug.Log("OnEnd");
        
    }

    private void PlayerDeath()
    {
        //PlayerOnOnEnd();
        OnDeath?.Invoke();
        ContinueButton.GetComponent<Button>().interactable = MoneyManager.Count >= 200;
        Debug.Log($"Death {MoneyManager.Count} >= 200 = {MoneyManager.Count >= 200}/n {ContinueButton.GetComponent<Button>().interactable}");

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        
        if (MoneyManager.Count >= 200)
        {

            ContinueButton.GetComponent<Button>().interactable = true;
            //LevelManager.Instantiate(nextRoomPrefab);
            HealthController.HealthRecovery(health);

        }

    }



    void Update()
    {
        
    }
}
