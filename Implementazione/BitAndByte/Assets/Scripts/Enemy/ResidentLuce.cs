using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentLuce : MonoBehaviour
{
    private bool active;
    private SpriteRenderer luce;

    private void Awake()
    {
        active = true;
        luce = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && active)
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

    public void DisableLuce()
    {
        active = false;
        luce.enabled = false;
    }

    public void ActiverLuce()
    {
        active = true;
        luce.enabled = true;
    }
}
