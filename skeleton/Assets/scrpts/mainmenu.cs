using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject credits;
    public GameObject firstmenu;
    public GameObject Xbutton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void play()
    {
        SceneManager.LoadScene("game");
    }

    public void togglevisibility()
    {
        xping();
        credits.SetActive(!credits.activeSelf);
    }

    public void xping()
    {
        credits.SetActive(false);
        Xbutton.SetActive(!Xbutton.activeSelf);
        firstmenu.SetActive(!firstmenu.activeSelf);
    }
}
