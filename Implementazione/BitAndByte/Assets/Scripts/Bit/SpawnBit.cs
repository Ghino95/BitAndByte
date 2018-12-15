using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBit : MonoBehaviour {

    public GameObject obj;
    private Transform tr;
    private GameObject bit;
    private CircleCollider2D col;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        col = GetComponent<CircleCollider2D>();
        bit = Instantiate(obj, tr.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shot temp = collision.GetComponent<Shot>();
        if (temp != null && !temp.isActiveBit())
        {
            Destroy(bit);
            bit = null;
            col.enabled = false;
            temp.EnableBit();
            Invoke("Spawn", 5.0f);
        }
    }

    void Spawn()
    {
        if (bit == null)
        {
            bit = Instantiate(obj, tr.position, Quaternion.identity);
            col.enabled = true;
        }
    }



}
