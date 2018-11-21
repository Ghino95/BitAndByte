﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayer : MonoBehaviour {

    private List<MonoBehaviour> scripts;
    private Rigidbody2D rig;

    private void Awake()
    {
        scripts = new List<MonoBehaviour>();
        scripts.AddRange(GetComponentsInChildren<MonoBehaviour>());
        scripts.Remove(this);
        scripts.Remove(GetComponentInChildren<_2dxFX_Hologram>());
        rig = GetComponent<Rigidbody2D>();

    }

    public void Disable()
    {
        foreach(MonoBehaviour script in scripts){
            script.enabled = false;
        }

        rig.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

    }

    public void Enable()
    {
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = true;
        }
        rig.drag = 0.0f;

        rig.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
