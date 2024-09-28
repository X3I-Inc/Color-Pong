using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class instant : MonoBehaviour
{
    public float Timer = 3f;
    public float speed = 3f;
    public int pcheck;
    public int cl;
    public GameObject obj;
    public Sprite[] skintype;
    public Color[] colorllist;
    public string[] tg;
    public GameObject[] roads;
    public GameObject platform;
    public GameObject[] powers;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      

        if (PlayerPrefs.GetInt("pause") == 0 && GameObject.FindGameObjectWithTag("ball") != null)
        {

            if (PlayerPrefs.GetInt("gameactive") == 1)
            {
                Timer = Timer - 0.02f;
                if (PlayerPrefs.GetInt("rainb") == 1)
                {

                    PlayerPrefs.SetFloat("rtimer", PlayerPrefs.GetFloat("rtimer") - 0.02f);

                    if (PlayerPrefs.GetFloat("rtimer") <= 0)
                    {

                        PlayerPrefs.SetInt("rainb", 0);

                    }

                }
            
            if (Timer <= 0)
                {
                    instan();
                 if (PlayerPrefs.GetInt("score") < 100 && PlayerPrefs.GetInt("timercheck") == 0)
            {
                obj.GetComponent<Rigidbody2D>().gravityScale = 10f;
                Timer = 3f - (PlayerPrefs.GetInt("score") / 40);
                PlayerPrefs.SetInt("timercheck", 1);
            }
            else if (PlayerPrefs.GetInt("score") >= 100 && PlayerPrefs.GetInt("timercheck") == 0)
            {
                Timer = 0.55f;
                obj.GetComponent<Rigidbody2D>().gravityScale = 9f;
                PlayerPrefs.SetInt("timercheck", 1);
            }}
            }
        } }
    public void instan()
    {
       
       
           

            pcheck = Random.Range(0, 5);
            Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
            cl = Random.Range(0, colorllist.Length);

            for (int i = 0; i < 2; i++)
            {

                if (tg[cl] != platform.tag)
                {
                    cl = Random.Range(0, colorllist.Length);

                }
                else { }

            }




            if (PlayerPrefs.GetInt("pause") == 0 && GameObject.FindGameObjectWithTag("ball") != null)
            {
                if (pcheck == 3)
                {
                    GameObject childObject = Instantiate(powers[Random.Range(0, powers.Length)], roads[Random.Range(0, roads.Length)].transform.position, rotationVal);
                    GameObject parentObject = GameObject.FindGameObjectWithTag("ball");
                    childObject.transform.parent = parentObject.transform;
                    if (PlayerPrefs.GetInt("pause") == 1 && childObject != null)
                    {
                        Destroy(childObject);
                    }
                }
                else
                {

                    obj.GetComponent<SpriteRenderer>().sprite = skintype[PlayerPrefs.GetInt("selskin")];
                    if (PlayerPrefs.GetInt("rainb") == 0)
                    {
                        obj.GetComponent<SpriteRenderer>().color = colorllist[cl];
                        obj.tag = tg[cl];
                    }
                    else
                    {
                        obj.GetComponent<SpriteRenderer>().color = platform.GetComponent<SpriteRenderer>().color;
                        obj.tag = platform.tag;
                    }

                    GameObject childObject = Instantiate(obj, roads[Random.Range(0, roads.Length)].transform.position, rotationVal);
                    GameObject parentObject = GameObject.FindGameObjectWithTag("ball");
                    childObject.transform.parent = parentObject.transform;
                 if(PlayerPrefs.GetInt("pause") == 1 && childObject != null)
            {
                Destroy(childObject);
            }}
            }
           
       
      
            PlayerPrefs.SetInt("timercheck", 0);





           
          
           }
        
    
}
