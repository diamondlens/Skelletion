using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulseed : MonoBehaviour
{
    Vector3 spawnpos;
    public GameObject soulflame;
    GameObject soulsave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        spawnpos = new Vector3(transform.position.x, (transform.position.y - 2f), 0);
        GameObject clone = Instantiate(soulflame, spawnpos, Quaternion.identity);
        clone.SetActive(true);
        soulsave = clone;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(soulsave);
            Destroy(gameObject);
        }
    }
}


