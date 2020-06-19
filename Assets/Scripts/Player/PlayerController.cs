using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public GameObject bullet;

    MouseManager mouseScriptRef;

    public float damageMod = 1f;

    public float coolDown;

    public GameObject target;

    public Spell stolenSpell;

    public float stunDuration, spellDmg, spellAoe, castTime, castRange;

    public static PlayerController instance;

    void Awake()
    {
        instance = this;
    }



    void Start()
    {
        mouseScriptRef = GameObject.Find("MouseManager").GetComponent<MouseManager>();
        bullet = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        target = mouseScriptRef.selectedGameObject;

        if(Input.GetButtonDown("Fire1") && coolDown <= 0)
        {
            Shoot();
        }

        if(Input.GetButtonDown("Fire2") && target)
        {
            SpellSteal();
        }

        if(Input.GetButtonDown("Fire3"))
        {
            SpellCast(stolenSpell);
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
    }


    void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    void Shoot()
    {
        Instantiate(bullet, this.transform.position, this.transform.rotation);
        coolDown = 1f;
    }

    void SpellSteal()
    {
        Spell s = target.GetComponent<Spell>();
        stolenSpell = s;
    }

    void SpellCast(Spell ss)
    {
        stunDuration = ss.stunDuration;
        spellDmg = ss.spellDmg;
        spellAoe = ss.spellAoe;
        castTime = ss.castTime;
        castRange = ss.castRange;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized  * moveSpeed * Time.fixedDeltaTime);
    }
}
