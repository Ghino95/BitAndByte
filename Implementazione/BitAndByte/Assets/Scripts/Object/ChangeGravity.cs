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
