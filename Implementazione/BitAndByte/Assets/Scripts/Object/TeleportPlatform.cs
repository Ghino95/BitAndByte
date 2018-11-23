using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlatform : MonoBehaviour {

	private TeleportSystem teleportSystem;

	public GameObject Destination;

	void Start () {
		this.teleportSystem = this.GetComponentInParent<TeleportSystem>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.tag == "Player" && teleportSystem.teleportedObject == null)
		{
			Animator anim = collision.gameObject.GetComponentsInChildren<Animator>()[0];
			StartCoroutine(telep(collision.gameObject, anim));
		}
    }

	IEnumerator telep (GameObject target, Animator anim) 
	{
		
		anim.Play("Bitty_TelepOut");

		yield return new WaitForSeconds(1.5f);
		
		target.transform.position = this.Destination.transform.position;
		
		teleportSystem.teleportedObject = target.gameObject;

		this.teleportSystem.targetSprite.enabled = !this.teleportSystem.targetSprite.enabled;
		
		anim.Play("Bitty_TelepIn");

		yield return new WaitForSeconds(1.5f);
	}

	private void OnTriggerExit2D(Collider2D collision) 
	{
		if (collision.tag == "Player" && teleportSystem.teleportedObject != null)
		{
			teleportSystem.teleportedObject = null;
		}
	}

}
