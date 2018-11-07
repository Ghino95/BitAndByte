using UnityEngine;
using System.Collections;

public class Shot: MonoBehaviour
{

    private bool HaveBit;
    private SpriteRenderer spriteRenderer;

    private ParticleSystem effect;

    public GameObject shot;
    public Transform dx;
    public Transform sx;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        effect = GetComponent<ParticleSystem>();
        HaveBit = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(HaveBit && Input.GetButtonDown("Fire1")){
            if(!spriteRenderer.flipX){
                Instantiate(shot, dx.position, dx.rotation);
            }else{
                Instantiate(shot, sx.position, sx.rotation);
            }
            HaveBit = false;
            effect.Pause();
            effect.Clear();
        }

    }

    public void EnableBit(){
        HaveBit = true;
        effect.Play();
        //aggiungere effetto grafico
    }
}
