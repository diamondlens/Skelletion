using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camra : MonoBehaviour
{

    public GameObject loss;
    public GameObject player;
    Vector3 mouseposition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (loss.activeSelf == false)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3((7 * player.transform.position.x + mouseposition.x) / 8, (7 * player.transform.position.y + mouseposition.y) / 8, -40);
        }
    }
}
 