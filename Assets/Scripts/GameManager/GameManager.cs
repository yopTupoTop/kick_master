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
        
    }

    private void PlayerDeath()
    {
        PlayerOnOnEnd();
        OnDeath?.Invoke();
        //Player.Death();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Continue()
    {
        if (MoneyManager.Count >= 200)
        {
            //ContinueButton = GetComponent<Button>();
            ContinueButton.GetComponent<Button>().interactable = true;
            HealthController.HealthRecovery(health);
        }

        else
        {
            //ContinueButton = GetComponent<Button>();
            ContinueButton.GetComponent<Button>().interactable = false;
            Debug.Log("Not enough money");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
