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
    public AudioClip ShotEffect;

    private void Awake()
    {
        effect = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
        direzione = dx;
        HaveBit = false;
    }

    void Update()
    {
        //UpdateDirezione();
        if(HaveBit && Input.GetButtonDown("ActivePower")){
            StartCoroutine(Fire());
            SoundManager.instance.StartEffectMusic(ShotEffect);
        }

    }

    private IEnumerator Fire(){
        anim.SetBool("ParticolState", true);
        anim.SetBool("Shot", true);
        direzione = anim.GetInteger("Direzione") >= 0 ? dx : sx;
        Instantiate(shot, direzione.position, direzione.rotation);
        HaveBit = false;
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ParticolState", false);
        anim.SetBool("Shot", false);
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
