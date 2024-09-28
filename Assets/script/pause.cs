using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pause : MonoBehaviour
{
    public GameObject cntrl;
    public GameObject empt;
    public GameObject pausemenu;
         // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void menubtn()
    {PlayerPrefs.SetInt("pause", 0);
        if (PlayerPrefs.GetInt("score") - PlayerPrefs.GetInt("bestscore") > 0)
        {
            PlayerPrefs.SetInt("bestscore", PlayerPrefs.GetInt("score"));

        }
        Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
        Vector3 pt = new Vector3(0, 200, 85);
        Instantiate(empt, pt, rotationVal);
        PlayerPrefs.SetInt("losec", 0);
        pausemenu.SetActive(false);
        SceneManager.LoadScene("menu");
    }
    public void continuebtn()
    {
        PlayerPrefs.SetInt("wt", 0);
        Quaternion rotationVal = Quaternion.Euler(0, 0, 0);
        Vector3 pt = new Vector3(0, 0, 85);
        Instantiate(empt, pt, rotationVal);
        cntrl.SetActive(true);
       
      
        PlayerPrefs.SetInt("pause", 0);
  pausemenu.SetActive(false);
    }
}
