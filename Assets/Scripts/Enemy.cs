using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float hitPoints;
    private float castRange;
    private float visionRange;
    private float cooldown;

    private float moveSpeed;

    private float minRoamDist;
    private float maxRoamDist;

    private bool casting;
    GameObject playerObj;


    private Vector2 targetPosition;
    private float distanceToPlayer;



    // Start is called before the first frame update
    void Start()
    {
        hitPoints = 10f;
        maxRoamDist = 5f;
        moveSpeed = 1f;
        cooldown = 0f;
        minRoamDist = 1f;
        visionRange = 6f;
        castRange = 3f;
        casting = false;
        targetPosition = GetRoamingPosition();
        //playerObj = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPoints == 0)
        {
            Destroy(this.gameObject);
        }

        distanceToPlayer = Vector2.Distance(this.transform.position, PlayerController.instance.transform.position);
        
        //Cast spell
        if ((distanceToPlayer < castRange) && (cooldown == 0))
        {
            //casting = true;
            //CastSpell();
            targetPosition = this.transform.position;
        }
        //Follow
        else if (distanceToPlayer < visionRange)
        {
            targetPosition = GetPlayerPosition(); 
        }

        //Default roaming procedure
        if (Vector2.Distance(transform.position, targetPosition) < 1f)
        {
            targetPosition = GetRoamingPosition();      
        }

        float step = moveSpeed * Time.deltaTime;
        
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            hitPoints -= PlayerController.instance.GetComponent<PlayerController>().damageMod;
            Destroy(col.gameObject);
        }
    }

    private Vector3 GetRoamingPosition() 
    {
        Vector3 r = new Vector3(UnityEngine.Random.Range(-1f,1f), UnityEngine.Random.Range(-1f,1f)).normalized;
        return this.transform.position + r * Random.Range(minRoamDist, maxRoamDist);
    }

    private Vector3 GetPlayerPosition()
    {
        return PlayerController.instance.transform.position;
    }

}
