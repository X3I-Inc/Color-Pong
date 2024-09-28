using UnityEngine;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class skipad : MonoBehaviour
{ 

    //string gameId = "3772575";
    //bool testMode = false;

    void Start()
    {
        // Initialize the Ads service:
        //if (PlayerPrefs.GetInt("lose") >= 8)
      //  { Advertisement.Initialize(gameId, testMode); }
       }

    /*public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
     
        if (PlayerPrefs.GetInt("lose") >= 8)
        {
           // if (Advertisement.IsReady())
          //  {
               PlayerPrefs.SetInt("wt", 0);
              PlayerPrefs.SetInt("gameactive", 0);
               PlayerPrefs.SetInt("lose", 0);

             //   Advertisement.Show();

            }

            else
            {
                PlayerPrefs.SetInt("wt", 0);
                PlayerPrefs.SetInt("gameactive", 1);
                PlayerPrefs.SetInt("lose", 0);
              
                Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
            }
        }
    }*/
  /*  private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                PlayerPrefs.SetInt("wt", 0);
                PlayerPrefs.SetInt("gameactive", 1);
                PlayerPrefs.SetInt("lose", 0);
                break;
            case ShowResult.Skipped:
                PlayerPrefs.SetInt("wt", 0);
                PlayerPrefs.SetInt("gameactive", 1);
                PlayerPrefs.SetInt("lose", 0);
                break;
            case ShowResult.Failed:

                PlayerPrefs.SetInt("wt", 0);
                PlayerPrefs.SetInt("gameactive", 1);
                PlayerPrefs.SetInt("lose", 0);
                break;
        }
    }*/
}