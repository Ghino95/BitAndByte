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
    private int CurrentScene;

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
        CurrentScene = 0;
        EventManager.StartListening("CatchKey",CatchKey);
        EventManager.StartListening("AllPlayerExit",WinLevel);
        EventManager.StartListening("GameOver", ResetLevel);
    }


    private void CatchKey(){
        HaveKey = true;
    }

    private void WinLevel(){
        if(HaveKey){
            if(CurrentScene < (scenes.NumberOfScene() - 1)){
                CurrentScene++;
                SceneManager.LoadScene(scenes.GetLevel(CurrentScene));
            }
        }

    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(scenes.GetLevel(CurrentScene));
    }

    public void GoToLevel(int scene){
        SceneManager.LoadScene(scenes.GetLevel(scene));
        CurrentScene = scene;
    }




}
