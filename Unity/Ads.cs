using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour {

    public string gameID;
    public bool isTestMode;


    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID, isTestMode);
        }
        else return;
    }

    public void ShowAds() {
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else return;
    }
}
