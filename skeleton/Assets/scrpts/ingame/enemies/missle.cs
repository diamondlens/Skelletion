using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class missle : MonoBehaviour
{

    [SerializeField] Transform target;

    NavMeshAgent agent;

    public float health;
    public player playerref;
    public bool miniboss = false;
    public Enemycontroller cont;
    public GameObject coin;
    public GameObject soulseed;

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

        Quaternion rotato = Quaternion.Euler(0, 0, Mathf.Atan(agent.velocity.y / agent.velocity.x) * (180 / Mathf.PI));

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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Proj"))
        {

            health -= playerref.damage;
            if (health <= 0)
            {
                if (miniboss == true)
                {
                    GameObject clone = Instantiate(soulseed, transform.position, Quaternion.identity);
                    clone.SetActive(true);
                    Destroy(gameObject);
                    print(health);
                }

                GameObject clone1 = Instantiate(coin, transform.position, Quaternion.identity);
                clone1.SetActive(true);
                cont.current -= 1;
                Destroy(gameObject);
            }


        }

    }
}