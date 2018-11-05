using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour
{

    private ControlPlayer parent;

    private void Awake()
    {
        parent = transform.parent.gameObject.GetComponent<ControlPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        parent.grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parent.grounded = false;
    }
}
