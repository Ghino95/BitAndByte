using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour
{

    public bool Grounded;
    private Animator anim;

    private void Awake()
    {
        Grounded = false;
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Grounded = true;
        anim.SetBool("Salto", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Grounded = false;
        anim.SetBool("Salto", true);
    }
}
