using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ControllerManager: MonoBehaviour
{
    public static ControllerManager instance
    {
        get;
        private set;
    }


    public List<DisablePlayer> players;
    private int playerEnable = 0;



    private void Start()
    {
        foreach(DisablePlayer player in players){
            player.Disable();
        }
        players[playerEnable].Enable();
        
    }

    //magari uso EventManager per mandare il messaggio del cambio player
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            players[playerEnable].Disable();
            playerEnable = (playerEnable +1) % players.Count;
            players[playerEnable].Enable();
        }
        
    }

}
