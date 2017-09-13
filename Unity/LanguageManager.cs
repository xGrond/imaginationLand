using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    string turkLang = "Turkish";
    string engLang = "English";
    static string _langDataString;
    TextAsset xmlPath;
    List<string> data = new List<string>();

    void Start()
    {

        xmlPath = (TextAsset)Resources.Load(getSystemLang(), typeof(TextAsset));
        XmlDocument lanDoc = new XmlDocument();
        lanDoc.LoadXml(xmlPath.text) ;
        XmlNodeList root = lanDoc.GetElementsByTagName("GameMenu");
        setLangData(root);
    }

    string getSystemLang() {
        if (Application.systemLanguage == SystemLanguage.Turkish) {
            _langDataString = turkLang;  
        }
        else _langDataString = engLang;
        return _langDataString;
    }

    void setLangData(XmlNodeList langNodes)
    {
        for (int i = 0; i < langNodes.Count; i++)
        {
            string val = langNodes[i].Attributes["name"].Value;
            switch (val)
            {
                case "best_score":
                    langData.best_score = langNodes[i].InnerText;
                    break;
                case "game_status_pause":
                    langData.game_status_pause = langNodes[i].InnerText;
                    break;
                case "game_status_over":
                    langData.game_status_over = langNodes[i].InnerText;
                    break;
                case "game_score":
                    langData.game_score = langNodes[i].InnerText;
                    break;
                case "resume_button":
                    langData.resume_button = langNodes[i].InnerText;
                    break;
                case "mainmenu_button":
                    langData.mainmenu_button = langNodes[i].InnerText;
                    break;
                case "newgame_button":
                    langData.newgame_button = langNodes[i].InnerText;
                    break;
                case "tutorial_script_1":
                    langData.t1 = langNodes[i].InnerText;
                    break;
                case "tutorial_script_2":
                    langData.t2 = langNodes[i].InnerText;
                    break;
                case "tutorial_script_3":
                    langData.t3 = langNodes[i].InnerText;
                    break;
                case "tutorial_script_4":
                    langData.t4 = langNodes[i].InnerText;
                    break;
            }
            
        }

    }
}