using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latch : MonoBehaviour
{

    public InferfaceEffect taget;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        anim.SetInteger("Status", 1);
        taget.PerformEffect(null);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetInteger("Status", 0);
        taget.DisableEffect(null);
    }
}