using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public AudioClip KeyAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            Destroy(gameObject);
            SoundManager.instance.StartEffectMusic(KeyAudio);
            EventManager.TriggerEvent("CatchKey");
        }
    }

}
