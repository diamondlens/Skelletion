using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class boneshards : MonoBehaviour
{
    GameObject playerGO;
    private player playerscript;

    // Start is called before the first frame update
    void Start()
    {

        playerGO = GameObject.FindWithTag("Player");
        playerscript = playerGO.GetComponent<player>();



        playerscript.dash.AddListener(Dashping);
        //playerscript.dash.AddListener(Dashping);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dashping()
    {
        print("stab");
    }

    private void OnTriggerEnter2D(Collider2D enemy)
    {
        //if (collision.gameObject.CompareTag("enemy"))
        //{
        //    enemy.get_component<scriptname>();
        //}

    }


}


