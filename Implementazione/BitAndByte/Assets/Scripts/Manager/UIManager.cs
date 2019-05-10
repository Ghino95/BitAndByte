using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour {

    public static UIManager instance
    {
        get;
        private set;
    }
    

    public GameObject MainMenuObj;
    public GameObject MenuLevel;

    public GameObject StartMenu;
    public GameObject StartLevel;

    private void Awake()
    {
        instance = this;
        Screen.SetResolution(1920, 1080,true);
    }

    public void ActiveLevel()
    {
        MainMenuObj.SetActive(false);
        MenuLevel.SetActive(true);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(StartLevel);
    }

    public void ActiveMainMenu()
    {
        MainMenuObj.SetActive(true);
        MenuLevel.SetActive(false);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(StartMenu);
    }

}
