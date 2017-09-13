using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deathController : MonoBehaviour {

    public karakterController controller;
    public ParticleSystem deathEffect;
    public GameObject karakter;
    public menuScripts menuScript;
    public GameObject resumeButton;
    public Text mainScore;

    // Use this for initialization
    void Start() {
        controller = controller.GetComponent<karakterController>();
        menuScript = menuScript.GetComponent<menuScripts>();
    }

    //Oyunu kismen bitir
    public void gameOver() {
        controller.canFinish = true;
        controller.isGameRunning = false;
        Destroy(Instantiate(deathEffect.gameObject, karakter.transform.position, Quaternion.Euler(-20, 0, 0)) as GameObject, 2);
        DestroyObject(karakter);
        StartCoroutine(olumSayici());
    }

    IEnumerator olumSayici()
    {
        yield return new WaitForSeconds(2f);
        whenHitTrap();
    }

    //Oyunu tamamen bitir
    public void whenHitTrap() {
        controller.isGameRunning = false;
        resumeButton.SetActive(false);
        mainScore.text = controller.score.ToString();
        menuScript.araMenu.SetActive(true);
        setHighScore();
    }

    void setHighScore() {
        float bestScore = PlayerPrefs.GetFloat("bestScore");
        if (controller.score > bestScore)
        {
            PlayerPrefs.SetFloat("bestScore", controller.score);
            PlayerPrefs.Save();
        }
        else return;
    }
}
