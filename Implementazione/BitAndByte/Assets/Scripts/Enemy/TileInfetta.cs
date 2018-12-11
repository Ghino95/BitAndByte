using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileInfetta : InferfaceEffect {


    private Tilemap tile;
    private bool col;

    private void Awake()
    {
        tile = GetComponent<Tilemap>();
        col = true;
    }

    public override void PerformEffect(GameObject oggetto)
    {
        col = false;
        tile.color = Color.white;
        
    }

    public override void DisableEffect(GameObject oggetto)
    {
        col = true;
        tile.color = Color.magenta;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (col && collision.gameObject.CompareTag("Player"))
        {
            EventManager.TriggerEvent("GameOver");
        }
    }

}
