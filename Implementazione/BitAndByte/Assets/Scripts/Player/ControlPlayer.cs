﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour {


    [Header("Velocità del movimento")]
    public float maxVelocity = 6.0f;
    [Header("Velocità del salto")]
    public float jumpForce = 6.0f;
    [Header("Contatto con il terreno")]
    public bool grounded = false;

    private Rigidbody2D rig;
    private Vector2 move;



    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

	
	// Update is called once per frame
	void Update () {

        move = rig.velocity;

        move.x = Input.GetAxis("Horizontal") * maxVelocity;

        rig.velocity = move;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, jumpForce);
        }

    }

    private void OnDisable()
    {
        move = rig.velocity;
        move.x = 0;
        rig.velocity = move;
    }


}
