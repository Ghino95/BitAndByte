using UnityEngine;
using System.Collections;

public class ShotBit : MonoBehaviour
{

    private Rigidbody2D rig;
    private Transform tr;

    private float velocity = 10.0f;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        rig.velocity = tr.right * velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


}
