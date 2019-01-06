using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollSposta : MonoBehaviour {

    private Transform tr;
    private CircleCollider2D col;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        col = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && col.enabled)
        {
            tr.position += tr.right/2;
            col.enabled = false;
        }
    }


}
