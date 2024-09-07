using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class reaperstime : MonoBehaviour
{

    public player playerref;

    public float soulcost;

    Rigidbody2D rb;

    public float slowspeed;
    public float slowtime;
    float slowdowntimer;

    bool done = true;
    // Start is called before the first frame update
    void Start()
    {
        playerref.rightclick.AddListener(rightping);
    }

    // Update is called once per frame
    void Update()
    {


        if (done == false)
        {
            slowdowntimer -= Time.deltaTime;
        }

        if (done == false && slowdowntimer <= 0 && playerref.levelpause == false)
        {
            playerref.soulgainmod += 50;
            Time.timeScale = 1f;
        }
    }

    public void rightping()
    {
        if (playerref.soul >= soulcost)
        {
            Time.timeScale = slowspeed;
            slowdowntimer = slowtime;
            playerref.soul -= soulcost;
            playerref.soulgainmod -= 50;
            done = false;

        }
    }
}
