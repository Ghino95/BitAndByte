using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour {

    public List<InferfaceEffect> lasers;

    private GameObject player;


    private void Awake()
    {
        player = null;
        foreach (InferfaceEffect laser in lasers)
        {
            laser.enabled = false;
        }
    }

    private void Update()
    {

        if (player != null && player.GetComponent<DisablePlayer>().isActive == true && Input.GetButtonDown("Interact"))
        {
            foreach (InferfaceEffect temp in lasers)
            {
                temp.PerformEffect(null);
            }
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
