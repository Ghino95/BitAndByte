using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityObject : InferfaceEffect {

    private Rigidbody2D rig;
    private Vector3 startPosition;
    private Transform tr;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        startPosition = tr.position;
        EventManager.StartListening("ChangeGravity", ChangeGravity);
    }

    private void ChangeGravity()
    {
        rig.gravityScale *= -1;
       
    }

    public override void PerformEffect(GameObject oggetto)
    {
        tr.position = startPosition;
    }
    

}
