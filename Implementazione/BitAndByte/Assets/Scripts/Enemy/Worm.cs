using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worm : InferfaceEffect {

    public List<GameObject> Parti;
    private int count;


    private void Awake()
    {
        count = 0;
    }

    public override void PerformEffect(GameObject oggetto)
    {
        Destroy(Parti[count]);
        count++;
        if(count == Parti.Count){
            Destroy(gameObject);
        }
    }


}
