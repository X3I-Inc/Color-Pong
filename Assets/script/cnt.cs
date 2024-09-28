using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnt : MonoBehaviour
{
    public float Timer = 5.4f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("gameactive") == 1)
        {if (PlayerPrefs.GetInt("pause") == 0)
                {
            if (PlayerPrefs.GetInt("rainb") == 1)
            {
                
                    PlayerPrefs.SetFloat("rtimer", PlayerPrefs.GetFloat("rtimer") - 0.02f);

                    if (PlayerPrefs.GetFloat("rtimer") <= 0)
                    {

                        PlayerPrefs.SetInt("rainb", 0);

                    }

                }
            }
        }
     
    }
}
