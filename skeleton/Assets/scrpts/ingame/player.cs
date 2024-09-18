using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Drawing.Drawing2D;

public class player : MonoBehaviour
{
    public UnityEvent dash;
    public UnityEvent rightclick;

    float speed;
    public float speedbase;
    public float speedmod = 100;
    float jumpForce;
    public float jumpbase;
    public float jumpmod = 100;

    public itemcont itemcont;

    int level = 0;
    float XPness;
    float XP;
    public bool levelpause = false;

    public float maxhealth;
    public float health;
    public float invertime;
    float invertimer;
    public TMP_Text hp;


    public float damage;
    public float damagebase;
    public float damagemod = 100;
    public float projectilespeed;
    public int projpierce;
    public float cc = 5;
    public float cd = 200;

    public float dashcost;
    public float dashforce;
    public float dashtime;
    float dashdirection;
    float timer;

    float originalgrav;
    bool tangible = true;
    BoxCollider2D bc;

    Rigidbody2D rb;
    float inputX;

    private RaycastHit2D climbray;
    private bool climb = false;
    float climbspeed;
    public float climbspeedbase;
    private RaycastHit2D noclimbray;
    private RaycastHit2D noclimbray2;
    bool ding = false;

    bool isGrounded;
    public LayerMask whatIsGroundLayer;


    float shootcd;
    float firerate;
    public float fireratebase;
    public float fireratemod = 100;

    public GameObject projectile;
    private Vector3 mousepos;

    public float soul;
    public float maxsoul;
    public GameObject bar;
    float soulgain;
    public float soulgainbase;
    public float soulgainmod = 100;

    public GameObject loss;
    public TMP_Text scoreT;
    float score = 0;

    public float localplayertime;

    bool hit = false;

    public bool rightping = false;
    float Ysave;


    void Awake()
    {
        dash = new UnityEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        Resetstats();

        rb = GetComponent<Rigidbody2D>();
        //TextMeshPro hp = GetComponent<health>();
        originalgrav = rb.gravityScale;
        bc = GetComponent<BoxCollider2D>();
        health = maxhealth;
        hp.text = health.ToString() + "/" + maxhealth.ToString();

        XPness = levelcalc(level);

        Physics2D.IgnoreLayerCollision(0, 6, false);
        Physics2D.IgnoreLayerCollision(0, 8, false);
        Physics2D.IgnoreLayerCollision(0, 3, false);
    }


