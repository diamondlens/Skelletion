using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class enemybase : MonoBehaviour
{

    public GameObject player;
    public float health;
    protected Rigidbody2D m_Rigidbody;
    public player playerref;
    public bool miniboss = false;
    public Enemycontroller cont;
    public GameObject coin;
    public GameObject soulseed;
    protected bool coinspawned = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
