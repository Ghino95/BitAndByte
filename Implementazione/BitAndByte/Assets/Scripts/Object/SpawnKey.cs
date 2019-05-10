using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour {

    public GameObject Key;
    public Sprite ImageKey;
    private bool HaveKey;

    private void Awake()
    {
        HaveKey = true;
        EventManager.StartListening("DecatchKey", SpawnKeyEvent);
        EventManager.StartListening("CatchKey", CatchKey);
    }

    private void OnDestroy()
    {
        EventManager.StopListening("DecatchKey", SpawnKeyEvent);
    }

    private void SpawnKeyEvent()
    {
        if (!HaveKey)
        {
            GameObject temp = Instantiate(Key, transform.position, Quaternion.Euler(0,0,40));
            temp.GetComponent<SpriteRenderer>().sprite = ImageKey;
            HaveKey = true;
        }
    }

    private void CatchKey()
    {
        HaveKey = false;
    }

}
