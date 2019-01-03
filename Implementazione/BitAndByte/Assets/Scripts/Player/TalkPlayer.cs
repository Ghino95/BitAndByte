using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkPlayer : MonoBehaviour {

    public DiagolImages Dialogo;


	// Use this for initialization
	void Start () {
        DialogManager.instance.StartDialog(Dialogo);
	}
	
}
