using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour {

    private List<MonoBehaviour> scripts;

    private void Awake()
    {
        scripts = new List<MonoBehaviour>();
        scripts.AddRange(GetComponents<MonoBehaviour>());
        scripts.AddRange(GetComponentsInChildren<MonoBehaviour>());
        scripts.Remove(this);
    }

    public void Disable()
    {
        foreach(MonoBehaviour script in scripts){
            script.enabled = false;
        }
    }

    public void Enable()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
    }

}
