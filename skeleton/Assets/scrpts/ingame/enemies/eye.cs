using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eye : enemybase
{

    [SerializeField] Transform target;

    UnityEngine.AI.NavMeshAgent agent;


    float timer = 0;
    public float spitcd;
    public GameObject spit;
    private RaycastHit2D checkray;
    public float projectilespeed;
    public GameObject projectile;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateUpAxis = false;
        agent.updateRotation = false;

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
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotato, 0.03f);

    
        timer += Time.deltaTime;
        if (timer > spitcd)
        {
            Vector3 toplayer;

            LayerMask layer_mask = LayerMask.GetMask("enemy");
            //spit animiation
            toplayer = new Vector3((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y), 0);
            checkray = Physics2D.Raycast(transform.position, toplayer, 25, ~layer_mask);
            if (checkray.collider != null) 
            {
                if (checkray.collider.gameObject == player)
                {
                    shoot();
                }
            }


        }

    }

    void shoot()
    {
        GameObject target;
        target = player;



        Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((target.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2))) / ((target.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2)))) * (180 / Mathf.PI));

        //print((mousepos.x - transform.position.x));
        if ((target.transform.position.x - transform.position.x) < 0)
        {
            spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((target.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2))) / ((target.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2)))) * (180 / Mathf.PI) + 180);
        }

        GameObject clone = Instantiate(projectile, transform.position, spawnRotation);
        clone.SetActive(true);

        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        //clonerb.AddForce((Vector3.Normalize(mousepos - transform.position)) * projectilespeed, ForceMode2D.Impulse);
        clonerb.AddForce((new Vector3((target.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2)), (target.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2)))) * projectilespeed, ForceMode2D.Impulse);


        print(new Vector3((target.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2)), (target.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((target.transform.position.x - transform.position.x), 2) + Mathf.Pow((target.transform.position.y - transform.position.y), 2))));
        timer = 0;
    }

    

}
;