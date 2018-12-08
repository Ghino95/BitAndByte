using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {


    public LayerMask Target;

    private LineRenderer Line;
    private RaycastHit2D hit;
    private Transform tr;

    private void Awake()
    {
        Line = GetComponent<LineRenderer>();
        tr = GetComponent<Transform>();
        Line.SetPosition(0, tr.position);
    }

    private void Update()
    {
        hit = Physics2D.Raycast(tr.position, -tr.right, 20.0f, Target);
        if(hit.collider != null){
            Line.SetPosition(1, tr.position);
            Line.SetPosition(0, hit.point);
            if(hit.collider.CompareTag("Player")){
                EventManager.TriggerEvent("GameOver");
            }

        }
    }


}
