using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : InferfaceEffect {

    public Transform Target;


    public override void PerformEffect(GameObject oggetto)
    {
        StartCoroutine(Test(oggetto));
    }


    private IEnumerator Test(GameObject Player){
        Player.GetComponent<DisablePlayer>().Disable();
        Animator anim = Player.GetComponent<Animator>();
        anim.SetBool("ParticolState", true);
        anim.SetTrigger("TeleIn");
        yield return new WaitForSeconds(1f);
        Player.GetComponent<SpriteRenderer>().enabled = false;
        Player.transform.position = Target.position;
        Player.GetComponent<SpriteRenderer>().enabled = true;
        anim.SetTrigger("TeleOut");
        yield return new WaitForSeconds(1f);
        anim.SetBool("ParticolState", false);
        Player.GetComponent<DisablePlayer>().Enable();
    }


}
