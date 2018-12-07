using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : InferfaceEffect{

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    public override void PerformEffect(GameObject oggetto)
    {
       //GetComponent<Collider2D>().enabled = false;
        anim.SetTrigger("Activate");
    }

    public override void DisableEffect(GameObject oggetto)
    {
        this.gameObject.SetActive(true);
        //GetComponent<Collider2D>().enabled = true;
        anim.SetTrigger("Deactivate");
    }

    private void DeactivateWall()
    {
        this.gameObject.SetActive(false);
    }


}
