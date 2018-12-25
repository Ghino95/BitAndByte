using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTroll : MonoBehaviour {

    private Rigidbody2D rig;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rig.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(Delete());
        }
    }

    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

}
