using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charTuzakEtkilesim : MonoBehaviour {

    public GameObject accessScripts;
    Ads ads;
    static private int deathCount;
    public deathController death;


    private void Start()
    {
        ads = accessScripts.GetComponent<Ads>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tuzak") {
            deathCount++;
            if (deathCount > 4)
            {
                ads.ShowAds();
                deathCount = 0;
            }
            death.gameOver();
        } 
    }
}
