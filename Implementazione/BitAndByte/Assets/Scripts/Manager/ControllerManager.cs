using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class ControllerManager: MonoBehaviour
{

    public DeadzoneCamera CameraMobile;
    public GameObject RuotaPersonaggi;

    public static ControllerManager instance
    {
        get;
        private set;
    }

    public List<DisablePlayer> players;
    public int playerEnable
    {
        get;
        private set;
    }


    private void Awake()
    {
        instance = this;
        playerEnable = 0;
        EventManager.StartListening("PausePlayer", PausePlayer);
        EventManager.StartListening("ResumePlayer", ResumePlayer);
    }
    

    private void OnDestroy()
    {
        EventManager.StopListening("PausePlayer", PausePlayer);
        EventManager.StopListening("ResumePlayer", ResumePlayer);
    }

    private void Start()
    {
        foreach(DisablePlayer player in players){
            player.Disable();
        }
        players[playerEnable].Enable();
        CameraMobile.target = players[playerEnable].gameObject.GetComponent<Renderer>();
        RuotaPersonaggi.GetComponent<SelectPlayer>().SetUp(players);

    }

    private void Update()
    {

        /*if(Input.GetButtonDown("Swap")){
            ChangePlayer();
        }*/
        if (Input.GetButtonDown("Swap"))
        {
            Time.timeScale = 0;
            players[playerEnable].Disable();
            RuotaPersonaggi.SetActive(true);
        }
        if (Input.GetButtonUp("Swap"))
        {
            RuotaPersonaggi.SetActive(false);
            Time.timeScale = 1;
            players[playerEnable].Enable();
        }
        if (Input.GetButtonDown("Pause") && !RuotaPersonaggi.activeInHierarchy){
            EventManager.TriggerEvent("Pause");
        }
    }

    /*private void ChangePlayer()
    {
        players[playerEnable].Disable();
        do
        {
            playerEnable = (playerEnable + 1) % players.Count;
        }while (!players[playerEnable].CompareTag("Player"));
        players[playerEnable].Enable();
        CameraMobile.target = players[playerEnable].gameObject.GetComponent<Renderer>();
    }*/

    public void ChangePlayer(int index)
    {
        if (index >= 0 && index < players.Count && players[index].CompareTag("Player"))
        {
            players[playerEnable].Disable();
            playerEnable = index;
            players[playerEnable].Enable();
            CameraMobile.target = players[playerEnable].gameObject.GetComponent<Renderer>();
        }
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
