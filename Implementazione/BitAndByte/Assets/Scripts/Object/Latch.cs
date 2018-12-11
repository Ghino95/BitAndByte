using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latch : MonoBehaviour
{

    public InferfaceEffect[] target;
    private int i = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (i == 0)
        {
            foreach (InferfaceEffect temp in target)
            {
                temp.PerformEffect(null);
            }
        }
        i++;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        i--;
        if (i == 0)
        {
            foreach (InferfaceEffect temp in target)
            {
                temp.DisableEffect(null);
            }
        }
    }
}