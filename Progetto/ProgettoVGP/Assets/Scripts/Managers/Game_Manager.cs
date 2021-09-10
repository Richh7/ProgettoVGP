using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public UIManager uiManager;
    public HealthManager healthManager;
    public GameObject player;
    public Camera playerCam;
    public Transform respawnPt;
    public GameObject[] levelsArray;
    public Material black;

    [HideInInspector]
    public List<GameObject> lightsToSetActive;
    [HideInInspector]
    public List<GameObject> healthToSetActive;
    [HideInInspector]
    public PortalActivator portalActivator;
    [HideInInspector]
    public int current = 0;


    // Start is called before the first frame update
    void Start()
    {
        lightsToSetActive = new List<GameObject>();
        healthToSetActive = new List<GameObject>();
    }

    public void NextLevel() {
        ActivateEnvironmentObjects();
        lightsToSetActive.Clear();
        levelsArray[current].SetActive(false);
        current++;
        levelsArray[current].SetActive(true);
        uiManager.currLevel.text = levelsArray[current].name;
        player.SetActive(false);
        Respawn();
        player.SetActive(true);
    }

    public void Respawn()
    {
        ActivateEnvironmentObjects();
        uiManager.HideAndLockCursor();
        player.SetActive(false);
        player.transform.position = respawnPt.position;
        if (current != 0)
        {
            player.GetComponentInChildren<Shoot>().enabled = true;
        }
        MeshRenderer[] meshes = levelsArray[current].GetComponentInChildren<SwitchLevel>().gameObject.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mR in meshes)
        {
            if (mR.CompareTag("Color"))
            {
                mR.material = black;
            }
        }
        playerCam.GetComponent<FirstPersonController>().xRot = respawnPt.transform.rotation.x;
        playerCam.GetComponent<FirstPersonController>().yRot = respawnPt.transform.rotation.y;
        healthManager.currentHP = healthManager.maxHP;
        player.SetActive(true);
        Time.timeScale = 1;
    }

    public void SimpleRespawn()
    {
        player.transform.position = respawnPt.position;
        if (current != 0)
        {
            player.GetComponentInChildren<Shoot>().enabled = true;
        }
        playerCam.transform.rotation = respawnPt.rotation;
        healthManager.currentHP = healthManager.maxHP;
        player.SetActive(true);
        Time.timeScale = 1;
    }

    public void ActivateEnvironmentObjects()
    {
        foreach (GameObject g in lightsToSetActive)
        {
            if (g.layer == 8)
            {
                g.GetComponent<CheckChild>().SetChild(true);
            }
            else 
            {
                g.SetActive(true);
            }
        }
        foreach (GameObject g in healthToSetActive)
        {
            g.SetActive(true);
        }
        if (portalActivator != null)
        {
            if (portalActivator.portalActivated == true)
            {
                portalActivator.portalActivated = false;
            }
            portalActivator.portal.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    public void Play()
    {
        levelsArray[current].SetActive(true);
        uiManager.currLevel.enabled = true;
        uiManager.currLevel.text = levelsArray[current].name;
        player.SetActive(true);
        SimpleRespawn();
        if (current == 0)
        {
            uiManager.ShowWelcomePanel();
            player.GetComponentInChildren<FirstPersonController>().enabled = false;
            player.GetComponentInChildren<Shoot>().enabled = false;
        }
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Respawn();
        player.SetActive(false);
        uiManager.ShowAndUnlockCursor();
        levelsArray[current].SetActive(false);
        uiManager.currLevel.enabled = false;
        if (current != 0)
        {
            current = 1;
        }
        levelsArray[current].SetActive(true);
    }

    public void Win()
    {
        levelsArray[current].SetActive(false);
        player.GetComponentInChildren<Shoot>().enabled = false;
        uiManager.ShowWinPanel();
        uiManager.ShowAndUnlockCursor();
        Time.timeScale = 0;
    }

    public void Lose()
    {
        player.GetComponentInChildren<Shoot>().enabled = false;
        uiManager.ShowLosePanel();
        uiManager.ShowAndUnlockCursor();
        Time.timeScale = 0;
    }

}
