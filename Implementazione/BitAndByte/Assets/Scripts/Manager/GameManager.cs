using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance
    {
        get;
        private set;
    }

    private bool HaveKey;

    public GameFlow scenes;


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
        EventManager.StartListening("AllPlayerExit",WinLevel);
        EventManager.StartListening("GameOver", ResetLevel);
        EventManager.StartListening("Exit", GoMenu);
    }


    private void CatchKey(){
        HaveKey = true;
    }

    private void WinLevel(){
        if(HaveKey){
            SceneManager.LoadScene(scenes.GoToNextLevel());
        }

    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(scenes.GetCurrentLevel());
    }

    private void GoMenu(){
        SceneManager.LoadScene(scenes.MainMenu());
    }




}
