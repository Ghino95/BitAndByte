using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    public GameObject Prison;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            EventManager.TriggerEvent("OpenJail");
            Prison.tag = "Player";
        }
    }

}
