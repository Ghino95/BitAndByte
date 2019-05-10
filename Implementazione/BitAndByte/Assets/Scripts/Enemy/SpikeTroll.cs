using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTroll : MonoBehaviour {

    public Vector3 NewPosition;
    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tr.position = NewPosition;
        }
    }

}
