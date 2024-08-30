using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcont : MonoBehaviour
{

    public player playerref;
    bool ding = false;

    float av;
    float avmax;

     float cmax;
    float cav;
     float rmax;
    float rav;
     float emax;
    float eav;
     float lmax;
    float lav;

    float choicesmax = 3;
    float choicesleft;

    float raritypick;
    List<GameObject> cpool = new List<GameObject>();
    List<GameObject> rpool = new List<GameObject>();
    List<GameObject> epool = new List<GameObject>();
    List<GameObject> lpool = new List<GameObject>();

    GameObject onepick;
    GameObject twopick;
    GameObject threepick;

    public GameObject boneshards;
    // Start is called before the first frame update
    void Start()
    {


        rpool.Add(boneshards);

        cmax = cpool.Count;
        rmax = rpool.Count;
        emax = epool.Count;
        lmax = lpool.Count;

        avmax = cmax + rmax + emax + lmax;
        av = avmax;
        rav = rmax;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void begin()
    {
        Time.timeScale = 0f;
        upgradepick1();
    }

    void upgradepick1()
    {

        if (av > 0)
        {

            print("hi");
            raritypick = Random.Range(1, 20);

            if (raritypick <= 11 && cav > 0)
            {
                //common (55%)
                onepick = Cpick();
            }
            if (raritypick > 11 && raritypick <= 16 && rav > 0)
            {
                //rare (30%)
                onepick = Rpick();
            }
            if (raritypick > 16 && raritypick <= 19 && eav > 0)
            {
                //epic (10%)
                onepick = Epick();
            }
            if (raritypick > 19 && lav > 0)
            {
                //legendary (5) 
                onepick = Lpick();
            }

            if (onepick != null)
            {

                onepick.SetActive(true);
                onepick.transform.localPosition = new Vector3(-200, 0, 0);
            }

            if (onepick == null)
            {
                upgradepick1();
            }
        }

    }

    void upgradepick2()
    {

        if (av >= 0)
        {
            raritypick = Random.Range(1, 20);
            if (raritypick <= 11)
            {
                //common (55%)
                twopick = Cpick();
            }
            if (raritypick > 11 && raritypick <= 16)
            {
                //rare (30%)
                twopick = Rpick();
            }
            if (raritypick > 16 && raritypick <= 19)
            {
                //epic (10%)
                twopick = Epick();
            }
            if (raritypick > 19)
            {
                //legendary (5) 
                twopick = Lpick();
            }

            bool check2 = true;
            //check2 = check(twopick);

            if (check2 == true)
            {
                twopick.SetActive(true);
                twopick.transform.localPosition = new Vector3(0, 0, 0);
                upgradepick3();
            }
            if (check2 == false)
            {
                upgradepick2();
            }
        }
    }

    void upgradepick3()
    {

        if (av >= 0)
        {
            raritypick = Random.Range(1, 20);

            if (raritypick <= 11)
            {
                //common (55%)
                threepick = Cpick();
            }
            if (raritypick > 11 && raritypick <= 16)
            {
                //rare (30%)
                threepick = Rpick();
            }
            if (raritypick > 16 && raritypick <= 19)
            {
                //epic (10%)
                threepick = Epick();
            }
            if (raritypick > 19)
            {
                //legendary (5) 
                threepick = Lpick();
            }

            bool check3 = true;
            //check3 = check(threepick);

            if (check3 == true)
            {
                threepick.SetActive(true);
                threepick.transform.localPosition = new Vector3(200, 0, 0);
            }
            if (check3 == false)
            {
                upgradepick3();
            }
        }
    }

    GameObject Cpick()
    {
        return cpool[Random.Range(0, cpool.Count)];
    }

    GameObject Rpick()
    {
        return rpool[Random.Range(0, rpool.Count)];
    }
    GameObject Epick()
    {
        return epool[Random.Range(0, epool.Count)];
    }
    GameObject Lpick()
    {
        return cpool[Random.Range(0, lpool.Count)];
    }

}
