using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static UIManager instance
    {
        get;
        private set;
    }

    public GameObject KeyImage;
    public GameObject MenuPause;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        EventManager.StartListening("CatchKey",CatchKey);
    }

    private void CatchKey(){
        KeyImage.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
    }

    public void Restart(){
        Time.timeScale = 1;
        EventManager.TriggerEvent("GameOver");
    }

    public void Menu(){
        Time.timeScale = 1;
        EventManager.TriggerEvent("Exit");
    }

    public void OpenMenuPause()
    {
        Time.timeScale = 0;
        MenuPause.SetActive(true);
    }

}
