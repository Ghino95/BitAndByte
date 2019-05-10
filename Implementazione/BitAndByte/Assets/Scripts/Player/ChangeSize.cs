using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

    private Animator anim;
    private readonly float differenza = 0.5f;
    private RaycastHit2D hit;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Small", false);

    }

    public void ChangeSizeEffect(){
        if (CalcolaProssimoStato())
        {
            anim.SetBool("Small", !anim.GetBool("Small"));
        }
    }

    private bool CalcolaProssimoStato()
    {
        if (anim.GetBool("Small"))
        {
            hit = Physics2D.Raycast(transform.position, transform.up, differenza, LayerMask.GetMask("Default", "Player"));
            return hit.collider == null;

        }
        else
        {
            return true;
        }


    }

}
