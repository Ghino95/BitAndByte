using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntermittenza : MonoBehaviour {

    private Light Luce;

    private void Awake()
    {
        Luce = GetComponent<Light>();
        StartCoroutine(Intermittenza());
    }

    private IEnumerator Intermittenza()
    {
        while (true)
        {
            Luce.enabled = true;
            yield return new WaitForSeconds(Random.Range(1f,2.5f));
            Luce.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.2f, 1f));
            yield return null;
        }
    }


}
