using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTele : MonoBehaviour {


    private Transform tr;

    private void Awake()
    {
        tr = GetComponent<Transform>();

    }

    private void Update()
    {
        tr.Rotate(new Vector3(0,0,1.0f));
    }


}
