using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spit : MonoBehaviour
{


    public float time;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = time;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
