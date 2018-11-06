using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour
{

    public InferfaceEffect taget;
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Activate");
        taget.PerformEffect(null);
    }


}
