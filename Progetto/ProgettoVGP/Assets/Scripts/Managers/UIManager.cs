using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour
{

    public GameObject losePanel;
    public GameObject winPanel;
    public GameObject menuPanel;
    public GameObject pausePanel;
    public GameObject welcomePanel;
    public GameObject movingPanel;
    public GameObject newLevelPanel;
    public GameObject shootPanel;
    public GameObject finishPanel;
    public GameObject player;
    public Image healthBar;
    public Text textFPS;
    public AudioSource track;
    public Slider slider;
    public Text currLevel;
    private HealthManager healthManager;
    
    private bool isPaused;
    private int avgFrameRate;
    private float currentFPS;


    // Start is called before the first frame update
    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
        isPaused = false;
        currentFPS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = healthManager.currentHP / healthManager.maxHP;
        if (player.GetComponentInChildren<FirstPersonController>().enabled)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        currentFPS = (int) (1f / Time.unscaledDeltaTime);
        avgFrameRate = (int) currentFPS;
        textFPS.text = "" + avgFrameRate + " FPS";
    }

    public void Resume()
    {
        HideAndLockCursor();
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        ShowAndUnlockCursor();
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(true);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void ShowWelcomePanel()
    {
        welcomePanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowMenuPanel()
    {
        menuPanel.SetActive(true);
    }

    public void CloseMovingPanel()
    {
        movingPanel.SetActive(false);
    }

    public void ShowNewLevelPanel()
    {
        newLevelPanel.SetActive(true);
    }

    public void CloseNewLevelPanel()
    {
        newLevelPanel.SetActive(false);
    }

    public void ShowShootPanel()
    {
        shootPanel.SetActive(true);
    }

    public void CloseShootPanel()
    {
        shootPanel.SetActive(false);
    }

    public void ShowFinishPanel()
    {
        finishPanel.SetActive(true);
    }

    public void CloseFinishPanel()
    {
        finishPanel.SetActive(false);
    }

    public void HideAndLockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ShowAndUnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void UpdateVolume()
    {
        track.volume = slider.value;
    }
}
