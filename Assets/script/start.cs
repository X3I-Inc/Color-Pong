using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public GameObject bgwatch;
    public GameObject losemenu;
    public GameObject pausemenu;

    public GameObject[] lives;
    public GameObject cntrl;
    public Color[] colorllist;
    public float speed = 3f;
    public GameObject obj;
    public GameObject[] roads;
    public GameObject skinsui;
    public Vector2 firstPressPos;
    public Vector2 secondPressPos;
    public Vector2 currentSwipe;
    public GameObject soundbtn;
    public GameObject editbtn;
    public GameObject tutorialbtn;
    public GameObject playbtn;
    public Sprite soundoff;
    public Sprite soundon;
    public GameObject tutorialmenu;
    public GameObject tutplat;// tutorial platform
    public GameObject tutorball; //tutorial ball
    public Text tuttext;
    public GameObject rainbow;
    public GameObject exitbtn;
    public GameObject editimage;
    public GameObject editim;//edit buckground
    public GameObject editcir;//edit skin
    public GameObject editexit;
    public GameObject coin;
    public GameObject bestscore;
    public int bgscheck;
    public Sprite[] backgrounds;//all backgrounds
    public GameObject editexitbtn;//exit edit button
    public GameObject editok;//
    public GameObject bg;
    public int bgn;//selected background
    public GameObject skinicon;
    public GameObject[] selectedskin;
    public Sprite slsk;//ok sprite skin
    public Sprite[] skintype;//background number
    public Sprite seletui;//select
    public Sprite selui;//selected
    public GameObject ok;
    public int[] isbgbuy;//checks if background bought
    public int Money;
    public int[] bgprice;// background price list
    public Text coinamount;//main coin amount
    public Sprite oknull; // prite to buy bg
    public Text oktext;//the
    public GameObject platform;// platform
    public GameObject buycoin; // the coin sprite
    public int[] skinprice;//price of skins
    public int[] isskinbuy;//shows wich skins is bought
    public Text[] pricetext;//texts that need to change to the skin price
    public Text coinamount2;//coin amount in the skin buy
    public int isbgbuyleng = 5;// amount of background if i add backgrounds i need first change this number to overall number of backgrounds(old and new)
    public int isskinbuyleng = 6;// amount of skins if i add skins i need first change this number to overall number of skins(old and new)
    public Sprite adim;
    public int gameactive = 0;
    public float Timer = 3f;
    public int posplatform = 2;
    public int pause = 0;
    public int cl; // color balls
    public int clp; // color platform
    public GameObject[] powers;
    public int pcheck;
    public string[] tg;//tags
    public GameObject bestscoreamount;
    public GameObject empt;
    public GameObject exitappbtn;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ready", 1);
        exitappbtn.SetActive(true);
      
        pausemenu.SetActive(false);
        losemenu.SetActive(false);
        PlayerPrefs.SetInt("pause", 0);
        platform.GetComponent<Animation>().Play("startplatform");

        PlayerPrefs.SetInt("gameactive", 0);


        bgn = PlayerPrefs.GetInt("selectedbg");

        if (PlayerPrefs.GetInt("firsttime") == 1)
        {
            for (int i = 0; i < isbgbuy.Length; i++)
            { PlayerPrefs.SetInt("bg" + i.ToString(), isbgbuy[i]); }
            for (int i = 0; i < isskinbuy.Length; i++)
            { PlayerPrefs.SetInt("skin" + i.ToString(), isskinbuy[i]); }
            tutorial();

            PlayerPrefs.SetInt("firsttime", 0);
        }
       
        if (PlayerPrefs.GetInt("update") == 0)
        {
            for (int i = isbgbuyleng; i < isbgbuy.Length; i++)
            {  isbgbuy[i] = PlayerPrefs.GetInt("bg" + i.ToString());
                
               }
                for (int i = isbgbuyleng; i < isbgbuy.Length; i++)
                { PlayerPrefs.SetInt("bg" + i.ToString(), isbgbuy[i]); }
isbgbuyleng = isbgbuy.Length;
            for (int i = isskinbuyleng; i < isskinbuy.Length; i++)
            {
               
                isskinbuy[i] = PlayerPrefs.GetInt("skin" + i.ToString());
            }
           
                for (int i = isskinbuyleng; i < isskinbuy.Length; i++)
                { PlayerPrefs.SetInt("skin" + i.ToString(), isskinbuy[i]); }
             isskinbuyleng = isskinbuy.Length;
            PlayerPrefs.SetInt("update", 1); }

        else { }
        skinicon.GetComponent<Image>().sprite = skintype[PlayerPrefs.GetInt("selskin")];

        bgscheck = 0;
        soundbtn.GetComponent<Animation>().Play("soundstart");
        tutorialbtn.GetComponent<Animation>().Play("tutstart");
        editbtn.GetComponent<Animation>().Play("editstart");
        coin.GetComponent<Animation>().Play("coinstart");
        bestscore.GetComponent<Animation>().Play("bestscorestart");
        
        bg.GetComponent<Image>().sprite = backgrounds[bgn];
     }

    // Update is called once per frame
    void Update()
    {
       
        
 
        
        bestscoreamount.GetComponent<Text>().text = PlayerPrefs.GetInt("bestscore").ToString();
        Money = PlayerPrefs.GetInt("money");
        if (PlayerPrefs.GetInt("gameactive") == 0)
        { 

            if (PlayerPrefs.GetInt("rewarded") == 1)
            {
                PlayerPrefs.SetInt("rewarded", 0);
                skinsel(PlayerPrefs.GetInt("value"));
            }
            coinamount2.GetComponent<Text>().text = Money.ToString();
            coinamount.GetComponent<Text>().text = Money.ToString();
            if (PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 1)
            {
                buycoin.SetActive(false);
                bgwatch.SetActive(false);
                if (PlayerPrefs.GetInt("selectbg") == PlayerPrefs.GetInt("selectedbg"))
                {
                    oktext.GetComponent<Text>().text = "";
                    ok.GetComponent<Image>().sprite = selui;
                }
                else
                {
                    oktext.GetComponent<Text>().text = "";
                    ok.GetComponent<Image>().sprite = seletui;
                }
            }
            else
            {
                if (bgprice[PlayerPrefs.GetInt("selectbg")] != 192837465)
                {
                    ok.GetComponent<Button>().interactable = true;
                    ok.GetComponent<Image>().sprite = oknull;
                    oktext.GetComponent<Text>().text = bgprice[PlayerPrefs.GetInt("selectbg")].ToString();
                    buycoin.SetActive(true);
                    bgwatch.SetActive(false);
                    ok.SetActive(true);
                }
                if (bgprice[PlayerPrefs.GetInt("selectbg")] == 192837465)
                {
                    ok.GetComponent<Image>().sprite = oknull;
                    oktext.GetComponent<Text>().text = "Watch ad";

                    buycoin.SetActive(false);
                    bgwatch.SetActive(true);
                }
            }
            for (int i = 0; i < isskinbuy.Length; i++)
            {
                if (PlayerPrefs.GetInt("skin" + i.ToString()) == 1)
                {


                    if (i == PlayerPrefs.GetInt("selskin"))
                    {
                        selectedskin[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                        selectedskin[PlayerPrefs.GetInt("selskin")].GetComponent<Image>().sprite = slsk;
                        pricetext[i].GetComponent<Text>().text = "";
                    }
                    else
                    {
                        pricetext[i].GetComponent<Text>().text = "";
                        selectedskin[i].GetComponent<Image>().color = new Color(0, 0, 0, 0);
                    }


                }
                else
                {


                    if (i == 7 || i == 6)
                    {

                        pricetext[i].GetComponent<Text>().text = "Watch ad to get free";
                        selectedskin[i].GetComponent<Image>().sprite = adim;
                    }
                    if (i != 7 && i != 6)
                    {

                        selectedskin[i].GetComponent<Image>().sprite = coin.GetComponent<Image>().sprite;
                        pricetext[i].GetComponent<Text>().text = skinprice[i].ToString();
                    }
                }
            }

if (ok.activeSelf && bgscheck == 0)
            {
                
              
                ok.SetActive(false);
            }
            backgroundselect();
            if (PlayerPrefs.GetInt("aend") == 1)
            {
                editimage.SetActive(false);

                PlayerPrefs.SetInt("aend", 0);
                editbtn.SetActive(true);
            }
            tuttext.GetComponent<Text>().color = tutplat.GetComponent<Image>().color;
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                soundbtn.GetComponent<Image>().sprite = soundon;

            }
            else
            {
                soundbtn.GetComponent<Image>().sprite = soundoff;
            }
        }
        else
        {

            if (PlayerPrefs.GetInt("pause") == 0)
            {

                if (GameObject.FindGameObjectWithTag("ball") == null)
                {


                    Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
                    Vector3 pt = new Vector3(0, 200, 85);
                    Instantiate(empt, pt, rotationVal);
                }
                if (PlayerPrefs.GetInt("live") <= 0)
                {
                    PlayerPrefs.SetFloat("rtimer", 0);
                    PlayerPrefs.SetInt("rainb", 0);
                    PlayerPrefs.SetInt("gameactive", 0);
                    if (PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("bestscore") > 0)
                    {
                        PlayerPrefs.SetInt("bestscore", PlayerPrefs.GetInt("score"));

                    }
                    posplatform = 2;



                    Vector3 p = roads[2].transform.position;
                    platform.transform.position = new Vector3(p.x, -140, 85);
                    
                    losemenu.SetActive(true);

                    if (GameObject.FindGameObjectWithTag("ball") != null)
                    {cntrl.SetActive(false);
                        Destroy(GameObject.FindGameObjectWithTag("ball"));
                    }

                }
           
                   
                    
                   
            }
                   
        }
       
            if (PlayerPrefs.GetInt("ready") == 0)
            {
                cntrl.SetActive(true);

                PlayerPrefs.SetInt("gameactive", 1);
                PlayerPrefs.SetInt("livec", 0);
                while (PlayerPrefs.GetInt("live") != 3)
                {
                    lives[PlayerPrefs.GetInt("live")].SetActive(true);
                    PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("live") + 1);

                }
                losemenu.SetActive(false);
                PlayerPrefs.SetInt("ready", 1);

            }
        
        
    }

    public void restart()
    {
        if (PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("bestscore") > 0)
        {
            PlayerPrefs.SetInt("bestscore", PlayerPrefs.GetInt("score"));

        }
       
        Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
        Vector3 pt = new Vector3(0, 200, 85);
        Instantiate(empt, pt, rotationVal);
        clp = Random.Range(0, colorllist.Length);
        platform.GetComponent<SpriteRenderer>().color = colorllist[clp];
        platform.tag = tg[clp];
        
        
       
       
        posplatform = 2;
        Vector3 p = roads[posplatform].transform.position;
        platform.transform.position = new Vector3(p.x, -140, 85);
        cntrl.SetActive(true);
while (PlayerPrefs.GetInt("live") != 3)
        {
            lives[PlayerPrefs.GetInt("live")].SetActive(true);
            PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("live") + 1);
        }
       
        losemenu.SetActive(false);
        PlayerPrefs.SetInt("lose", PlayerPrefs.GetInt("lose") + 1);
 PlayerPrefs.SetInt("livec", 0);
        PlayerPrefs.SetInt("score", 0);
 PlayerPrefs.SetInt("wt", 0);
        PlayerPrefs.SetInt("gameactive", 1);
        PlayerPrefs.SetInt("pause", 0);
 pause = 0;


    }
   
    public void sound()
    {
        soundbtn.GetComponent<Animation>().Play("clicksound");
       
            if (PlayerPrefs.GetInt("sound") == 0)
        {
           
            PlayerPrefs.SetInt("sound", 1); }
       else
        { PlayerPrefs.SetInt("sound", 0); }



        }
    public void Play()
       {
        PlayerPrefs.SetInt("rtimer", 0);
        exitappbtn.SetActive(false);
        PlayerPrefs.SetInt("rainb", 0);
        PlayerPrefs.SetInt("wt", 0);
        posplatform = 2;
        Vector3 p = roads[posplatform].transform.position;
        platform.transform.position = new Vector3(p.x, -140, 85);
        Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
        Vector3 pt = new Vector3(0, 200, 85);
        Instantiate(empt, pt, rotationVal);
        PlayerPrefs.SetInt("times", 0);
       
        PlayerPrefs.SetInt("live", 0);
        while (PlayerPrefs.GetInt("live") != 3)
        {
            lives[PlayerPrefs.GetInt("live")].SetActive(true);
            PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("live")+1);
        }
        PlayerPrefs.SetInt("livec", 0);
        PlayerPrefs.SetInt("score", 0);
        platform.GetComponent<Animation>().Stop("startplatform");
        clp = Random.Range(0, colorllist.Length);
        platform.GetComponent<SpriteRenderer>().color = colorllist[clp];
        platform.tag = tg[clp];
        editimage.SetActive(false);
          playbtn.GetComponent<Animation>().Play("playclick");
       StartCoroutine(WaitForSecondsDo(0.3f));
        PlayerPrefs.SetInt("losec", 0);
        PlayerPrefs.SetInt("gameactive",1);
        pause = 0;


    }
   public IEnumerator WaitForSecondsDo(float secToWait)
    {
        
        yield return new WaitForSeconds(secToWait);
        playbtn.GetComponent<Animation>().Play("playout");
        tutorialbtn.GetComponent<Animation>().Play("tutorout");
        editbtn.GetComponent<Animation>().Play("editoutg");
        soundbtn.GetComponent<Animation>().Play("soundout");
        coin.GetComponent<Animation>().Play("coinout");
        cntrl.SetActive(true);
        bestscore.GetComponent<Animation>().Play("bestscoreout");
        playbtn.SetActive(false);
    }
    public void plright()
    {
        if (pause == 0 && posplatform != 4)
        {
            posplatform++;
            Vector3 p = roads[posplatform].transform.position;
            platform.transform.position = new Vector3(p.x, -140, 85);
        }
     
    }
    public void plleft()
    {
        if (pause == 0 && posplatform != 0)
        {
            posplatform--;
            Vector3 p = roads[posplatform].transform.position;
            platform.transform.position = new Vector3(p.x, -140, 85);
        }
    }
    public void pausebtn()
    {
 PlayerPrefs.SetInt("pause", 1);
        posplatform = 2;
        Vector3 p = roads[posplatform].transform.position;
        platform.transform.position = new Vector3(p.x, -140, 85);
        if (GameObject.FindGameObjectWithTag("ball") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("ball"));
        }
      
