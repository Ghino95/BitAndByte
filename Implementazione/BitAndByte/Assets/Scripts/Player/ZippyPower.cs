using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZippyPower : MonoBehaviour {

    public List<Vector3> Trasformazioni;
    private int count;
    private Animator anim;
    private GameObject Other;
    private Transform tr;
    private float[] sizes;
    private RaycastHit2D hit;
    public AudioClip ZippyAudio;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        count = 0;
        tr = GetComponent<Transform>();
        sizes = new float[3];
        sizes[0] = 0.9f;
        sizes[1] = 0.4f;
        sizes[2] = 1.4f;
    }

    private void Update()
    {
        if (Other != null && Input.GetButtonDown("Interact"))
        {
            Other.GetComponent<ChangeSize>().ChangeSizeEffect();
            SoundManager.instance.StartEffectMusic(ZippyAudio);
        }
        if (Input.GetButtonDown("ActivePower"))
        {
            count = CalcolaProssimoStato();
            anim.SetInteger("Size", count);
            SoundManager.instance.StartEffectMusic(ZippyAudio);
        }
    }

    private int CalcolaProssimoStato()
    {
        int temp = count;
        float differenza;
        do
        {
            differenza = sizes[(temp + 1) % 3] - sizes[count];
            hit = Physics2D.Raycast(tr.position, tr.up, differenza, LayerMask.GetMask("Default", "Player"));

            temp = (temp + 1) % 3;
            if (differenza < 0)
            {
                break;
            }
        } while (hit.collider != null);
        return temp;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Other = collision.gameObject;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(Other == collision.gameObject){
            Other = null;
        }
    }


}
