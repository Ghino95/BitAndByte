using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public InferfaceEffect taget;
    private Animator anim;
    private Collider2D col;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Activate");
        taget.PerformEffect(null);
        col.enabled = false;
    }


}
