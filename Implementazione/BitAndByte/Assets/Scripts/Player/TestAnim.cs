using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour {


    private Animator anim;
    private Rigidbody2D rig;
    private int invert;

    private void Awake()
    {
        invert = 1;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        anim.SetBool("ParticolState", false);
        EventManager.StartListening("ChangeGravity", ChangeGravity);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ChangeGravity", ChangeGravity);
    }

    void FixedUpdate () {
        //invert = rig.gravityScale >= 0 ? 1 : -1;
        if (rig.velocity.x != 0)
        {
            anim.SetInteger("Direzione", invert * Sign(rig.velocity.x));
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
