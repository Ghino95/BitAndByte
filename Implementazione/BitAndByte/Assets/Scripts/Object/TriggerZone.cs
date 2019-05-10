using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour {

    public InferfaceEffect Target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Target.PerformEffect(null);
        Destroy(gameObject);
    }


}
