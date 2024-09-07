using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class megaslash : dmgdealer
{
    GameObject playerGO;
    BoxCollider2D bc;

    public float projectilespeed;

    Rigidbody2D rb;
    public float soulcost;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerref.rightclick.AddListener(rightping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void rightping()
    {
        if (playerref.soul >= soulcost)
        {
            playerref.soul -= soulcost;
            Vector3 mousepos;
            mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((mousepos.y - playerref.transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2))) / ((mousepos.x - playerref.transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2)))) * (180 / Mathf.PI));




            if ((mousepos.x - transform.position.x) < 0)
            {
                spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((mousepos.y - playerref.transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2))) / ((mousepos.x - playerref.transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2)))) * (180 / Mathf.PI) + 180);
            }
            /*
            GameObject clone = Instantiate(projectile, transform.position, spawnRotation);
            clone.SetActive(true);

            Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
            //clonerb.AddForce((Vector3.Normalize(mousepos - transform.position)) * projectilespeed, ForceMode2D.Impulse);
            */


            rb.AddForce((new Vector3((mousepos.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2)), (mousepos.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - playerref.transform.position.x), 2) + Mathf.Pow((mousepos.y - playerref.transform.position.y), 2)))) * projectilespeed, ForceMode2D.Impulse);
        }
    }
}
