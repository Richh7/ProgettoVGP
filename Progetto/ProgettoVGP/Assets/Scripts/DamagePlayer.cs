using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public float value = 30;
    public float valueOnStay = 10;
    public float elapsedTime = 0;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<HealthManager>().DamagePlayer(value);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (elapsedTime >= 1)
            {
                FindObjectOfType<HealthManager>().DamagePlayer(valueOnStay);
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        elapsedTime = 0;
    }
}
