using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resident : InterfaceDisable {

    [Header("Layer Visibili")]
    public LayerMask Target;

    private Transform tr;
    private RaycastHit2D hit;
    public SpriteRenderer luce;
    private PolygonCollider2D col;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        col = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            /*hit = Physics2D.Raycast(tr.position, collision.gameObject.transform.position - tr.position, 5.0f, Target);
            if(hit.collider != null && hit.collider.CompareTag("Player")){
                print("GameOver");
            }*/
            print("GameOver");
        }
    }

    public override void ChangeState()
    {
        luce.enabled = !luce.enabled;
        col.enabled = !col.enabled;
        print("luce: " + luce.enabled + " collider: " + col.enabled);
    }

    public override void ActiveVirus()
    {
        luce.enabled = true;
        col.enabled = true;
    }


}
