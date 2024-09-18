using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttiontext : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame  
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.SetActive(true);
        text.transform.localPosition = new Vector3(0,158.048f, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.SetActive(false);
    }

    public void pressed()
    {
        text.SetActive(false );
    }
}
