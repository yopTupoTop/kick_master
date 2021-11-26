using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player.Player>()) other.GetComponent<Player.Player>().EndGame();
    }
}
