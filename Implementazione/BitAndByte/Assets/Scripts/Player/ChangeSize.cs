using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

    private int count;
    private Transform tr;
    private List<Vector3> sizes;

    private void Awake()
    {
        count = 0;
        tr = GetComponent<Transform>();
        sizes = new List<Vector3>
        {
            new Vector3(1, 1, 1),
            new Vector3(0.5f, 0.5f, 1)
        };
    }

    public void ChangeSizeEffect(){
        count = (count + 1) % sizes.Count;
        tr.localScale = sizes[count];
    }

}
