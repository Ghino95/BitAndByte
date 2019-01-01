using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimpyPower : MonoBehaviour {

    private _2dxFX_Hologram Effetto;
    public AudioClip GimpEffect;
    private bool ActivePower;

    private void Awake()
    {
        Effetto = gameObject.AddComponent(typeof(_2dxFX_Hologram)) as _2dxFX_Hologram;
        Effetto.Speed = 1.0f;
        Effetto.Distortion = 0.7f;
        Effetto.enabled = false;
        ActivePower = false;
    }


    private void Update()
    {
        if (Input.GetButtonDown("ActivePower") && !ActivePower)
        {
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            ActivePower = !ActivePower;
            Effetto.enabled = true;
            SoundManager.instance.StartEffectMusic(GimpEffect);
        }
        else if (Input.GetButtonDown("ActivePower") && ActivePower)
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            ActivePower = !ActivePower;
            Effetto.enabled = false;
        }
    }


}
