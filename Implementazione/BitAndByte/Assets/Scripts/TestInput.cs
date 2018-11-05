using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour {

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.X)){
            EventManager.TriggerEvent("OpenJail");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            EventManager.TriggerEvent("Absorbe");
        }
    }
}
