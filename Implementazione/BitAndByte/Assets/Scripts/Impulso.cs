using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulso : InferfaceEffect {


    public GameObject OggettoImpulso;
    public InferfaceEffect Oggetto;

    private LineRenderer Percorso;
    private Transform ImpulsoTr;
    private Vector3[] PuntiLinea;
    private int Count;
    private Coroutine Conr;

    private void Awake()
    {
        Percorso = GetComponent<LineRenderer>();
        PuntiLinea = new Vector3[Percorso.positionCount];
        Percorso.GetPositions(PuntiLinea);
        Count = 0;
    }

    public override void PerformEffect(GameObject oggetto)
    {
        Count = 0;
        GameObject temp = Instantiate(OggettoImpulso, PuntiLinea[0], Quaternion.identity);
        ImpulsoTr = temp.GetComponent<Transform>();
        Conr = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (Count < PuntiLinea.Length)
        {
            if (ImpulsoTr.position != PuntiLinea[Count]){
                ImpulsoTr.position = Vector3.MoveTowards(ImpulsoTr.position, PuntiLinea[Count], 0.3f);
            }
            else{
                Count++;
            }
            yield return null;
        }
        Destroy(ImpulsoTr.gameObject);
        Oggetto.PerformEffect(null);
        StopCoroutine(Conr);
        yield return null;
    }

}
