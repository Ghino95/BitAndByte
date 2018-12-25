using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLog : MonoBehaviour
{

    public Rigidbody2D Target;
    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Target.velocity.x != 0)
        {
            rig.MovePosition(new Vector2(Target.position.x,transform.position.y));
        }
    }
}
