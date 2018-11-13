using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnim : MonoBehaviour {


    private Animator anim;
    private Rigidbody2D rig;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

   
	
	// Update is called once per frame
	void Update () {

        Vector2 velocity = rig.velocity;

        if(velocity.x > 0){
            anim.SetInteger("Direction", 1);
        } else if(velocity.x < 0){
            anim.SetInteger("Direction", -1);
        }
        else{
            anim.SetInteger("Direction", 0);
        }
		
	}
}
