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
        foreach (InferfaceEffect laser in lasers)
        {
            laser.enabled = false;
        }
    }

    private void Update()
    {
        if (!interact && player != null && player.GetComponent<DisablePlayer>().isActive == true && Input.GetButtonDown("Interact")){
            player.GetComponent<DisablePlayer>().Disable();
            ControllerManager.instance.enabled = false;
            count = 0;
            lasers[count].enabled = true;
            interact = true;
        }else if (interact && player != null && Input.GetButtonDown("Interact"))
        {
            player.GetComponent<DisablePlayer>().Enable();
            ControllerManager.instance.enabled = true;
            lasers[count].enabled = false;
            interact = false;
        }else if(interact && Input.GetButtonDown("Swap")){
            lasers[count].enabled = false;
            count = (count+1) % lasers.Count;
            lasers[count].enabled = true;
        }
        else if (interact && Input.GetButtonDown("Jump"))
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
