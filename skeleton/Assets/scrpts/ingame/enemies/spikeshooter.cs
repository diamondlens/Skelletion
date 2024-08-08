using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class spikeshooter : MonoBehaviour
{
    

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;   
    public GameObject spawn5;
    public GameObject spawn6;
    public GameObject spawn7;
    public GameObject spawn8;
    public GameObject spawn9;

    List<GameObject> spikeloc = new List<GameObject>();

    public GameObject spike;
    public float spikespeed; 
        

    void Start()
    {
        spikeloc.Add(spawn1);
        spikeloc.Add(spawn2);
        spikeloc.Add(spawn3);
        spikeloc.Add(spawn4);
        spikeloc.Add(spawn5);
        spikeloc.Add(spawn6);
        spikeloc.Add(spawn7);
        spikeloc.Add(spawn8);   
        spikeloc.Add(spawn9);
    }

    // Up
    // date is called once per frame
    void Update()
    { 

        

    }
    
    void Spikeping()
    {

    }
    public void activateset()
    {


      GameObject spawnloc;
    
      spawnloc = spikeloc[Random.Range(0, spikeloc.Count)];

        GameObject clone = Instantiate(spike, spawnloc.transform.position, spawnloc.transform.rotation);
        clone.SetActive(true);
        print(spawnloc.transform.rotation);
        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();

        //Quaternion rotato = Quaternion.AngleAxis(clone.transform.rotation, Vector3.up);
        
        clonerb.AddForce(clone.transform.rotation * (new Vector3(spikespeed, 0, 0)));
        
        //clone.transform.rotation  = Quaternion.Euler(clone.transform.rotation.x, clone.transform.rotation.y, spawnloc.transform.rotation.z * 180 / Mathf.PI  - 90);
        //print(spawnloc.transform.rotation.z * 180 / Mathf.PI - 90);


    }
    
}
