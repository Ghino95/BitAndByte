using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabbia : MonoBehaviour {


    private void Awake()
    {
        EventManager.StartListening("OpenJail", OpenJail);
    }

    private void OpenJail(){
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("OpenJail", OpenJail);
    }

}
