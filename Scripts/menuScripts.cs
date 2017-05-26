using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class menuScripts : MonoBehaviour {

    public GameObject araMenu;
    public bool gamePause;
    public Text status;
    public Text resumebtn;
    public Text mainmenubtn;
    public Text newgamebtn;
    public Text gamescore;

    private void Start()
    {
        gamePause = false;
        if (araMenu.activeSelf) {
            araMenu.SetActive(false);
        }
        if (!gamePause) {
            Time.timeScale = 1.0f;
        }
        setSceneTexts();
    }


    public void loadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void pauseButton() {
        if (gamePause) {
            Time.timeScale = 1.0f;
            araMenu.SetActive(false);
            gamePause = false;
        }

        if (!gamePause)
        {
            Time.timeScale = 0.0f;
            araMenu.SetActive(true);
            gamePause = true;
        }


    }
    public void resumeGame() {
        if (gamePause)
        {
            Time.timeScale = 1.0f;
            araMenu.SetActive(false);
            gamePause = false;
        }
    }

    public void newGameButton() {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1.0f;
    }

    void setSceneTexts()
    {
        status.text = langData.game_status_pause;
        resumebtn.text = langData.resume_button;
        mainmenubtn.text = langData.mainmenu_button;
        newgamebtn.text = langData.newgame_button;
        gamescore.text = langData.game_score;
    }


}
