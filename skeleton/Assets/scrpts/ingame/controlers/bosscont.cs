using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{

    public GameObject spawner;
    public GameObject boss1;
    public player playerscrift;
    float dmgsave;
    public GameObject DEATH; 

    public float bossfight;
    float timer;
    bool bossfighttriggered1 = false;
    bool bossfighttriggered2 = false;

    public GameObject player;
    Vector3 playerxy;

    void Start()
    {

    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bossfight && bossfighttriggered1 == false)
        {
            startfight();
            bossfighttriggered1 = true;
        }

        if (timer >= bossfight +5f && bossfighttriggered2 == false)
        {
            playerscrift.damage = dmgsave;
            DEATH.SetActive(false);
            boss1.SetActive(true);
            bossfighttriggered2 = true;
        }


    }

    void startfight()
    {

        spawner.SetActive(false);
        playerxy = player.transform.position;
        player.transform.position = transform.position;
        dmgsave = playerscrift.damage;
        playerscrift.damage = 1000;
        DEATH.SetActive(true);
    }

    public void endfight()
    {
        player.transform.position = playerxy;
        spawner.SetActive(true);
        
    }
}
