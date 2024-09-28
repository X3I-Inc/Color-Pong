using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class rewardbg : MonoBehaviour
{



    //private string gameId = "3772575";

    public GameObject ptext;
    Button myButton;
   // public string myPlacementId = "rewardedVideo";

    void Start()
    {
       // myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        

        // Map the ShowRewardedVideo function to the button’s click listener:
        //if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:

       // Advertisement.AddListener(this);
        if (PlayerPrefs.GetInt("bgf") == 1)
        {
            if (PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 0)
            {
              // Advertisement.Initialize(gameId, false);
            }
        }
    }
    void Update()
    {
if (ptext.GetComponent<Text>().text == "Watch ad" && PlayerPrefs.GetInt("bgf") == 1)
        {
         //   myButton.interactable = Advertisement.IsReady(myPlacementId);
        }
        else
        {
           // myButton.interactable = true;
        }
    }
    }
    // Implement a function for showing a rewarded video ad:
    /*void ShowRewardedVideo()
    {
        
        if (PlayerPrefs.GetInt("bgf") == 1)
        {
            if (PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 0)
            {
              //  Advertisement.Show(myPlacementId);

            }
            else
            {

            }
        }


    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        //if (placementId == myPlacementId && PlayerPrefs.GetInt("bg" + PlayerPrefs.GetInt("selectbg")) == 0 )
        //{
           

             ///   myButton.interactable = true;



       // }
    }

   // public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
   // {


        // Define conditional logic for each ad completion status:
       // if (showResult == ShowResult.Finished)
       // {
          
          //  PlayerPrefs.SetInt("bg" + PlayerPrefs.GetInt("selectbg"), 1);
            // Reward the user for watching the ad to completion.
        }


       else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
} */