using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpike : MonoBehaviour {

    public GameObject Spike;


    private void Awake()
    {
        Spike.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Spike.SetActive(true);
        }
    }
}
