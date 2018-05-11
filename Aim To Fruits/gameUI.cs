using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameUI : MonoBehaviour {

    public Text scoreText;
    public GameObject gameOverObj;
    public Text endGameScore;
    public Text doublePointTimeText;
    public GameObject doublePointTimeTextObj;
    public GameObject doubleLogo;
    bool doublePoint;
    float doublePointTime;

    public int score;

    void Start()
    {
        doublePoint = false;
        Time.timeScale = 1.0f;
        score = 0;
    }

    void Update() {
        doublePointTimer();
    }


    public void activateDoublePoint() {
        doublePointTime = 10.5f;
        doublePoint = true;
        if (!doublePointTimeTextObj.activeSelf)
        {
            doublePointTimeTextObj.SetActive(true);
            doubleLogo.SetActive(true);
        }
    }

    void doublePointTimer() {
        if (doublePoint)
        {
            doublePointTimeText.text = Mathf.Round(doublePointTime).ToString();
            doublePointTime -= Time.deltaTime;
            if (doublePointTime < 0.5f)
            {
                doublePoint = false;
                doublePointTimeTextObj.SetActive(false);
                doubleLogo.SetActive(false);
            }
        }
    }

    public void increaseScore()
    {
        if (doublePoint) {
            score = score + 2;
        }
        else score++;
        updateScore(score);
    }

    void updateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void playAgain() {
        SceneManager.LoadScene("mainScene");
    }

    public void gameOver() {
        gameOverObj.SetActive(true);
        endGameScore.text = "Score : " + score.ToString();
        highScore();
        Time.timeScale = 0.0f;       
    }

    void highScore()
    {
        int highScore = PlayerPrefs.GetInt("highScore");
        if (score > highScore) {
            PlayerPrefs.SetInt("highScore", score);
            PlayerPrefs.Save();
        }
    }

}
