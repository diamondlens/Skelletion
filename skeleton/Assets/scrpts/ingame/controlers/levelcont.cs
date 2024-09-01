using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelcont : MonoBehaviour
{
    public player playerref;
    bool ding = false;

    public float cmax;
    float cav;
    public float rmax;
    float rav;
    public float emax;
    float eav;
    public float lmax;
    float lav;

    bool ascheck = false;
    bool dcheck = false;
    bool jcheck = false;
    bool scheck = false;
    bool pcheck = false;
    bool ccheck = false;
    bool cdcheck = false;
    bool rcheck = false;
    bool hcheck = false;

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

    //attackspeed
    public GameObject cas;
    public GameObject ras;
    public GameObject eas;
    public GameObject las;
    //damage
    public GameObject cd;
    public GameObject rd;
    public GameObject ed;
    public GameObject ld;
    //peirce 
    public GameObject lp;
    //jump
    public GameObject cj;
    public GameObject rj;
    //speed
    public GameObject rs;
    public GameObject es;
    //crit
    public GameObject cc;
    public GameObject rc;
    //critdmg
    public GameObject rcd;
    public GameObject ecd;
    public GameObject lcd;
    //soulregen 
    public GameObject cr;
    public GameObject rr;
    //health
    public GameObject rh;
    public GameObject eh;

    // Start is called before the first frame update
    void Start()
    {
        reset();

        cpool.Add(cas);
        cpool.Add(cd);
        cpool.Add(cj);
        cpool.Add(cc);
        cpool.Add(cr);

        rpool.Add(ras);
        rpool.Add(rd);
        rpool.Add(rj);
        rpool.Add(rs);
        rpool.Add(rc);
        rpool.Add(rcd);
        rpool.Add(rr);
        rpool.Add(rh);

        epool.Add(eas);
        epool.Add(ed);
        epool.Add(es);
        epool.Add(ecd);
        epool.Add(eh);

        lpool.Add(las);
        lpool.Add(ld);
        lpool.Add(lp);
        lpool.Add(lcd);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerref.levelpause == true && ding == false)
        {
            Time.timeScale = 0f;
            ding = true;
            upgradepick1();
        }



    }

    void upgradepick1()
    {


        raritypick = Random.Range(1, 20);
        if (raritypick <= 11)
        {
            //common (55%)
            onepick = Cpick();
        }
        if (raritypick > 11 && raritypick <= 16)
        {
            //rare (30%)
            onepick = Rpick();
        }
        if (raritypick > 16 && raritypick <= 19)
        {
            //epic (10%)
            onepick = Epick();
        }
        if (raritypick > 19)
        {
            //legendary (5) 
            onepick = Lpick();
        }

        bool check1;
        check1 = check(onepick);

        if (check1 == true)
        {
            onepick.SetActive(true);
            onepick.transform.localPosition = new Vector3(-200, 0, 0);
            upgradepick2();
        }
        if (check1 == false)
        {
            upgradepick1();
        }
    }

    void upgradepick2()
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

        bool check2;
        check2 = check(twopick);

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

    void upgradepick3()
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

        bool check3;
        check3 = check(threepick);

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

    bool check(GameObject check)
    {
        // true means valid

        //atackspeed 
        if (check == cas && ascheck == false)
        {
            cav -= 1;
            ascheck = true;
            return true;
        }
        if (check == ras && ascheck == false)
        {
            rav -= 1;
            ascheck = true;
            return true;
        }
        if (check == eas && ascheck == false)
        {
            eav -= 1;
            ascheck = true;
            return true;
        }
        if (check == las && ascheck == false)
        {
            lav -= 1;
            ascheck = true;
            return true;
        }

        //damage
        if (check == cd && dcheck == false)
        {
            cav -= 1;
            dcheck = true;
            return true;
        }
        if (check == rd && dcheck == false)
        {
            rav -= 1;
            dcheck = true;
            return true;
        }
        if (check == ed && dcheck == false)
        {
            eav -= 1;
            dcheck = true;
            return true;
        }
        if (check == ld && dcheck == false)
        {
            lav -= 1;
            dcheck = true;
            return true;
        }

        //jump
        if (check == cj && jcheck == false)
        {
            cav -= 1;
            jcheck = true;
            return true;
        }
        if (check == rj && jcheck == false)
        {
            rav -= 1;
            jcheck = true;
            return true;
        }

        //speed
        if (check == rs && scheck == false)
        {
            rav -= 1;
            scheck = true;
            return true;
        }
        if (check == es && scheck == false)
        {
            eav -= 1;
            scheck = true;
            return true;
        }

        //peirce
        if (check == lp && pcheck == false)
        {
            lav -= 1;
            pcheck = true;
            return true;
        }

        //crit
        if (check == cc && ccheck == false)
        {
            cav -= 1;
            ccheck = true;
            return true;
        }
        if (check == rc && ccheck == false)
        {
            rav -= 1;
            ccheck = true;
            return true;
        }

        //critdmg
        if (check == rcd && cdcheck == false)
        {
            cav -= 1;
            cdcheck = true;
            return true;
        }
        if (check == ecd && cdcheck == false)
        {
            rav -= 1;
            cdcheck = true;
            return true;
        }
        if (check == lcd && cdcheck == false)
        {
            rav -= 1;
            cdcheck = true;
            return true;
        }

        //soul regen
        if (check == cr && rcheck == false)
        {
            cav -= 1;
            rcheck = true;
            return true;
        }
        if (check == rr && rcheck == false)
        {
            rav -= 1;
            rcheck = true;
            return true;
        }

        //health
        if (check == rh && hcheck == false)
        {
            cav -= 1;
            hcheck = true;
            return true;
        }
        if (check == eh && hcheck == false)
        {
            rav -= 1;
            hcheck = true;
            return true;
        }

        return false;

    }

    //attack speed 
    public void Cas()
    {
        playerref.firerate += 0.1f;
        buttonpressed();
    }
    public void Ras()
    {
        playerref.firerate += 0.3f;
        buttonpressed();
    }
    public void Eas()
    {
        playerref.firerate += 0.4f;
        buttonpressed();
    }
    public void Las()
    {
        playerref.firerate += 0.75f;
        buttonpressed();
    }

    //damage 
    public void Cd()
    {
        playerref.damage += 10;
        buttonpressed();
    }
    public void Rd()
    {
        playerref.damage += 15;
        buttonpressed();
    }
    public void Ed()
    {
        playerref.damage += 20;
        buttonpressed();
    }
    public void Ld()
    {
        playerref.damage += 30;
        buttonpressed();
    }

    //jump
    public void Cj()
    {
        playerref.jumpForce += 2;
        buttonpressed();
    }
    public void Rj()
    {
        playerref.jumpForce += 4;
        buttonpressed();
    }

    //speed
    public void Rs()
    {
        playerref.speed += 2;
        buttonpressed();
    }
    public void Es()
    {
        playerref.speed += 4;
        buttonpressed();
    }

    //pierce
    public void Lp()
    {
        playerref.projpierce += 1;
        buttonpressed();
    }

    //crit chance
    public void Cc()
    {
        playerref.cc += 3;
        buttonpressed();
    }
    public void Rc()
    {
        playerref.cc += 7;
        buttonpressed();
    }

    //crit damage
    public void Rcd()
    {
        playerref.cd += 50;
        buttonpressed();
    }
    public void Ecd()
    {
        playerref.cd += 100;
        buttonpressed();
    }

    public void Lcd()
    {
        playerref.cd += 200;
        buttonpressed();
    }

    //soul regen
    public void Cr()
    {
        playerref.soulgain += 5;
        buttonpressed();
    }
    public void Rr()
    {
        playerref.cc += 7;
        buttonpressed();
    }

    //health
    public void Rh()
    {
        playerref.maxhealth += 1;
        playerref.health += 1;
        playerref.hp.SetText(playerref.health.ToString() + "/" + playerref.maxhealth.ToString());
        buttonpressed();
    }
    public void Eh()
    {
        playerref.maxhealth += 2;
        playerref.health += 2;
        playerref.hp.SetText(playerref.health.ToString() + "/" + playerref.maxhealth.ToString());
        buttonpressed();
    }


    void reset()
    {
        choicesleft = choicesmax;
        cav = cmax;
        rav = rmax;
        eav = emax;
        lav = lmax;

        ascheck = false;
        dcheck = false;
        jcheck = false;
        scheck = false;
        pcheck = false;
        ccheck = false;
        cdcheck = false;
        rcheck = false;
        hcheck = false;
    }



    void buttonpressed()
    {
        reset();
        Time.timeScale = 1f;
        onepick.SetActive(false);
        twopick.SetActive(false);
        threepick.SetActive(false);

        ding = false;
        playerref.levelpause = false;
    }
    //                         butttons 

}
