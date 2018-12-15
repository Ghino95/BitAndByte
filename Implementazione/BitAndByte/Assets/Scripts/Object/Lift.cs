using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lift : InferfaceEffect
{

    private Transform tr;
    private Vector3 start;
    public Vector3 target;
    public bool triggered = false;
    private bool end;


    private Vector3 temp;

    private int invert;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        start = tr.position;
        end = false;
        invert = 1;
        EventManager.StartListening("ChangeGravity", ChangeGravity);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("ChangeGravity", ChangeGravity);
    }

    void Update()
    {
        StartCoroutine(Move());

    }

    IEnumerator Move(){
        if ((triggered && !end))
        {
            tr.position = Vector3.MoveTowards(tr.position, target, 0.05f);


            if ((tr.position - target).magnitude < 0.05f )
            {
                temp = target;
                target = start;
                start = temp;
                end = true;
                yield return new WaitForSeconds(2f);
                end = false;
            }
        }

    }


    public override void PerformEffect(GameObject oggetto)
    {
        triggered = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((tr.position.y - collision.transform.position.y)*invert < 0)
        {
            collision.transform.parent = tr;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }

    private void ChangeGravity()
    {
        invert *= -1;
    }

}
