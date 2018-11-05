using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildyPower : MonoBehaviour {


    private InterfaceDisable enemy;
    private bool CanActive = false;
    private bool BoolTest = false;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && CanActive){
            enemy.ChangeState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")){
            enemy = collision.gameObject.GetComponent<InterfaceDisable>();
            CanActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CanActive = false;
            if(!BoolTest){
                BoolTest = true;
                Invoke("Restore", 5.0f);
            }
        }
    }

    private void Restore(){
        enemy.ActiveVirus();
        enemy = null;
        BoolTest = false;
    }

}
