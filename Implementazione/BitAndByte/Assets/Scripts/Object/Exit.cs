using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public int TotalPlayer;
    private int ActualPlayer;
    private Animator Anim;

    public int Mondo;

    private void Awake()
    {
        ActualPlayer = 0;
        Anim = GetComponent<Animator>();
        Anim.SetInteger("Level", Mondo);
        EventManager.StartListening("CatchKey",OpenGate);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActualPlayer++;
            if(ActualPlayer == TotalPlayer){
                EventManager.TriggerEvent("AllPlayerExit");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            ActualPlayer--;
        }
    }

    private void OpenGate(){
        Anim.SetBool("OpenDoor",true);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("CatchKey", OpenGate);
    }
}
