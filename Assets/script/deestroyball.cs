using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deestroyball : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject platform;
    public GameObject[] lives;

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (platform.tag == other.tag)
        {
            if (other.gameObject != null && PlayerPrefs.GetInt("live") > 1)
            {
                Destroy(other.gameObject);
            }
            if (PlayerPrefs.GetInt("live") > 0)
            {
                PlayerPrefs.SetInt("live", PlayerPrefs.GetInt("live") - 1);
                lives[PlayerPrefs.GetInt("livec")].SetActive(false);
                PlayerPrefs.SetInt("livec", PlayerPrefs.GetInt("livec") + 1);
            }
        }

        else
        {
            if (other.gameObject != null && PlayerPrefs.GetInt("live") > 0)
            { Destroy(other.gameObject); }
        }
    }
}
