using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : InferfaceEffect {

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    public override void PerformEffect(GameObject oggetto)
    {
        Destroy(gameObject);
    }

}
