using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBit : InferfaceEffect {

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


    public override void PerformEffect(GameObject oggetto)
    {
        Shot temp = oggetto.GetComponent<Shot>();
        if(temp != null){
            Destroy(bit);
            bit = null;
            col.enabled = false;
            temp.EnableBit();
            Invoke("Spawn", 10.0f);
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
