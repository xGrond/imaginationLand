using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charTuzakEtkilesim : MonoBehaviour {

    public GameObject acessMenu;
    public GameObject acessMenuBtn;
    public float bestScore;
    public bool gameOver;
    public GameObject accessKarakter;
    private karakterController karakterController;
    public GameObject accessScripts;
    private Ads ads;
    static private int deathCount;

    private void Start()
    {
        //acessScore = gameObject.GetComponent<krakterMove>().score.ToString();
        karakterController = accessKarakter.GetComponent<karakterController>();
        bestScore = PlayerPrefs.GetFloat("bestScore");
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
            karakterController.gameOver();
        } 
    }

    //menuyu ac
    //scoru ve menu yazisini degistir
    public void hitTuzak() {
        //Karakter olurse x saniye sonra oyunu bitir
        karakterController.isGameRunning = false;
        acessMenu.GetComponent<menuScripts>().araMenu.SetActive(true);
        acessMenuBtn.SetActive(false);
        GameObject.Find("MenuScore").GetComponent<Text>().text = karakterController.score.ToString();
        if (karakterController.score > bestScore) {
            PlayerPrefs.SetFloat("bestScore", karakterController.score);
            PlayerPrefs.Save();
        }
    }
}
