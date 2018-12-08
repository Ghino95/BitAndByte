using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : InterfaceDisable{

    public float MaxDistanza;


    private LayerMask ObstacleLayer;
    private Rigidbody2D rig;
    private RaycastHit2D hit;
    private Transform tr;
    private float posX;
    private SpriteRenderer Sprite;
    private readonly float velocity = 5.0f;
    private Vector3 Direzione;
    private bool StartFlipX;
    private bool disable;
    private Coroutine Risveglio;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        Sprite = GetComponent<SpriteRenderer>();
        posX = tr.position.x;
        ObstacleLayer = LayerMask.GetMask("Player");
        StartFlipX = Sprite.flipX;
        disable = false;
    }

    private void Update()
    {
        if (!disable)
        {
            Direzione = !Sprite.flipX ? tr.right : -tr.right;
            hit = Physics2D.Raycast(tr.position, Direzione, MaxDistanza, ObstacleLayer);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                rig.velocity = (Direzione).normalized * velocity;
            }
            else if (Mathf.Abs(tr.position.x - posX) > 0.1f)
            {
                Sprite.flipX = !StartFlipX;
                rig.velocity = (Vector2.right * (posX - tr.position.x)).normalized * velocity / 5;
            }
            else
            {
                Sprite.flipX = StartFlipX;
                rig.velocity = Vector2.zero;
            }
        }else{
            rig.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            EventManager.TriggerEvent("GameOver");
        }

    }

    public override void ActiveVirus()
    {
        if (Risveglio == null)
        {
            Risveglio = StartCoroutine(Reactive());
        }
    }

    public override void DisableVirus()
    {
        disable = true;
        if (Risveglio != null)
        {
            StopCoroutine(Risveglio);
            Risveglio = null;
        }
    }


    private IEnumerator Reactive()
    {
        yield return new WaitForSeconds(5.0f);
        disable = false;
        Risveglio = null;
    }

}
