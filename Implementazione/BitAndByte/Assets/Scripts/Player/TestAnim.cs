﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour {


    private Animator anim;
    private Rigidbody2D rig;
    private int invert;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        invert = rig.gravityScale >= 0 ? 1 : -1;
        anim.SetBool("ParticolState", false);
        EventManager.StartListening("ChangeGravity", ChangeGravity);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ChangeGravity", ChangeGravity);
    }

    void Update () {
        if (rig.velocity.x != 0)
        {
            anim.SetBool("Fermo", false);
            anim.SetInteger("Direzione", invert * Sign(rig.velocity.x));
        }
        else
        {
            anim.SetBool("Fermo",true);
        }
    }

    private int Sign(float vel)
    {
        return vel < 0 ? -1 : (vel > 0 ? 1 : 0);
    }

    private void ChangeGravity()
    {
        invert *= -1;
    }

}
