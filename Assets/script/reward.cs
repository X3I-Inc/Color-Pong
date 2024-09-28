using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class reward : MonoBehaviour
{


 /*
    private string gameId = "3772575";


    Button myButton;
    public string myPlacementId = "rewardedVideo";
*/
    void Start()
    {
       /* myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement’s status:
        if (PlayerPrefs.GetInt("skin" + PlayerPrefs.GetInt("value")) == 0)
        {
            myButton.interactable = Advertisement.IsReady(myPlacementId);
        }
        else
        {
            myButton.interactable = true;
        }
        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        if (PlayerPrefs.GetInt("skin" + PlayerPrefs.GetInt("value")) == 0)
        {

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, false);
        }
        */
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
       /*
            if (PlayerPrefs.GetInt("skin" + PlayerPrefs.GetInt("value")) == 0)
            { Advertisement.Show(myPlacementId);
                
            }
            else
            {
                
            }
        
    */
       
        
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
      /*  if (placementId == myPlacementId)
        {
           
                    myButton.interactable = true;
            
                
            
        }*/
    }

   /* public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {


                // Define conditional logic for each ad completion status:
                if (showResult == ShowResult.Finished)
                {
                PlayerPrefs.SetInt("rewarded", 1);
                PlayerPrefs.SetInt("skin" + PlayerPrefs.GetInt("value"), 1);
          // Reward the user for watching the ad to completion.
                }
            
        
        else if (showResult == ShowResult.Skipped)
        {
          
                PlayerPrefs.SetInt("selskin", 0);
            
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            PlayerPrefs.SetInt("selskin", 0);
            Debug.LogWarning("The ad did not finish due to an error.");
        }*/
    }

  /* public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}*/