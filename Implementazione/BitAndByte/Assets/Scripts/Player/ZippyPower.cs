using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZippyPower : MonoBehaviour {

    public List<Vector3> Trasformazioni;
    private Transform tr;
    private int count;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        count = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("ActivePower"))
        {
            count = (count + 1) % Trasformazioni.Count;
            tr.localScale = Trasformazioni[count];
        }
    }
}
