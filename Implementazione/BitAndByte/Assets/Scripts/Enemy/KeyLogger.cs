using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogger : MonoBehaviour {

    public DisablePlayer Target;

    private float maxVelocity;
    private float jumpForce;
    private Rigidbody2D rig;
    private Contact Piedi;
    private Animator anim;
    private Animator AnimTarget;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        Piedi = GetComponentInChildren<Contact>();
        anim = GetComponent<Animator>();
        AnimTarget = Target.gameObject.GetComponent<Animator>();
        maxVelocity = Target.GetComponent<ControlPlayer>().maxVelocity;
        jumpForce = Target.GetComponent<ControlPlayer>().jumpForce;
    }

    void Update()
    {
        if (Target.isActive)
        {
            if (Input.GetButtonDown("Jump") && Piedi.Grounded)
            {
                rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y - jumpForce);
            }
            rig.velocity = new Vector2(Input.GetAxis("Horizontal") * maxVelocity, rig.velocity.y);
        }
        else
        {
            rig.velocity = new Vector2(0.0f, rig.velocity.y);
        }
        anim.SetBool("Small", AnimTarget.GetBool("Small"));

    }

}
