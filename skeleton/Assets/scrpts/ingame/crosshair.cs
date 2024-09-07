using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    public player playerref;
    public GameObject loss;

    Vector3 mouseposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerref.levelpause == false)
        {
            mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseposition.x, mouseposition.y);
            if (loss.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
