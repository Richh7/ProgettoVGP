using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PortalActivator : MonoBehaviour
{
    public GameObject portal;
    public float timeToHoldPosition = 5f;
    public bool portalActivated = false;
    public Text timeLeft;
    public Material blueColor;
    
    public float elapsedTime = 0f;

    private Game_Manager gameManager;
    private UIManager uiManager;
    private BoxCollider tutorialCollider1;
    private BoxCollider tutorialCollider2;
    private bool looping;

    private void Start()
    {
        gameManager = GameObject.Find("Game Logic").GetComponent<Game_Manager>();
        uiManager = GameObject.Find("Game Logic").GetComponent<UIManager>();
        if (gameManager.current == 0) {
            tutorialCollider1 = GameObject.Find("Tutorial Collider 1").GetComponent<BoxCollider>();
            tutorialCollider2 = GameObject.Find("Tutorial Collider 2").GetComponent<BoxCollider>();
        }
        looping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elapsedTime += Time.deltaTime;
        }
        if (gameManager.current == 0)
        {
            uiManager.CloseNewLevelPanel();
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            return;
        }
        if (other.CompareTag("Player"))
        {
            if (!((int)(timeToHoldPosition - elapsedTime + 1) < 0)) {
                timeLeft.text = "" + (int)(timeToHoldPosition - elapsedTime + 1);
            }
            if (((int)(timeToHoldPosition - elapsedTime + 1) == 0))
            {
                timeLeft.text = "";
            }
            if (elapsedTime >= timeToHoldPosition && !looping)
            {
                Debug.Log("Portale attivato!");
                portalActivated = true;
                MeshRenderer[] meshes = portal.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer mR in meshes)
                {
                    if (mR.CompareTag("Color"))
                    {
                        mR.material = blueColor;
                    }
                }
                if (gameManager.current == 0)
                {
                    tutorialCollider1.isTrigger = true;
                    tutorialCollider2.isTrigger = true;
                }
                portal.GetComponent<BoxCollider>().isTrigger = true;
                GetComponent<AudioSource>().Play();
                looping = true;
                gameManager.portalActivator = this;
            } else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        timeLeft.text = "";
        elapsedTime = 0;
        looping = false;
    }
}
