using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleally : MonoBehaviour
{
    public player playerref;
    public GameObject playergo;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            shoot();
        }

    }

    void shoot()
    {
        Collider[] hitColliders = new Collider[100];
        Physics.OverlapSphereNonAlloc(playergo.transform.position, 0.2985775f, hitColliders);

        Collider tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = playergo.transform.position;
        foreach (Collider t in hitColliders)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t;       
                minDist = dist;
            }
        }
        
        if (tMin != null)
        {


            Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((tMin.transform.position.y - playergo.transform.position.y) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2))) / ((tMin.transform.position.x - playergo.transform.position.x) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2)))) * (180 / Mathf.PI));




            if ((tMin.transform.position.x - playergo.transform.position.x) < 0)
            {
                spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((tMin.transform.position.y - playergo.transform.position.y) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2))) / ((tMin.transform.position.x - playergo.transform.position.x) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2)))) * (180 / Mathf.PI) + 180);
            }

            GameObject clone = Instantiate(playerref.projectile, playerref.transform.position, spawnRotation);
            clone.SetActive(true);

            Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
            //clonerb.AddForce((Vector3.Normalize(mousepos - transform.position)) * projectilespeed, ForceMode2D.Impulse);
            clonerb.AddForce((new Vector3((tMin.transform.position.x - playergo.transform.position.x) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2)), (tMin.transform.position.y - playergo.transform.position.y) / Mathf.Sqrt(Mathf.Pow((tMin.transform.position.x - playergo.transform.position.x), 2) + Mathf.Pow((tMin.transform.position.y - playergo.transform.position.y), 2)))) * playerref.projectilespeed, ForceMode2D.Impulse);
        }
    }
}
