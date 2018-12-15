using System.Collections;
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
    private Transform tr;

    private int invert = 1;



    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        EventManager.StartListening("ChangeGravity", ChangeGravity);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ChangeGravity", ChangeGravity);
    }

    void Update () {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rig.velocity = new Vector2(rig.velocity.x, rig.velocity.y + invert*jumpForce);
        }
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * maxVelocity, rig.velocity.y);

    }

    private void OnDisable()
    {
        move = rig.velocity;
        move.x = 0;
        rig.velocity.Set(0.0f, rig.velocity.y);
    }

    private void ChangeGravity()
    {
        invert *= -1;
        rig.gravityScale = invert == 1 ? 1.0f : -0.8f;
        if (invert == 1)
        {
            tr.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            tr.rotation = Quaternion.Euler(0, 0, 180);
        }
    }


}
