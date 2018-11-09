using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : InterfaceDisable {

    [Header("Layer Visibili")]
    public LayerMask Target;

    private RaycastHit2D hit;
    public SpriteRenderer luce;
    private bool active;

    private Coroutine Risveglio;

    private void Awake()
    {
        active = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && active){
            EventManager.TriggerEvent("GameOver");
        }
    }

    public override void ChangeState()
    {
        luce.enabled = !luce.enabled;
        active = !active;
    }

    public override void ActiveVirus()
    {
        if(Risveglio == null){
            Risveglio = StartCoroutine(Reactive());
        }

    }

    public override void EnterZone()
    {
        if(Risveglio != null){
            StopCoroutine(Risveglio);
            Risveglio = null;
        }
    }

    private IEnumerator Reactive(){
        yield return new WaitForSeconds(5.0f);
        luce.enabled = true;
        active = !active;
        Risveglio = null;
    }


}
