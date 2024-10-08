using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roller : enemybase
{

    public float speed;
    float speedcont;
    public float bye;
    float theta;


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

            dmgdealer pain;
            pain = collision.gameObject.GetComponent<dmgdealer>();

            float critroll;
            critroll = Random.Range(1, 100);
            if (critroll > playerref.cc)
            {
                health -= pain.damage;
            }
            if (critroll <= playerref.cc)
            {
                health -= pain.damage * playerref.cd;
            }
            pain.damage = 0;


            if (health <= 0)
            {
                if (miniboss == true)
                {
                    if (coinspawned == false)
                    {
                        GameObject clone = Instantiate(soulseed, transform.position, Quaternion.identity);
                        clone.SetActive(true);
                        coinspawned = true;
                    }
                    Destroy(gameObject);
                    print(health);
                }
                if (coinspawned == false)
                {
                    GameObject clone1 = Instantiate(coin, transform.position, Quaternion.identity);
                    clone1.SetActive(true);
                    coinspawned = true;
                }
                cont.current -= 1;
                Destroy(gameObject);
            }
        }

    }
}
