using System.Collections;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class boneshards : dmgdealer
{
    GameObject playerGO;
    private player playerscript;
    public Rigidbody2D playerrb;
    BoxCollider2D bc;

    float dashtime;
    float dashtimer;
    bool dashing = false;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        playerGO = GameObject.FindWithTag("Player");
        playerscript = playerGO.GetComponent<player>();
        


        playerscript.dash.AddListener(Dashping);
        //playerscript.dash.AddListener(Dashping);


        damage = playerref.damage/2;
        dashtime = playerref.dashtime - 0.05f;
    }


    // Update is called once per frame  
    void Update()
    {
        if (dashing == true)
        {
            Quaternion rotato = Quaternion.Euler(0, 0, Mathf.Atan(playerrb.velocity.y / playerrb.velocity.x) * (180 / Mathf.PI));

            if (playerrb.velocity.x < 0)
            {
                rotato = Quaternion.Euler(0, 0, Mathf.Atan(playerrb.velocity.y / playerrb.velocity.x) * (180 / Mathf.PI) + 180);
            }
            transform.rotation = rotato;


            transform.position = playerGO.transform.position;
            dashtimer -= Time.deltaTime;
            if (dashtimer <= 0)
            {

                bc.enabled = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                dashing = false;
            }
        }
    }

    public void Dashping()
    {
        damage = playerref.damage / 2;
        bc.enabled = true;
        dashing = true;
        dashtimer = dashtime;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        //if (collision.gameObject.CompareTag("enemy"))
        //{
        //    enemy.get_component<scriptname>();
        //}

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            damage = playerref.damage /2 ;
            print(damage);
        }
    }
}


