using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public GameObject KeyImage;
    public GameObject MenuPause;
    public Sprite KeyCatched;

    private void Awake()
    {
        EventManager.StartListening("CatchKey", CatchKey);
        EventManager.StartListening("Pause", OpenMenuPause);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("CatchKey", CatchKey);
        EventManager.StopListening("Pause", OpenMenuPause);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
        ControllerManager.instance.ResumePlayer();
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

    private void CatchKey()
    {
        KeyImage.GetComponent<Image>().sprite = KeyCatched;

    }


}
