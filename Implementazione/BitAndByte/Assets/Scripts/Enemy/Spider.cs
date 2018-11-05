using UnityEngine;
using System.Collections;

public class Spider : InterfaceDisable{


    [Header("Layer collisi")]
    public LayerMask ObstacleLayer;


    private DistanceJoint2D joint;
    private Transform tr;
    private RaycastHit2D hit;
    private Vector2 direction;
    private bool idle;
    private bool disable;

    private readonly float velocity = 0.3f;

    private void Awake()
    {
        joint = GetComponent<DistanceJoint2D>();
        tr = GetComponent<Transform>();
        idle = false;
        disable = false;

    }

    private bool IsPlayer(){

        hit = Physics2D.Raycast(tr.position, -tr.up, 2.5f, ObstacleLayer);
        return hit.collider != null ? true : false;
    }

    private void Update()
    {
        if(!idle && !disable){
            StartCoroutine("Move");
        }
        else{
            StartCoroutine("Idle");
        }
    }


    IEnumerator Move()
    {
        if(IsPlayer()){
            joint.distance += velocity;
        }else if(joint.distance > 1.0f){
            joint.distance += -velocity;
        }
        return null;

    }

    IEnumerator Idle()
    {
        if (joint.distance > 1.0f)
        {
            joint.distance += -velocity;
        }else{
            yield return new WaitForSeconds(5f);
            idle = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BitShot"))
        {
            StopCoroutine("Move");
            idle = true;
        }
    }

    public override void ChangeState()
    {
        disable = !disable;
    }

    public override void ActiveVirus()
    {
        disable = false;
    }




}
