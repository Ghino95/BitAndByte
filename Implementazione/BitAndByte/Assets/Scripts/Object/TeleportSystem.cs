using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSystem : MonoBehaviour {

	[HideInInspector]
	public GameObject teleportedObject = null;
	
	public SpriteRenderer targetSprite;
}
