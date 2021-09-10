using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class HealPlayer : MonoBehaviour
{

    public float value = 30;


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            FindObjectOfType<HealthManager>().HealPlayer(value);
            FindObjectOfType<Game_Manager>().healthToSetActive.Add(gameObject);
            StartCoroutine(Deactivate());
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

}