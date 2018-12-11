using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityLevel : MonoBehaviour {

    public DisablePlayer player;

    private void Awake()
    {
        EventManager.StartListening("PausePlayer", PausePlayer);
        EventManager.StartListening("ResumePlayer", ResumePlayer);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("PausePlayer", PausePlayer);
        EventManager.StopListening("ResumePlayer", ResumePlayer);
    }



    // Update is called once per frame
    void Update () {

        if (Input.GetButtonDown("Swap"))
        {
            EventManager.TriggerEvent("ChangeGravity");
        }
        if (Input.GetButtonDown("Pause"))
        {
            player.Disable();
            EventManager.TriggerEvent("Pause");
        }
    }

    private void ResumePlayer()
    {
        player.Enable();
    }

    private void PausePlayer()
    {
        player.Disable();
    }


}
