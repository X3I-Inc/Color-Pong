using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class losess : MonoBehaviour
{
    public GameObject rev;
    public Text score;
    public GameObject cntrl;
    public GameObject lose;
    // Start is called before the first frame update
    void Start()
    {
       
        PlayerPrefs.SetInt("losec", 1);
     
        if (PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("bestscore") > 0)
        {
            PlayerPrefs.SetInt("bestscore", PlayerPrefs.GetInt("score"));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("gameactive") == 0)
        {
            score.GetComponent<Text>().text = PlayerPrefs.GetInt("score").ToString();
            if (PlayerPrefs.GetInt("losec") == 0)
            {
                
                cntrl.SetActive(false);
                if (PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("bestscore") > 0)
                {
                    PlayerPrefs.SetInt("bestscore", PlayerPrefs.GetInt("score"));

                }
              
            }
        }
    }

    public void menu()
    {
        PlayerPrefs.SetInt("score", 0);
       
       
        if (GameObject.FindGameObjectWithTag("ball") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("ball"));
        }
        PlayerPrefs.SetInt("lose", PlayerPrefs.GetInt("lose") + 1);
        SceneManager.LoadScene("menu");
     
    }
}
