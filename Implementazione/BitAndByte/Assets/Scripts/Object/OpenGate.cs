using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour {

    public GameObject Prison;
    public DiagolImages Images;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            EventManager.TriggerEvent("OpenJail");
            DialogManager.instance.StartDialog(Images, Prison);
            Prison.tag = "Player";
            Destroy(gameObject);
        }
    }

}
