using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float time;
    float timer;
    public player playerref;
    int pierce;

    // Start is called before the first frame update
    void Start()
    {
        timer = time;
        pierce = playerref.projpierce;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            pierce -= 1;
        }
        
        if (pierce <= 0)
        {
            Destroy(gameObject);
        }
    }
}
