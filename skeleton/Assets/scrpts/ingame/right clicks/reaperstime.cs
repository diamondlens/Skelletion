using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaperstime : MonoBehaviour
{

    public player playerref;

    public float soulcost;
    

    public float slowspeed;
    public float slowtime;
    float slowdowntimer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (playerref.rightping == true && playerref.levelpause == false)
        {

            if (playerref.soul >= soulcost)
            {
                Time.timeScale = slowspeed;
                slowdowntimer = slowtime;
                playerref.soul -= soulcost;

            }
            playerref.rightping = false;
        }

        if (Time.timeScale > 0)
        {
            slowdowntimer -= Time.deltaTime;
        }

        if (slowdowntimer <= 0 && playerref.levelpause == false)
        {
            Time.timeScale = 1f;
        }

        
    }
}
