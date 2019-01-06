using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pacman : InferfaceEffect {

    private Transform tr;

    public Transform Target;

    private void Awake()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        tr.rotation = Quaternion.Euler(0, 0, Quaternion.FromToRotation(Vector3.right, Target.position - tr.position).eulerAngles.z);
        tr.position = Vector3.MoveTowards(tr.position, Target.position, 0.055f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.TriggerEvent("CatchKey");
            EventManager.TriggerEvent("AllPlayerExit");
        }
    }

    public override void PerformEffect(GameObject oggetto)
    {
        gameObject.SetActive(true);
    }

}
