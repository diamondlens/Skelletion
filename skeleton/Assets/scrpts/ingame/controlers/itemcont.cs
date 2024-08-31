using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemcont : MonoBehaviour
{

    public player playerref;

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


    float raritypick;
    List<GameObject> cpool = new List<GameObject>();
    List<GameObject> rpool = new List<GameObject>();
    List<GameObject> epool = new List<GameObject>();
    List<GameObject> lpool = new List<GameObject>();

    GameObject onepick;
    GameObject twopick;
    GameObject threepick;

    public GameObject nochoice1;
    public GameObject nochoice2;
    public GameObject nochoice3;

    public GameObject boneshards;
    public GameObject boneshardsgo;
    public GameObject hellsdecent;
    // Start is called before the first frame update
    void Start()
    {


        rpool.Add(boneshards);
        rpool.Add(hellsdecent);

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
        if (av <= 0)
        {
            onepick = nochoice1;
            onepick.SetActive(true);
            onepick.transform.localPosition = new Vector3(-200, 0, 0);
            upgradepick2();
        }
        if (av > 0)
        {

            raritypick = Random.Range(1, 20);

            if (raritypick <= 11 && cav > 0)
            {
                //common (55%)
                onepick = Cpick();
                cav -= 1;
            }
            if (raritypick > 11 && raritypick <= 16 && rav > 0)
            {
                //rare (30%)

                onepick = Rpick();
                rav -= 1;
            }
            if (raritypick > 16 && raritypick <= 19 && eav > 0)
            {
                //epic (10%)
                onepick = Epick();
                eav -= 1;
            }
            if (raritypick > 19 && lav > 0)
            {
                //legendary (5) 
                onepick = Lpick();
                lav -= 1;
            }

            if (onepick != null)
            {
                onepick.SetActive(true);
                onepick.transform.localPosition = new Vector3(-200, 0, 0);
                av -= 1;
                upgradepick2();
            }

            if (onepick == null)
            {
                upgradepick1();
            }
        }
    }

    void upgradepick2()
    {
        if (av <= 0)
        {
            twopick = nochoice2;
            twopick.SetActive(true);
            twopick.transform.localPosition = new Vector3(0, 0, 0);
            upgradepick3();
        }
        if (av > 0)
        {
            raritypick = Random.Range(1, 20);

            if (raritypick <= 11)
            {
                //common (55%)
                if (cav > 0)
                {
                    twopick = Cpick();
                }
                cav -= 1;
            }
            if (raritypick > 11 && raritypick <= 16)
            {
                //rare (30%)
                if (rav > 0)
                {
                    twopick = Rpick();
                }
                rav -= 1;
            }
            if (raritypick > 16 && raritypick <= 19)
            {
                //epic (10%)
                if (eav > 0)
                {
                    twopick = Epick();
                }
                eav -= 1;
            }
            if (raritypick > 19)
            {
                //legendary (5) 
                if (lav > 0)
                {
                    twopick = Lpick();
                }
                lav -= 1;
            }

            if (twopick != onepick)
            {
                if (twopick != null)
                {
                    twopick.SetActive(true);
                    twopick.transform.localPosition = new Vector3(0, 0, 0);
                    av -= 1;
                    upgradepick3();
                }
            }

            if (twopick == null || twopick == onepick)
            {
                if (raritypick <= 11)
                {
                    cav += 1;
                }
                if (raritypick > 11 && raritypick <= 16)
                {
                    rav += 1;
                }
                if (raritypick > 16 && raritypick <= 19)
                {
                    eav += 1;
                }
                if (raritypick > 19)
                {
                    lav += 1;
                }
                upgradepick2();

            }
        }
    }

    void upgradepick3()
    {
        if (av <= 0)
        {
            threepick = nochoice3;
            threepick.SetActive(true);
            threepick.transform.localPosition = new Vector3(200, 0, 0);
        }

        if (av > 0)
        {
            raritypick = Random.Range(1, 20);

            if (raritypick <= 11)
            {
                //common (55%)
                if (cav > 0)
                {
                    threepick = Cpick();
                }
                cav -= 1;
            }
            if (raritypick > 11 && raritypick <= 16)
            {
                //rare (30%)
                if (rav > 0)
                {
                    threepick = Rpick();
                }
                rav -= 1;
            }
            if (raritypick > 16 && raritypick <= 19)
            {
                //epic (10%)
                if (eav > 0)
                {
                    threepick = Epick();
                }
                eav -= 1;
            }
            if (raritypick > 19)
            {
                //legendary (5) 
                if (lav > 0)
                {
                    threepick = Lpick();
                }
                lav -= 1;
            }

            if (threepick != onepick && threepick != twopick)
            {
                if (threepick != null)
                {
                    threepick.SetActive(true);
                    threepick.transform.localPosition = new Vector3(200, 0, 0);
                    av -= 1;
                }
            }

            if (threepick == null || threepick == onepick || threepick == twopick)
            {
                if (raritypick <= 11)
                {
                    cav += 1;
                }
                if (raritypick > 11 && raritypick <= 16)
                {
                    rav += 1;
                }
                if (raritypick > 16 && raritypick <= 19)
                {
                    eav += 1;
                }
                if (raritypick > 19)
                {
                    lav += 1;
                }
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

    public void boneshardsbut()
    {
        boneshardsgo.SetActive(true);
        rpool.Remove(boneshards);
        buttonpressed();
    }
    private void reset()
    {
        cmax = cpool.Count;
        rmax = rpool.Count;
        emax = epool.Count;
        lmax = lpool.Count;

        avmax = cmax + rmax + emax + lmax;
        av = avmax;
        rav = rmax;
    }

    void buttonpressed()
    {
        reset();
        Time.timeScale = 1f;
        onepick.SetActive(false);
        twopick.SetActive(false);
        threepick.SetActive(false);
    }
}
