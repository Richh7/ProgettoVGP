using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteract : MonoBehaviour
{

    public UIManager uiManager;


    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Ground":
                FindObjectOfType<Game_Manager>().Lose();
                break;
            case "New Level panel":
                uiManager.ShowNewLevelPanel();
                break;
            case "Shoot panel":
                uiManager.ShowShootPanel();
                break;
            case "Finish panel":
                uiManager.ShowFinishPanel();
                break;
        }
    }
}
