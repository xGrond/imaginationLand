using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScripts : MonoBehaviour {

    public Text bestScoreText;
    public float bestScore;

    [SerializeField]
    AudioSource mainMenuMusic;

    [SerializeField]
    Toggle musicToggle;

    [SerializeField]
    Text best_score; 

    private void Start()
    {
        if (PlayerPrefs.GetInt("musicStatus") == 0)
        {
            musicToggle.isOn = true;
        }
        else musicToggle.isOn = false;
        checkMusicStatus();
        bestScore = PlayerPrefs.GetFloat("bestScore");
        bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString();
        setSceneTexts();

    }

    public void loadGame() {
        SceneManager.LoadScene("Level 1");
    }


    void setSceneTexts() {
        if (langData.best_score == null) return;
        else best_score.GetComponent<Text>().text = langData.best_score;
    }

    void setMusicStatus() {
        if (!musicToggle.isOn)
        {
            PlayerPrefs.SetInt("musicStatus", 1);
        }
        else PlayerPrefs.SetInt("musicStatus", 0);
    }

    public void checkMusicStatus() {
        setMusicStatus();
        if (PlayerPrefs.GetInt("musicStatus") == 1)
        {
            mainMenuMusic.Play();
        }
        else mainMenuMusic.Stop();
    }

    public void rateThisApp() {
        Application.OpenURL("market://details?id=com.state.hwhp");
    }
}
