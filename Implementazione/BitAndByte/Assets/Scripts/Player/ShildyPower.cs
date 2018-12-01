using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildyPower : MonoBehaviour {

    private GameObject enemy;
    private bool CanActive = false;
    private Animator anim;
    private SpriteRenderer Area;

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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && enemy == null){
            enemy = collision.gameObject;
            enemy.GetComponent<InterfaceDisable>().EnterZone();
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
        }
    }

    private IEnumerator Scudo(){
        anim.SetBool("ParticolState", true);
        anim.SetTrigger("Power");
        Area.enabled = true;
        enemy.GetComponent<InterfaceDisable>().ChangeState();
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ParticolState", false);
        Area.enabled = false;

    }

}