cntrl.SetActive(false);
        pausemenu.SetActive(true);
       
      
       
    }
    public void tutorial()
    {
        
        tutorialbtn.GetComponent<Animation>().Play("tutorialclick");
        tutorialmenu.GetComponent<Animation>().Play("tutdown");
        tutplat.GetComponent<Animation>().Play("tutball");
        tutorball.GetComponent<Animation>().Play("ballcolor");
        rainbow.GetComponent<Animation>().Play("rainbow");
    }
    public void tutorialup()
    {
       
        tutorialmenu.GetComponent<Animation>().Play("tutup");
        tutplat.GetComponent<Animation>().Stop("tutball");
        tutorball.GetComponent<Animation>().Stop("ballcolor");
        rainbow.GetComponent<Animation>().Stop("rainbow");
    }
    public void editon()
    {

        editimage.SetActive(true);
       
        editimage.GetComponent<Animation>().Play("edit");
        editim.GetComponent<Animation>().Play("editim");
        editcir.GetComponent<Animation>().Play("editci");
        editexit.GetComponent<Animation>().Play("editx");
        editbtn.SetActive(false);
    }
    public void editoff()
    {
        editbtn.SetActive(true);
    
    editimage.GetComponent<Animation>().Play("editout");
        editim.GetComponent<Animation>().Play("editimout");
        editcir.GetComponent<Animation>().Play("editciout");
        editexit.GetComponent<Animation>().Play("editxout");
        PlayerPrefs.SetInt("animtimer", 1);


    }
    public void backgroundselect() {
        if (bgscheck == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //save began touch 2d point
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                  
                    firstPressPos = new Vector2(0, 0);
                    secondPressPos = new Vector2(0, 0);
                    currentSwipe = new Vector2(0, 0);
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f )
                {
                    
                    firstPressPos = new Vector2(0,0);
                    secondPressPos = new Vector2(0, 0);
                    currentSwipe = new Vector2(0, 0);
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && firstPressPos.y > 500.0f)
                {
                 
                    if (PlayerPrefs.GetInt("selectbg") < bgprice.Length - 1)
                    {
                        PlayerPrefs.SetInt("selectbg", PlayerPrefs.GetInt("selectbg") + 1);
                    }
                   
                    firstPressPos = new Vector2(0, 0);
                    secondPressPos = new Vector2(0, 0);
                    bg.GetComponent<Image>().sprite = backgrounds[PlayerPrefs.GetInt("selectbg")];
                    if (bgn == PlayerPrefs.GetInt("selectbg"))
                    {
                        ok.GetComponent<Image>().sprite = selui;
                    }
                    else { ok.GetComponent<Image>().sprite = seletui; }
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f && firstPressPos.y > 500.0f)
                {
                

                    if (PlayerPrefs.GetInt("selectbg") > 0)
                    {
                        PlayerPrefs.SetInt("selectbg", PlayerPrefs.GetInt("selectbg") - 1);
                    }
                    bg.GetComponent<Image>().sprite = backgrounds[PlayerPrefs.GetInt("selectbg")];
                   
                    firstPressPos = new Vector2(0, 0);
                    secondPressPos = new Vector2(0, 0);
                    currentSwipe = new Vector2(0, 0);
                }
            }

        }
    } 
    public void bgs()
    {
        PlayerPrefs.SetInt("selectbg", bgn);
        if (PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 1)
        {
            buycoin.SetActive(false);

            if (bgn == PlayerPrefs.GetInt("selectedbg"))
            {
                oktext.GetComponent<Text>().text = "";
                ok.GetComponent<Image>().sprite = selui;
            }
            else {
                oktext.GetComponent<Text>().text = "";
                ok.GetComponent<Image>().sprite = seletui; }
        }
        else
        {
            ok.GetComponent<Image>().sprite = oknull;
            oktext.GetComponent<Text>().text = bgprice[PlayerPrefs.GetInt("selectbg")].ToString();
            buycoin.SetActive(true);
        }
        playbtn.SetActive(false);
        editbtn.SetActive(false);
        tutorialbtn.SetActive(false);
        soundbtn.SetActive(false);
        bestscore.SetActive(false);
        platform.SetActive(false);
        editimage.SetActive(false);
        editexitbtn.SetActive(true);
        editok.SetActive(true);
        bgscheck = 1;
        
       
          
        
    }

    public void select()
    {
        if (PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 1)
        {
            PlayerPrefs.SetInt("selectedbg", PlayerPrefs.GetInt("selectbg"));
           
        }
        else {buybg(); }

    }
    public void exitselect()
    {
     
       
        bgscheck = 0;
        SceneManager.LoadScene("menu");
        editexitbtn.SetActive(false);
        editok.SetActive(false);
    }
     public void skin() {//selected
       
            skinsui.SetActive(true);
        coin.SetActive(false);
        

    }   
    public void exsk()
    {
        skinsui.SetActive(false);
        SceneManager.LoadScene("menu");
    }
    public void skinsel(int sel)
    {
        if (PlayerPrefs.GetInt("skin" + sel )== 1)
            {
            PlayerPrefs.SetInt("selskin", sel);
        }
        else
        {
            buyskin(sel);
        }
        
    }
    public void buybg()
    {

        if (bgprice[PlayerPrefs.GetInt("selectbg")] != 192837465)
        {
            PlayerPrefs.SetInt("bgf", 0);
            if (bgprice[PlayerPrefs.GetInt("selectbg")] <= Money)
            {
                PlayerPrefs.SetInt("bg" + PlayerPrefs.GetInt("selectbg"), 1);
                Money = Money - bgprice[PlayerPrefs.GetInt("selectbg")];
                PlayerPrefs.SetInt("money", Money);
                oktext.GetComponent<Text>().text = "";
            }
        }
        if (bgprice[PlayerPrefs.GetInt("selectbg")] == 192837465)
        {
            PlayerPrefs.SetInt("bgf", 1);



        }
    }
    public void buyskin(int val)
    {if (val == 6 || val == 7)
        {
            
            PlayerPrefs.SetInt("value", val);
        }
        else
        {
            if (skinprice[val] <= Money)
            {
                PlayerPrefs.SetInt("skin" + val, 1);
                Money = Money - skinprice[val];
                PlayerPrefs.SetInt("money", Money);
                pricetext[val].GetComponent<Text>().text = "";
                skinsel(val);
            }
           
        }
    }
   
}
