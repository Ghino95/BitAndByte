using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ControllerManager: MonoBehaviour
{

    public DeadzoneCamera CameraMobile;

    public static ControllerManager instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        instance = this;
        EventManager.StartListening("PausePlayer", PausePlayer);
        EventManager.StartListening("ResumePlayer", ResumePlayer);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("PausePlayer", PausePlayer);
        EventManager.StopListening("ResumePlayer", ResumePlayer);
    }

    public List<DisablePlayer> players;
    private int playerEnable = 0;



    private void Start()
    {
        foreach(DisablePlayer player in players){
            player.Disable();
        }
        players[playerEnable].Enable();
        CameraMobile.target = players[playerEnable].gameObject.GetComponent<Renderer>();
        
    }

    private void Update()
    {

        if(Input.GetButtonDown("Swap")){
            ChangePlayer();
        }
        if(Input.GetButtonDown("Pause")){
            PausePlayer();
            EventManager.TriggerEvent("Pause");
        }
    }

    private void ChangePlayer()
    {
        players[playerEnable].Disable();
        do
        {
            playerEnable = (playerEnable + 1) % players.Count;
        }while (!players[playerEnable].CompareTag("Player"));
        players[playerEnable].Enable();
        CameraMobile.target = players[playerEnable].gameObject.GetComponent<Renderer>();
    }

    public void PausePlayer(){
        players[playerEnable].Disable();
        enabled = false;
    }

    public void ResumePlayer(){
        players[playerEnable].Enable();
        enabled = true;
    }

}
