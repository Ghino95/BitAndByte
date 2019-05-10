using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttivaEffetto : MonoBehaviour {

    private InferfaceEffect obj;

    private void Update()
    {
        if(obj != null && Input.GetButtonDown("Interact")){
            obj.PerformEffect(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Activable")){
            obj = collision.gameObject.GetComponent<InferfaceEffect>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Activable"))
        {
            obj = null;
        }

    }

}
