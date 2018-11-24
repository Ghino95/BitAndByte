using UnityEngine;
using System.Collections;

public class Shot: MonoBehaviour
{

    private bool HaveBit;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private ParticleSystem effect;
    private Transform direzione;
    private Transform tr;

    public GameObject shot;
    public Transform dx;
    public Transform sx;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        effect = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        direzione = dx;
        HaveBit = false;
    }


    // Update is called once per frame
    void Update()
    {
        UpdateDirezione();
        if(HaveBit && Input.GetButtonDown("Fire1")){
            Instantiate(shot, direzione.position, direzione.rotation);
            HaveBit = false;
            effect.Pause();
            effect.Clear();
        }

    }

    private void UpdateDirezione(){
        if(anim.GetInteger("Direzione") > 0){
            direzione = dx;
        }else if(anim.GetInteger("Direzione") < 0){
            direzione = sx;
        }
    }

    public void EnableBit(){
        HaveBit = true;
        effect.Play();
    }
}
