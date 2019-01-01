using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildyPower : MonoBehaviour {

    private GameObject enemy;
    private bool CanActive = false;
    private Animator anim;
    private SpriteRenderer Area;
    public AudioClip ShildyAudio;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        Area = GetComponent<SpriteRenderer>();
        Area.enabled = false;
    }

    private void Update()
    {
        if(Input.GetButtonDown("ActivePower") && CanActive){
            StartCoroutine(Scudo());
            enemy.GetComponent<InterfaceDisable>().DisableVirus();
        }else if (Input.GetButtonDown("ActivePower"))
        {
            StartCoroutine(Scudo());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && enemy == null){
            enemy = collision.gameObject;
            CanActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == enemy)
        {
            CanActive = false;
            enemy.GetComponent<InterfaceDisable>().ActiveVirus();
            enemy = null;
            Area.enabled = false;
        }
    }

    private IEnumerator Scudo(){
        SoundManager.instance.StartEffectMusic(ShildyAudio);
        anim.SetBool("ParticolState", true);
        anim.SetTrigger("Power");
        Area.enabled = true;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ParticolState", false);
        Area.enabled &= CanActive;

    }

}
