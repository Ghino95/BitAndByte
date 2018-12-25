using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : InferfaceEffect{

    public bool Init;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Init", Init);
        anim.SetBool("Perform", !Init);

    }

    public override void PerformEffect(GameObject oggetto)
    {
        //anim.SetTrigger("ChangeState");
        anim.SetBool("Perform", Init);
    }

    public override void DisableEffect(GameObject oggetto)
    {
        //anim.SetTrigger("ChangeState");
        anim.SetBool("Perform", !Init);
    }


}
