using UnityEngine;
using System.Collections;

public class Lift : InferfaceEffect
{

    private Transform tr;
    private Vector3 start;
    public Vector3 target;
    private Rigidbody2D rig;
    public bool triggered = false;
    private bool end;


    private Vector3 temp;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        start = tr.position;
        rig = GetComponent<Rigidbody2D>();
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());

    }

    IEnumerator Move(){
        if ((triggered && !end) || (rig.velocity != Vector2.zero))
        {
            rig.velocity = (target - tr.position).normalized * 3.0f;
            if ((tr.position - target).magnitude < 0.1f )
            {
                rig.velocity = Vector2.zero;
                temp = target;
                target = start;
                start = temp;
                end = true;
                yield return new WaitForSeconds(5f);
                end = false;
            }
        }

    }

    public override void PerformEffect(GameObject oggetto)
    {
        triggered = true;
    }




}
