using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
        else if(!collision.CompareTag("Activable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
