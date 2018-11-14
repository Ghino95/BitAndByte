using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour {

    private List<MonoBehaviour> scripts;
    private Rigidbody2D rig;

    private void Awake()
    {
        scripts = new List<MonoBehaviour>();
        scripts.AddRange(GetComponents<MonoBehaviour>());
        scripts.AddRange(GetComponentsInChildren<MonoBehaviour>());
        scripts.Remove(this);
        rig = GetComponent<Rigidbody2D>();
    }

    public void Disable()
    {
        foreach(MonoBehaviour script in scripts){
            script.enabled = false;
        }

        rig.drag = 10.0f;
    }

    public void Enable()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        rig.drag = 0.0f;
    }

}
