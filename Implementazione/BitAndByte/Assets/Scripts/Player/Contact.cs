using UnityEngine;
using System.Collections;

public class Contact : MonoBehaviour
{

    public bool Grounded;

    private void Awake()
    {
        Grounded = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Grounded = false;
    }
}
