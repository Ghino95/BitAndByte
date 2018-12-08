using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : InferfaceEffect {

    private int count;

    public List<InferfaceEffect> Attivare;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        count = 0;
    }

    public override void PerformEffect(GameObject oggetto)
    {
        anim.SetTrigger("Destroy");
        count++;
        if(count == 3){
            Destroy(gameObject);
            foreach(InferfaceEffect Elemento in Attivare){
                Elemento.PerformEffect(null);
            }
        }
    }


}
