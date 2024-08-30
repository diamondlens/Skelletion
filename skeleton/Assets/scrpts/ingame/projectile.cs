using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : dmgdealer 
{

    public float time;
    float timer;
    int pierce;
    

    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        pierce = playerref.projpierce;
        damage = playerref.damage;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
         
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.CompareTag("Enemy") && damage != 0)
        {
            pierce -= 1;
        }

        if (pierce == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { 
        damage = playerref.damage;
        print(damage);
        }
    }


}
