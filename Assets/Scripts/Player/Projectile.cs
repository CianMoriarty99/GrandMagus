using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;

    public Rigidbody2D rb;
    
    void Start()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        mousePos = mousePos.normalized;
        Vector2 castPos = new Vector2(mousePos.x, mousePos.y);
        //transform.rotation = Quaternion.LookRotation(castPos);
        rb.velocity = castPos.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
