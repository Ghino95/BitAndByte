using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildyPower : MonoBehaviour {


    private GameObject enemy;
    private bool CanActive = false;

    private void Update()
    {
        if(Input.GetButtonDown("ActivePower") && CanActive){
            enemy.GetComponent<InterfaceDisable>().ChangeState();
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

}
