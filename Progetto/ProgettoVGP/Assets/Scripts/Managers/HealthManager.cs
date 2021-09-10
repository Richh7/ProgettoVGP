using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealthManager : MonoBehaviour
{

    public GameObject player;
    public Game_Manager gameManager;
    public float maxHP = 100;
    public float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void HealPlayer(float health)
    {
        
        if (currentHP + health >= maxHP)
        {
            currentHP = maxHP;
            Debug.Log(currentHP);
        }
        else
        {
            currentHP += health;
            Debug.Log(currentHP);
        }
    }

    public void DamagePlayer(float damage)
    {
        player.GetComponent<AudioSource>().Play();
        if (currentHP > damage)
        {
            currentHP -= damage;
            Debug.Log(currentHP);
        }
        else
        {
            gameManager.Lose();
        }
    }
}
