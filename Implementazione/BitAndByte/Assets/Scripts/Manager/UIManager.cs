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

}
