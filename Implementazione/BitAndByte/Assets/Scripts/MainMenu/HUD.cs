using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject MenuPause;

    private void Awake()
    {
        EventManager.StartListening("Pause", OpenMenuPause);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("Pause", OpenMenuPause);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
        EventManager.TriggerEvent("ResumePlayer");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent("GameOver");
    }

    public void Menu()
    {
        Time.timeScale = 1;
        EventManager.TriggerEvent("Exit");
    }

    public void OpenMenuPause()
    {
        Time.timeScale = 0;
        MenuPause.SetActive(true);
    }

}
