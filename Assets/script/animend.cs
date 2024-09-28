using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animend : MonoBehaviour
{
    public float animatend;
    // Start is called before the first frame update
    void Start()
    {
        animatend = 0.4f;   
    }

    // Update is called once per frame
    void FixeedUpdate()
    {if (PlayerPrefs.GetInt("animtimer") == 1)
        {
            animatend -= 0.02f;
            if (animatend < 0)
            {
                PlayerPrefs.SetInt("aend", 1);
                animatend = 0.4f;
                PlayerPrefs.SetInt("animtimer", 0);
            }
           
        }
    }
}
