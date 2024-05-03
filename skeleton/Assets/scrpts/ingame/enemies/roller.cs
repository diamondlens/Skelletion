using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roller : MonoBehaviour
{
    public GameObject player;
    public float health;
    public float speed;
    float speedcont;
    Rigidbody2D m_Rigidbody;
    public player playerref;
    public bool miniboss = false;
    public Enemycontroller cont;
    public float bye;
    float theta;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        speedcont = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            m_Rigidbody.AddForce(new Vector3(-1, 0) * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (player.transform.position.x > transform.position.x)
        {
            m_Rigidbody.AddForce(new Vector3(1, 0) * speed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (player.transform.position.y - transform.position.y >= bye)
        {
            theta = Random.Range(-10f, 10f);
            transform.position = new Vector3(player.transform.position.x + theta, player.transform.position.y + 30, 0f);

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
                    Destroy(gameObject);
                    //spawn chest
                }
                GameObject clone1 = Instantiate(coin, transform.position, Quaternion.identity);
                clone1.SetActive(true);
                cont.current -= 1;
                Destroy(gameObject);
            }
        }

    }
}
