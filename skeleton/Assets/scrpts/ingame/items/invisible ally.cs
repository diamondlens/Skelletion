using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class invisibleally : MonoBehaviour
{
    public player playerref;
    public GameObject playergo;

    float shootcd;

    void Start()
    {
        shootcd = 2 / playerref.firerate;
    }

    // Update is called once per frame
    void Update()
    {
        float localplayertime = Time.deltaTime;
        if (Time.timeScale > 0)
        {
            localplayertime = Time.deltaTime / Time.timeScale;
        }
        shootcd -= localplayertime;
        if (shootcd <= 0)
        {
            shoot();
        }
    }

    void shoot()
    {
        //print("1");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(playergo.transform.position, 10f);

            
        //print(hitColliders.Length + "coliders");
        Collider2D tMin = null;
        float minDist = 10f;
        Vector3 currentPos = playergo.transform.position;
        foreach (Collider2D t in hitColliders)
        {
            //print("2");
            if (t != null)
            {

                if (t.CompareTag("Enemy") == false)
                {
                    //print("3");
                    continue;
                }

                //print("4");
                float dist = Vector3.Distance(t.transform.position, currentPos);
                if (dist < minDist)
                {
                    //print("5");
                    tMin = t;
                    minDist = dist;
                }
            }
        }

            if (tMin != null)
            {

                //print("6");
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

            shootcd = 2 / playerref.firerate;

        }
    }
    /*
    private void OnDrawGizmos()
    {
        //print("hi");
        Gizmos.DrawWireSphere(playergo.transform.position, 10f);
    }
    */
}
