using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public LayerMask Target;
    private LineRenderer Line;
    private RaycastHit2D hit;
    private Transform tr;
    private BoxCollider2D col;

    private void Awake()
    {
        Line = GetComponent<LineRenderer>();
        tr = GetComponent<Transform>();
        col = GetComponent<BoxCollider2D>();
        Line.SetPosition(0, tr.position);
    }

    private void Update()
    {
        hit = Physics2D.Raycast(tr.position, -tr.right, 20.0f, Target);
        if(hit.collider != null){
            Line.SetPosition(1, tr.position);
            Line.SetPosition(0, hit.point);
        }
        col.offset = new Vector2(-(Line.GetPosition(0) - Line.GetPosition(1)).magnitude/2 ,0);
        col.size = new Vector2((Line.GetPosition(0) - Line.GetPosition(1)).magnitude, 0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }


}
