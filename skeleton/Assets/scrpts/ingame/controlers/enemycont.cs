using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    float time; 
    public GameObject ghost;
    public GameObject greaterghost;
    public GameObject roller;
    public GameObject missle;
    //public GameObject greatermissle;
    public float max;
    public int current;
    public GameObject player;
    int pick;
    public float rad;
    Vector3 spawnpos;
    float theta;
    float minibosscurrent = 0;
    public float minibosstimer;
    float timer = 0;
    float maxtime = 1;
    float addtimer;

    public float ghostaddtime;
    bool ghostadded = false;

    public float rolleraddtime;
    bool rolleradded = false;



    float changetimer;
    public float changemax1;
    bool changemaxcheck = false ;

    List<GameObject> basicEpool = new List<GameObject>();

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        basicEpool.Add(missle);
        //basicEpool.Remove(0)
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        addtimer += Time.deltaTime;
        changetimer += Time.deltaTime;

        if (addtimer >= rolleraddtime && rolleradded == false)
        {
            basicEpool.Add(roller);
            rolleradded = true;
        }

        if (addtimer >= ghostaddtime && ghostadded == false)
        {
            basicEpool.Add(ghost);
            ghostadded = true;
        }

        if (timer >= maxtime)
        {
            onTimerTimeOut();
        }

        if (changetimer >= changemax1 && changemaxcheck == false)
        {
            max = 20;
            maxtime = 1/2;
        }

        minibosscurrent += Time.deltaTime;

        if (minibosscurrent >= minibosstimer)
        {
            theta = Random.Range(0f, 360f) * 180 / Mathf.PI;
            spawnpos = new Vector3(player.transform.position.x + rad * Mathf.Sin(theta), player.transform.position.y + rad * Mathf.Cos(theta), 0f);
            GameObject clone = Instantiate(greaterghost, spawnpos, Quaternion.identity);
            clone.SetActive(true);
            minibosscurrent = -100000;
        }
    }

    void onTimerTimeOut()
    {
        spawn();
        timer = 0;
    }

    void spawn()
    {
        if (current < max)
        {
            theta = Random.Range(0f, 360f) * 180 / Mathf.PI;
            spawnpos = new Vector3(player.transform.position.x + rad * Mathf.Sin(theta), player.transform.position.y + rad * Mathf.Cos(theta), 0f);
            GameObject clone = Instantiate( chooseETS(), spawnpos, Quaternion.identity);    
            clone.SetActive(true);
            current += 1;
        }
    }

        GameObject chooseETS()
    {
        return basicEpool[Random.Range(0, basicEpool.Count)];
    }
}
