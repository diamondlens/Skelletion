using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulbar : MonoBehaviour
{

    public player playerref;
    private float soul;
    private float soulmax;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            soul = playerref.soul;
            soulmax = playerref.maxsoul;
        transform.localScale = new Vector3(1.090337f , (soul / soulmax) * 1.003262f, 3618797f);

        ///transform.position = new Vector3( +(soul / soulmax), 27, 0);
    }
}
