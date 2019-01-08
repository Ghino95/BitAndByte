using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrojan : MonoBehaviour
{
    private LayerMask ObstacleLayer;
    private RaycastHit2D hit;
    private Transform tr;

    private Vector3 Direzione;
    private bool Carica;


    private void Awake()
    {
        tr = GetComponent<Transform>();
        ObstacleLayer = LayerMask.GetMask("Player", "Default");
        Carica = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hit = Physics2D.Raycast(tr.position, collision.transform.position - tr.position, float.PositiveInfinity, ObstacleLayer);
            Carica = hit.collider != null && hit.collider.gameObject == collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Carica &= !collision.CompareTag("Player");
    }

    public bool isCarica()
    {
        return Carica;
    }

}
