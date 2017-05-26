using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScripts : MonoBehaviour {

    public Text bestScoreText;
    public float bestScore;

    [SerializeField]
    Text best_score; 

    private void Start()
    {
        bestScore = PlayerPrefs.GetFloat("bestScore");
        bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString();
        setSceneTexts();
    }

    public void loadGame() {
        SceneManager.LoadScene("Level 1");
    }


    void setSceneTexts() {
        best_score.GetComponent<Text>().text = langData.best_score;
    }

}
