using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trojan : InterfaceDisable{

    private LayerMask ObstacleLayer;
    private Rigidbody2D rig;
    private RaycastHit2D hit;
    private Transform tr;
    private float posX;
    private float posXFinale;
    private SpriteRenderer Sprite;
    private readonly float velocity = 8.0f;
    private Vector3 Direzione;
    private bool StartFlipX;
    private bool disable;
    private Coroutine Risveglio;
    private TestTrojan Carica;
    private int Modificatore;
    public BoxCollider2D AngoloVisione;
    public BoxCollider2D ColliderTrojan;


    private void Awake()
    {
        Carica = GetComponentInChildren<TestTrojan>();
        rig = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        Sprite = GetComponent<SpriteRenderer>();
        StartFlipX = Sprite.flipX;
        posX = tr.position.x;
        ObstacleLayer = LayerMask.GetMask("Player", "Default");
        disable = false;
        Modificatore = Sprite.flipX ? -1 : 1;
        posXFinale = StartFlipX ? posX - (AngoloVisione.size.x + ColliderTrojan.size.x / 2) : posX + (AngoloVisione.size.x + ColliderTrojan.size.x / 2);
    }

    private void Update()
    {
        if (!disable)
        {
            if (Carica.isCarica() && Mathf.Abs(tr.position.x - posXFinale) > 0.05f)
            {
                Direzione = !Sprite.flipX ? tr.right : -tr.right;
                rig.velocity = (Direzione).normalized * velocity;
            }else if (Mathf.Abs(tr.position.x - posX) > 0.05f)
            {

                Sprite.flipX = tr.position.x > posX;
                Modificatore = Sprite.flipX ? -1 : 1;
                Direzione = !Sprite.flipX ? tr.right : -tr.right;
                rig.velocity = (tr.right * (posX - tr.position.x)).normalized * velocity / 5;
            }
            else
            {
                Sprite.flipX = StartFlipX;
                Modificatore = Sprite.flipX ? -1 : 1;
                rig.velocity = Vector2.zero;
            }

            AngoloVisione.offset = new Vector2(Modificatore * Mathf.Abs(AngoloVisione.offset.x), AngoloVisione.offset.y);
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
