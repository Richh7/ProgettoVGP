using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{

    public GameObject playerCam;
    public UIManager uiManager;
    public float timePanels = 4f;

    private float elapsedTime;


    // Start is called before the first frame update
    private void Start()
    {
        elapsedTime = 0;
    }

    void Update()
    {
        if (uiManager.movingPanel.activeSelf && ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Space))))
        {
            uiManager.CloseMovingPanel();
        }
        if (uiManager.newLevelPanel.activeSelf)
        {
            playerCam.GetComponent<FirstPersonController>().enabled = false;
            if (elapsedTime >= timePanels)
            {
                uiManager.CloseNewLevelPanel();
                playerCam.GetComponent<FirstPersonController>().enabled = true;
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
        if (uiManager.shootPanel.activeSelf)
        {
            playerCam.GetComponent<FirstPersonController>().enabled = false;
            playerCam.GetComponent<Shoot>().enabled = false;
            if (elapsedTime >= timePanels)
            {
                uiManager.CloseShootPanel();
                ActivateShoot();
                playerCam.GetComponent<FirstPersonController>().enabled = true;
                playerCam.GetComponent<Shoot>().enabled = true;
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
        if (uiManager.finishPanel.activeSelf)
        {
            playerCam.GetComponent<FirstPersonController>().enabled = false;
            playerCam.GetComponent<Shoot>().enabled = false;
            if (elapsedTime >= timePanels)
            {
                uiManager.CloseFinishPanel();
                playerCam.GetComponent<FirstPersonController>().enabled = true;
                playerCam.GetComponent<Shoot>().enabled = true;
                elapsedTime = 0;
            }
            else
            {
                elapsedTime += Time.deltaTime;
            }
        }
    }

    private void ActivateShoot()
    {
       playerCam.GetComponent<Shoot>().enabled = true;
    }

}
