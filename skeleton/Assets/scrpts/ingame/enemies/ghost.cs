using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using Unity.VisualScripting;
using UnityEngine;

public class ghosts : enemybase
{



    public float speed;


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