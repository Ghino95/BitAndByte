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
        anim.SetTrigger("Activate");
    }


}
