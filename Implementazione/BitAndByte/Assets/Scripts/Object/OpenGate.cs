using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            GetComponent<SpriteRenderer>().flipX = true;
            EventManager.TriggerEvent("OpenJail");
        }
    }

}
