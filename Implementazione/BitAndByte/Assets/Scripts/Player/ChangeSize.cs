using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

    private Transform tr;
    private Animator anim;

    private void Awake()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("Small", false);
    }

    public void ChangeSizeEffect(){
        anim.SetBool("Small", !anim.GetBool("Small"));
    }

}
