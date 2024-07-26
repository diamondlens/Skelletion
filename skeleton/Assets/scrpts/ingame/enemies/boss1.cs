using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour
{

    [SerializeField] Transform target;

    UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit2D checkray;
    public GameObject player;

     float basespeed;
    public float chargespeed;
    public float chargetime;
    float chargetimer;
    bool chargeding = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;
        basespeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
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

        toplayer = new Vector3((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y), 0);
        checkray = Physics2D.Raycast(transform.position, toplayer, 30, ~layer_mask);
        if (checkray.collider != null)
        {
            if (checkray.collider.gameObject == player)
            {
                //print("hi(");
                agent.speed = chargespeed;
                chargetimer = chargetime;
                chargeding = true;
            }
        }

        if (chargetimer >= 0)
        {
            chargetimer -= Time.deltaTime;
        }
        if (chargeding == true && chargetimer <= 0)
        {
            agent.speed = basespeed;
            chargeding = false;
        }
    }

    void spikes()
    {
            
    }
}
