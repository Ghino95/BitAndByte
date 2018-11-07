using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartMenu()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OptionMenu(){
        print("Option");
    }

    public void ExitMenu()
    {
        Application.Quit();
    }


}
