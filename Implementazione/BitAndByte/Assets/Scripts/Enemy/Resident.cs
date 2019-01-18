using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : InterfaceDisable {

    private ResidentLuce activeLuce;
    private Coroutine Risveglio;

    private void Awake()
    {
        activeLuce = GetComponentInChildren<ResidentLuce>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    public override void DisableVirus()
    {
        activeLuce.DisableLuce();
        if (Risveglio != null)
        {
            StopCoroutine(Risveglio);
            Risveglio = null;
        }
    }

    public override void ActiveVirus()
    {
        if(Risveglio == null){
            Risveglio = StartCoroutine(Reactive());
        }

    }


    private IEnumerator Reactive(){
        yield return new WaitForSeconds(5.0f);
        activeLuce.ActiverLuce();
        Risveglio = null;
    }


}
