using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileIntangible : MonoBehaviour
{
    private _2dxFX_AL_Hologram effetto;

    private void Awake()
    {
        effetto = GetComponent<_2dxFX_AL_Hologram>();
        effetto.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(AttivaEffetto());
    }

    private IEnumerator AttivaEffetto()
    {
        effetto.enabled = true;
        yield return new WaitForSeconds(1.0f);
        effetto.enabled = false;
        yield return null;
    }


}
