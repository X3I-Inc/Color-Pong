using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class skinselectanim : MonoBehaviour
{
    public GameObject upperim;
    public GameObject downim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upperim.GetComponent<Image>().color = downim.GetComponent<Image>().color;
    }
}