    // Update is called once per frame
    void Update()
    {

        localplayertime = Time.deltaTime;
        if (Time.timeScale > 0)
        {
            localplayertime = Time.deltaTime / Time.timeScale;
        }



        //movement
        inputX = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded == true && climb == false)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }

        if (invertimer > 0)
        {
            invertimer -= Time.deltaTime;
            if (invertimer <= 0)
            {
                Physics2D.IgnoreLayerCollision(0, 6, false);
                Physics2D.IgnoreLayerCollision(0, 8, false);
                hit = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && tangible == true && soul >= dashcost)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = dashforce * speed / 10f * Vector2.up;
                dashdirection = 1;
                Gravity();
                //if (dash != null)
                //{
                dash.Invoke();
                //}

            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = dashforce * speed / 10f * Vector2.left;
                dashdirection = 4;
                Gravity();
                if (dash != null)
                {
                    dash.Invoke();
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = dashforce * speed / 10f * Vector2.down;
                dashdirection = 3;
                Gravity();
                if (dash != null)
                {
                    dash.Invoke();
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = dashforce * speed / 10f * Vector2.right;
                dashdirection = 2;
                Gravity();
                if (dash != null)
                {
                    dash.Invoke();
                }
            }
        }
        if (tangible == false)
        {
            timer -= Time.deltaTime;
            invertimer = 0.7f;
            if (timer < 0.005)
            {
                // bc.enabled = true;
                Physics2D.IgnoreLayerCollision(0, 3, false);
                rb.velocity = new Vector2(0, 0);
            }
            if (timer < 0)
            {
                tangible = true;
                rb.gravityScale = originalgrav;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (shootcd < 0 && tangible == true)
            {
                shoot();

            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightclick.Invoke();
        }


        if (shootcd >= 0)
        {
            shootcd -= localplayertime;
        }

        if (climb == true && Input.GetKey(KeyCode.W) && tangible == true)
        {
            rb.velocity = new Vector2(0, climbspeed);
            inputX = 0;
        }
        if (ding == true && tangible == true)
        {
            rb.velocity = new Vector2(0, 0);
            ding = false;
        }




        //                                                 ~soul~
        if (soul <= maxsoul)
        {
            soul += soulgain * Time.deltaTime;
            if (soul > maxsoul)
            {
                soul = maxsoul;
            }
        }


    }

    void shoot()
    {
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((mousepos.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2))) / ((mousepos.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2)))) * (180 / Mathf.PI));




        if ((mousepos.x - transform.position.x) < 0)
        {   
            spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan(((mousepos.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2))) / ((mousepos.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2)))) * (180 / Mathf.PI) + 180);
        }

        GameObject clone = Instantiate(projectile, transform.position, spawnRotation);
        clone.SetActive(true);

        Rigidbody2D clonerb = clone.GetComponent<Rigidbody2D>();
        //clonerb.AddForce((Vector3.Normalize(mousepos - transform.position)) * projectilespeed, ForceMode2D.Impulse);
        clonerb.AddForce((new Vector3((mousepos.x - transform.position.x) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2)), (mousepos.y - transform.position.y) / Mathf.Sqrt(Mathf.Pow((mousepos.x - transform.position.x), 2) + Mathf.Pow((mousepos.y - transform.position.y), 2)))) * projectilespeed, ForceMode2D.Impulse);
        shootcd = 1 / firerate;
    }

    void Gravity()
    {
        tangible = false;
        timer = dashtime;
        rb.gravityScale = 0;
        //bc.enabled = false;
        Physics2D.IgnoreLayerCollision(0, 6, true);
        Physics2D.IgnoreLayerCollision(0, 3, true);
        Physics2D.IgnoreLayerCollision(0, 8, true);
        soul -= dashcost;
        climb = false;

    }

    void FixedUpdate()
    {
        if (tangible)
        {
            rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int layer_mask = LayerMask.GetMask("ground");
        climbray = Physics2D.Raycast(transform.position + Vector3.down * 2, Vector3.down, Mathf.Infinity, layer_mask);
        if (climbray.collider.gameObject.CompareTag("Floor") && climbray.collider.gameObject != collision.gameObject && collision.gameObject.CompareTag("Floor"))
        {
            climb = true;
        }

        noclimbray = Physics2D.Raycast(transform.position + Vector3.up * 2, Vector3.right, Mathf.Infinity, layer_mask);
        if (noclimbray.collider != null)
        {
            if (noclimbray.collider.gameObject.CompareTag("Floor") && noclimbray.collider.gameObject == collision.gameObject)
            {
                climb = false;
            }
        }

        noclimbray2 = Physics2D.Raycast(transform.position + Vector3.up * 2, Vector3.left, Mathf.Infinity, layer_mask);
        if (noclimbray2.collider != null)
        {
            if (noclimbray2.collider.gameObject.CompareTag("Floor") && noclimbray2.collider.gameObject == collision.gameObject)
            {
                climb = false;
            }
        }

        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
            ding = false;
        }

        ////damage

        if (collision.gameObject.CompareTag("Enemy") && hit == false)
        {

            health = health - 1f;
            hp.SetText(health.ToString() + "/" + maxhealth.ToString());
            invertimer = invertime;
            Physics2D.IgnoreLayerCollision(0, 6, true);
            Physics2D.IgnoreLayerCollision(0, 8, true);
            hit = true;
            if (health <= 0f)
            {
                //die

                Gravity();
                timer = 10000000;
                rb.velocity = new Vector2(0, 0);
                loss.SetActive(true);
            }
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        climbray = Physics2D.Raycast(transform.position + Vector3.down * 2, Vector3.down);
        if (climbray.collider.gameObject.CompareTag("Floor") && climbray.collider.gameObject == collision.gameObject)
        {
            climb = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deathbox"))
        {
            Gravity();
            timer = 10000000;
            rb.velocity = new Vector2(0, 0);
            loss.SetActive(true);
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            score += 1;
            scoreT.SetText(score.ToString());
            XP += 5;
        }

        if (XP >= XPness)
        {
            //levelup;
            level += 1;
            levelpause = true;
            XPness = levelcalc(level);
            XP = 0;
        }

        if (collision.gameObject.CompareTag("chest"))
        {
            itemcont.begin();
        }
    }

    private float levelcalc(float X)
    {
        return 9 + (Mathf.Pow(5, 53 * X / 125) / (1 + Mathf.Pow(3, (X - 5) / 2)));
    }

    private void OnCollisionExit2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Floor"))
        {
            if (climb == true)
                ding = true;
            isGrounded = false;
            climb = false;
            //Debug.Log(ding);
        }
    }

    public void Resetstats()
    {

        speed = speedbase * speedmod / 100;
        climbspeed = climbspeedbase * speed / 10;
        jumpForce = jumpbase * jumpmod / 100;
        damage = damagebase * damagemod / 100;
        firerate = fireratebase * fireratemod / 100;
        soulgain = soulgainbase* soulgainmod / 100;
    }
}
