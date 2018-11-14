using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : MonoBehaviour {


    public LayerMask ObstacleLayer;
    public Transform Front;

    private Rigidbody2D rig;
    private RaycastHit2D hit;
    private Transform tr;
    private readonly float velocity = 10.0f;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        hit = Physics2D.Raycast(Front.position, Front.position - tr.position, 4.0f, ObstacleLayer);
        if(hit.collider != null){
            rig.velocity = (Front.position - tr.position).normalized * velocity;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            EventManager.TriggerEvent("GameOver");
        }

    }


}
