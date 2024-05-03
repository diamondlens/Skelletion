using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghosts : MonoBehaviour
{


    public GameObject player;
    public float health;
    public float speed;
    Rigidbody2D m_Rigidbody;
    public player playerref;
    public bool miniboss = false;
    public Enemycontroller cont;
    public GameObject coin;
    public GameObject soulseed;
    

    //pubuic En

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // m_Rigidbody.AddForce((new Vector3((player.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.y - transform.position.y), 2)), (player.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.y - transform.position.y), 2)))) * speed * Time.deltaTime, ForceMode2D.Impulse);

        m_Rigidbody.velocity = new Vector2((player.transform.position.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.y - transform.position.y), 2)) * speed, (player.transform.position.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.y - transform.position.y), 2)) * speed);
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
