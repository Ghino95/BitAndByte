using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gabbia : MonoBehaviour {

    public GameObject Prison;
    public DiagolImages Images;
    public AudioClip CageEffect;

    private void Awake()
    {
        EventManager.StartListening("OpenJail", OpenJail);
    }

    private void OpenJail(){
        SoundManager.instance.StartEffectMusic(CageEffect);
        DialogManager.instance.StartDialog(Images, Prison);
        Prison.tag = "Player";
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("OpenJail", OpenJail);
    }

}
