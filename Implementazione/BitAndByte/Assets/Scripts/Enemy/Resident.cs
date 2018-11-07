using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : InterfaceDisable {

    [Header("Layer Visibili")]
    public LayerMask Target;

    //private Transform tr;
    private RaycastHit2D hit;
    public SpriteRenderer luce;
    //private PolygonCollider2D col;
    private bool active;

    private void Awake()
    {
        //tr = GetComponent<Transform>();
        //col = GetComponent<PolygonCollider2D>();
        active = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && active){
            /*hit = Physics2D.Raycast(tr.position, collision.gameObject.transform.position - tr.position, 5.0f, Target);
            if(hit.collider != null && hit.collider.CompareTag("Player")){
                print("GameOver");
            }*/
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
        luce.enabled = true;
        active = !active;
    }


}
