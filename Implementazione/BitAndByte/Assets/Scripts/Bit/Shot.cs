using UnityEngine;
using System.Collections;

public class Shot: MonoBehaviour
{

    private bool HaveBit;
    private SpriteRenderer spriteRenderer;
    public GameObject shot;
    public Transform dx;
    public Transform sx;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        HaveBit = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(HaveBit && Input.GetKeyDown(KeyCode.Tab)){
            if(!spriteRenderer.flipX){
                Instantiate(shot, dx.position, dx.rotation);
            }else{
                Instantiate(shot, sx.position, sx.rotation);
            }
            HaveBit = false;
        }

    }

    public void EnableBit(){
        HaveBit = true;
        //aggiungere effetto grafico
    }
}
