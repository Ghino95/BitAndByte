using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLight : InferfaceEffect {

    private Light Luce;

    private void Awake()
    {
        Luce = GetComponent<Light>();
        Luce.enabled = false;
    }

    public override void PerformEffect(GameObject oggetto)
    {
        Luce.enabled = true;
    }

}
