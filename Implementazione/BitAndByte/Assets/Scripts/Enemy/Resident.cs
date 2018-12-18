using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : InterfaceDisable {

    public SpriteRenderer luce;
    private bool active;

    private Coroutine Risveglio;

    private void Awake()
    {
        active = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && active)
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    public override void DisableVirus()
    {
        luce.enabled = false;
        active = false;
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
        luce.enabled = true;
        active = true;
        Risveglio = null;
    }


}
