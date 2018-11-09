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
            EventManager.StartListening("CatchKey", CatchKey);
            EventManager.StartListening("AllPlayerExit", WinLevel);
            EventManager.StartListening("GameOver", ResetLevel);
            EventManager.StartListening("Exit", GoMenu);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CatchKey(){
        HaveKey = true;
    }

    private void WinLevel(){
        if(HaveKey){
            SceneManager.LoadScene(scenes.GoToNextLevel(SceneManager.GetActiveScene().name));
        }

    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(scenes.GetCurrentLevel(SceneManager.GetActiveScene().name));
    }

    private void GoMenu(){
        SceneManager.LoadScene(scenes.MainMenu());
    }





}
