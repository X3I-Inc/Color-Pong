using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game : MonoBehaviour
{
    public Color[] colorllist;
    public GameObject platform;
    public GameObject[] lives;
    public Text score;
    
    public int clp;
    public string[] tgs;
    public float Timer = 0f;
    public GameObject timertext;
    public GameObject losemenu;
    public GameObject cchangepan;
    public GameObject cntrl;
    public AudioSource audioSource;
    public AudioClip clipb;
    public AudioClip clipo;
    public AudioClip clipc;
    public GameObject empt;
    void Start()
    {
        Timer = 0f;
    }
    void FixedUpdate()
    {


       
        if (PlayerPrefs.GetInt("rainb") == 1)
        {
            if (PlayerPrefs.GetInt("pause") == 0)
            {
                
                timertext.GetComponent<Text>().text = Mathf.Round(PlayerPrefs.GetFloat("rtimer")).ToString();
            }
        }
        else
        {
            timertext.GetComponent<Animation>().Stop("rainbtextanim");
            timertext.GetComponent<Text>().text = "";
        }
    
    
 
        

       
        score.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {if (PlayerPrefs.GetInt("gameactive") == 1)
            {
        if (PlayerPrefs.GetInt("live") > 0)
        {
            

                if (this.tag == other.tag)
                {

                    if (PlayerPrefs.GetInt("sound") == 0)
                    {

                        audioSource.PlayOneShot(clipb);
                    }
                    if (other != null && PlayerPrefs.GetInt("live") > 0)
                    {
                        Destroy(other.gameObject);
                    }
                    PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 1);
                    if (PlayerPrefs.GetInt("score") % 17 == 0 && PlayerPrefs.GetInt("score") != 0)
                    {
                       
                        PlayerPrefs.SetInt("pause", 1);
                        if (other != null)
                        {
                            
                            other = null;
                           
                        }
 StartCoroutine(WaitForSecondsDo(4f));

                    }
                }

                else
                {
                    if (other.tag == "bomb")
                    {


                        if (PlayerPrefs.GetInt("sound") == 0)
                        {

                            audioSource.PlayOneShot(clipo);
                        }
                        if (other.gameObject != null && PlayerPrefs.GetInt("live") > 1)
                        {
                            Destroy(other.gameObject);
                        }
                        PlayerPrefs.SetInt("live", 0);



                    }

                    else if (other.tag == "coin" )
                    {
                        if (PlayerPrefs.GetInt("sound") == 0)
                        {
                            audioSource.PlayOneShot(clipc);

                        }
                        if (other.gameObject != null && PlayerPrefs.GetInt("live") > 0)
                        {
                            Destroy(other.gameObject);
                        }
                        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);



                    }

                    else if (other.tag == "rainbow")
                    {timertext.GetComponent<Animation>().Play("rainbtextanim");
                        if (PlayerPrefs.GetInt("sound") == 0)
                        {

                            audioSource.PlayOneShot(clipb);
                        }
                        if (other.gameObject != null && PlayerPrefs.GetInt("live") > 0)
                        {
                            Destroy(other.gameObject);
                        }

                        StartCoroutine(WaitForrainbow(0f));




                    }
                    else
                    {if (other.gameObject != null && PlayerPrefs.GetInt("live") > 1)
                        {
                            Destroy(other.gameObject);
                        }
                        if (PlayerPrefs.GetInt("live") != 0)
                        {
                            PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("live") - 1);
                            lives[PlayerPrefs.GetInt("livec")].SetActive(false);
                            PlayerPrefs.SetInt("livec", PlayerPrefs.GetInt("livec") + 1);
                        }
                    }
                }
            }
           
        }
    }
    public IEnumerator WaitForSecondsDo(float secToWait)
    {     
   
  
       
        yield return new WaitForSeconds(secToWait);
   cchangepan.SetActive(true);
       clp = Random.Range(0, colorllist.Length);
        if (platform.tag == tgs[clp] && clp > 0)
        {
            clp--;
        }
        else if(platform.tag == tgs[clp] && clp == 0)
        {
            clp++;
        }
        platform.GetComponent<SpriteRenderer>().color = colorllist[clp];
        platform.tag = tgs[clp];
        cchangepan.GetComponent<Image>().color = platform.GetComponent<SpriteRenderer>().color;

        yield return new WaitForSeconds(secToWait);
        if (cntrl.activeSelf == true)
        {
            PlayerPrefs.SetInt("pause", 0);
        }
        
  cchangepan.SetActive(false);
    }
    public IEnumerator WaitForrainbow(float secToWait)
    { yield return new WaitForSeconds(secToWait);



        PlayerPrefs.SetFloat("rtimer", PlayerPrefs.GetFloat("rtimer") + 5f);
        PlayerPrefs.SetInt("rainb", 1);
      
        PlayerPrefs.SetInt("pause", 0);
    }
    public void quit()
    {
        Application.Quit();
    }
    }
