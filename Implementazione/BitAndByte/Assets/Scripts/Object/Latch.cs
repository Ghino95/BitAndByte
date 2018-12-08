using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latch : MonoBehaviour
{

    public InferfaceEffect taget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        taget.PerformEffect(null);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        taget.DisableEffect(null);
    }
}