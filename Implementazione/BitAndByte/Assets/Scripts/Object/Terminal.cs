using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

    public List<InferfaceEffect> lasers;

    private GameObject player;
    private int count;
    private bool interact;


    private void Awake()
    {
        player = null;
        interact = false;
        count = 0;
    }

    private void Update()
    {
        if (!interact && player != null && Input.GetButtonDown("Interact")){
            player.GetComponent<DisablePlayer>().Disable();
            ControllerManager.instance.enabled = false;
            interact = true;
        }else if (interact && player != null && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<DisablePlayer>().Enable();
            ControllerManager.instance.enabled = true;
            interact = false;
        }else if(interact && Input.GetButtonDown("Swap")){
            count = (count+1) % lasers.Count;
        }else if (interact && Input.GetButtonDown("Vertical"))
        {
            lasers[count].PerformEffect(null);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && player == null){
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && player != null)
        {
            player = null;
        }
    }


}
