using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class tutorial : MonoBehaviour {

    public Text tutorialText;
    public GameObject mainTut;
    int index = 0;
    private void Start()
    {
        if (PlayerPrefs.GetFloat("isTutorialDone") == 0) {
            initiateTutorial();
            setTutorial(langData.t1);
        }
    }
    public void initiateTutorial() {
        mainTut.SetActive(true);
    }

    public void nextTip() {
        if (index == 3)
        {
            mainTut.SetActive(false);
            PlayerPrefs.SetFloat("isTutorialDone", 1);
        }

        else
        {
            switch (index)
            {
                case 0:
                    setTutorial(langData.t2);
                    break;
                case 1:
                    setTutorial(langData.t3);
                    break;
                case 2:
                    setTutorial(langData.t4);
                    break;
            }
            index++;
        }
    }

    void setTutorial(string text) {
        tutorialText.text = text;
    }

}
