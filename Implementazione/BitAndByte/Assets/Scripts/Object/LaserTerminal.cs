using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTerminal : InferfaceEffect {


    public List<Vector3> rotations;

    private Transform tr;
    private int count;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        count = 0;
        
    }

    public override void PerformEffect(GameObject oggetto)
    {
        tr.rotation = Quaternion.Euler(rotations[count]);
        count = (count+1) % rotations.Count;
    }

}
