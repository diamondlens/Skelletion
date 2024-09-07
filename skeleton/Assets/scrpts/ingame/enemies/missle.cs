using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class missle : enemybase
{

    [SerializeField] Transform target;

    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;


    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);

        Quaternion rotato = Quaternion.Euler(0, 0, Mathf.Atan(agent.velocity.y / agent.velocity.x) * (180 /     Mathf.PI));

        if (agent.velocity.x < 0)
        {
            rotato = Quaternion.Euler(0, 0, Mathf.Atan(agent.velocity.y / agent.velocity.x) * (180 / Mathf.PI) + 180);
        }
        transform.rotation = rotato;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            agent.velocity = new Vector3(agent.velocity.x, -agent.velocity.y, 0);   

        }


    }


    
}