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
        CustomDictionaryLevel temp = scenes.GetCurrentLevel(SceneManager.GetActiveScene().name);
        SoundManager.instance.StartBackgroundMusic(temp.Audio);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            EventManager.StartListening("CatchKey", CatchKey);
            EventManager.StartListening("AllPlayerExit", WinLevel);
            EventManager.StartListening("Exit", GoMenu);
            EventManager.StartListening("DecatchKey", DecatchKey);
            EventManager.StartListening("ResetLevel", ResetLevel);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CatchKey(){
        HaveKey = true;
    }

    private void DecatchKey()
    {
        HaveKey = false;
    }

    private void WinLevel(){
        if(HaveKey){
            HaveKey = false;
            CustomDictionaryLevel temp = scenes.GoToNextLevel(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(temp.Level);
            //SoundManager.instance.StartBackgroundMusic(temp.Audio);
        }
    }

    private void ResetLevel()
    {
        HaveKey = false;
        CustomDictionaryLevel temp = scenes.GetCurrentLevel(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(temp.Level);
        //SoundManager.instance.StartBackgroundMusic(temp.Audio);
    }

    private void GoMenu(){
        HaveKey = false;
        CustomDictionaryLevel temp = scenes.MainMenu();
        SceneManager.LoadScene(temp.Level);
        //SoundManager.instance.StartBackgroundMusic(temp.Audio);
    }





}
