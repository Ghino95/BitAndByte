using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    public int TotalPlayer;
    public int ActualPlayer;
    private Animator Anim;

    private void Awake()
    {
        ActualPlayer = 0;
        Anim = GetComponent<Animator>();
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
        Anim.SetTrigger("Open");
    }
}
