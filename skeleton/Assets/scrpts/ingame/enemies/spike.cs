using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{


    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        Quaternion rotato = Quaternion.Euler(0, 0, Mathf.Atan(rb.velocity.y / rb.velocity.x) * (180 / Mathf.PI) - 90);

        if (rb.velocity.x < 0)
        {
            rotato = Quaternion.Euler(0, 0, Mathf.Atan(rb.velocity.y / rb.velocity.x) * (180 / Mathf.PI) + 90);
        }
        transform.rotation = rotato;
    }


}
