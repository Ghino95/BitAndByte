using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    public void StartMenu()
    {
        UIManager.instance.ActiveLevel();
    }

    public void Return()
    {
        UIManager.instance.ActiveMainMenu();
    }

    public void OptionMenu(){
        print("Option");
    }

    public void ExitMenu()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene(button.GetComponentInChildren<Text>().text.Replace(" ", ""));
    }


}
