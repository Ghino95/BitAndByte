using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour {

    private Renderer Indicatore;

    private void Awake()
    {
        Indicatore = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        Indicatore.enabled = true;
    }

    private void OnDisable()
    {
        Indicatore.enabled = false;
    }

}
