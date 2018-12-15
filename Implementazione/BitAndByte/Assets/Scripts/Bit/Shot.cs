using UnityEngine;
using System.Collections;

public class Shot: MonoBehaviour
{

    private bool HaveBit;
    private Animator anim;
    private ParticleSystem effect;
    private Transform direzione;

    public GameObject shot;
    public Transform dx;
    public Transform sx;

    private void Awake()
    {
        effect = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        direzione = dx;
        HaveBit = false;
    }

    void Update()
    {
        UpdateDirezione();
        if(HaveBit && Input.GetButtonDown("ActivePower")){
            StartCoroutine(Fire());
        }

    }

    private IEnumerator Fire(){
        anim.SetBool("ParticolState", true);
        if (direzione == dx)
            anim.SetInteger("Shot", 1);
        else
            anim.SetInteger("Shot", -1);
        Instantiate(shot, direzione.position, direzione.rotation);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ParticolState", false);
        anim.SetInteger("Shot", 0);
        HaveBit = false;
        effect.Pause();
        effect.Clear();
        anim.SetBool("Power", false);
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
        anim.SetBool("Power", true);
        effect.Play();
    }

    public bool isActiveBit()
    {
        return HaveBit;
    }
}
