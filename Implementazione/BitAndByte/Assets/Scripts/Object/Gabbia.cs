using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabbia : MonoBehaviour {

    public GameObject Prison;
    public DiagolImages Images;

    private void Awake()
    {
        EventManager.StartListening("OpenJail", OpenJail);
    }

    private void OpenJail(){
        DialogManager.instance.StartDialog(Images, Prison);
        Prison.tag = "Player";
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("OpenJail", OpenJail);
    }

}
