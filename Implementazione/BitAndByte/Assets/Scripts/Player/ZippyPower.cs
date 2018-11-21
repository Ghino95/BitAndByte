using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZippyPower : MonoBehaviour {

    public List<Vector3> Trasformazioni;
    private Transform tr;
    private int count;

    private GameObject Other;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        count = 0;
    }

    private void Update()
    {
        if (Other != null && Input.GetButtonDown("Fire1"))
        {
            Other.GetComponent<ChangeSize>().ChangeSizeEffect();
        }
        if (Input.GetButtonDown("ActivePower"))
        {
            count = (count + 1) % Trasformazioni.Count;
            tr.localScale = Trasformazioni[count];
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Other = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(Other == collision.gameObject){
            Other = null;
        }
    }




}
