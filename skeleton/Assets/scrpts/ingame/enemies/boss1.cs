using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class boss1 : MonoBehaviour
{
    public spikeshooter spikeshooter;


    [SerializeField] Transform target;

    UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit2D checkray;
    public GameObject player;
    public player playerref;    

    public float maxhp;
    float health;

    public float spikecd;
    float spiketimer;

    float basespeed;
    public float chargespeed;
    public float chargetime;
    float chargetimer;
    bool chargeding = false;
    public float chargecd;
    float chargecdtimer;
    bool chargeready;


    void Start()
    {
        health = maxhp;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        basespeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            spikes();
        }

        agent.SetDestination(target.position);

        Quaternion rotato = Quaternion.Euler(0, 0, 0);

        if (Mathf.Sqrt((Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2))) <= 100)
        {
            rotato = Quaternion.Euler(0, 0, Mathf.Atan((target.position.y - transform.position.y) / (target.position.x - transform.position.x)) * (180 / Mathf.PI));

            if ((target.position.x - transform.position.x) < 0)
            {
                rotato = Quaternion.Euler(0, 0, Mathf.Atan((target.position.y - transform.position.y) / (target.position.x - transform.position.x)) * (180 / Mathf.PI) + 180);
            }
        }

        transform.rotation = rotato;

        Vector3 toplayer;

        LayerMask layer_mask = LayerMask.GetMask("enemy");

        //toplayer = new Vector3((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y), 0);
        toplayer = new Vector3(agent.velocity.x, agent.velocity.y, 0);
        checkray = Physics2D.Raycast(transform.position, toplayer, 30, ~layer_mask);
        if (checkray.collider != null)
        {
            if (chargeready = true && checkray.collider.gameObject == player)
            {
                //print("hi(");
                agent.speed = chargespeed;
                chargetimer = chargetime;
                chargeding = true;
                chargeready = false;
            }
        }



        if (chargetimer >= 0)
        {
            chargetimer -= Time.deltaTime;
        }

        if (chargecdtimer > 0)
        {
            chargecdtimer -= Time.deltaTime;
        }

        if (chargeding == true && chargetimer <= 0)
        {
            agent.speed = basespeed;
            chargeding = false;
            chargecdtimer = chargecd;
        }

        if (chargeready == false && chargecdtimer <= 0)
        {
            chargeready = true;
        }

        if (health <= maxhp / 2)
        {
            spiketimer -= Time.deltaTime;
            if (spiketimer <= 0)
            {
                spikes();
                spiketimer = spikecd;
            }
        }
    }

    void spikes()
    {
        spikeshooter.activateset();
        spikeshooter.activateset();
        spikeshooter.activateset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Proj"))
        {

            health -= playerref.damage;
        }

    }
}

