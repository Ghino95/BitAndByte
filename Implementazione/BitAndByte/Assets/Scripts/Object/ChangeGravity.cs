using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : InferfaceEffect {


    private Rigidbody2D rig;
    private Collider2D col;

    public GameObject Effect;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
        col.enabled = false;
        Effect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if(rig != null && rig.bodyType == RigidbodyType2D.Dynamic){
            rig.gravityScale = -1.0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rig = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rig != null && rig.bodyType == RigidbodyType2D.Dynamic)
        {
            rig.gravityScale = 1.0f;
        }
    }

    public override void PerformEffect(GameObject oggetto)
    {
        col.enabled = true;
        Effect.SetActive(true);
    }

    public override void DisableEffect(GameObject oggetto)
    {
        col.enabled = false;

        Effect.SetActive(false);
    }

}
