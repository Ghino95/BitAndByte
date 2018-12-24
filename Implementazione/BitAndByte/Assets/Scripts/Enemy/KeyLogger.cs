using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLogger : MonoBehaviour {

    public GameObject Copia;

    private Rigidbody2D RigidCopia;
    private Rigidbody2D rig;

    private void Awake()
    {
        RigidCopia = Copia.GetComponent<Rigidbody2D>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (RigidCopia.velocity.y != 0)
        {
            rig.velocity = new Vector2(RigidCopia.velocity.x, -RigidCopia.velocity.y);
        }
        else
        {
            rig.velocity = new Vector2(RigidCopia.velocity.x, rig.velocity.y);
        }
    }
}
