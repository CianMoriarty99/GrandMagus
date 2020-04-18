using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;

    public Transform castPoint;
    public GameObject spellPrefab;

    public float damageMod = 1f;

    public float coolDown;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        if(Input.GetButtonDown("Fire1") && coolDown <= 0)
        {
            Shoot();
        }

        coolDown -= Time.deltaTime;
    }

    void Shoot()
    {
        Instantiate(spellPrefab, castPoint.position, castPoint.rotation);
        coolDown = 1f;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized  * moveSpeed * Time.fixedDeltaTime);
    }
}
