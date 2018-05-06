using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuUI : MonoBehaviour {

    public Text hightScoreText;

    public void loadScene() {
        SceneManager.LoadScene("mainScene");
    }

    void Start() {
        setHighScore();

    }

    void setHighScore() {
        int highScore = PlayerPrefs.GetInt("highScore");
        hightScoreText.text = "High Score : " + highScore;
    }

}
