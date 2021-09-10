using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    public Game_Manager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (gameManager.levelsArray.Length - 1) == gameManager.current)
        {
            gameManager.Win();
        }
        else
        {
            gameManager.NextLevel();
        }
    }
}
