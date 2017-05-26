using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class krakterMove : MonoBehaviour
{
    public int score = 000;
    float zKonum = 7.2f;
    public GameObject kamera;
    public Vector3 solKutu;

    private void Start()
    {
        solKutu = new Vector3(1.43f, 1.5f, zKonum - 2.4f * score);
    }


    public void sagMove()
    {
        if (Time.timeScale != 1.0f == false)
        {
            Time.timeScale = 1.0f;

        }
        if (kamera.transform.position.z - gameObject.transform.position.z <= -9.2 && score > 3)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(1.43f, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
        if (score < 4)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(1.43f, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
    }

    public void solMove()
    {
        if (Time.timeScale != 1.0f == false)
        {
            Time.timeScale = 1.0f;

        }
        if (kamera.transform.position.z - gameObject.transform.position.z <= -9.2 && score > 3)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(-1.43f, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
        if (score < 4)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(-1.43f, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
    }

    public void duzMove()
    {
        if (Time.timeScale != 1.0f == false)
        {
            Time.timeScale = 1.0f;

        }
        if (kamera.transform.position.z - gameObject.transform.position.z <= -9.2 && score > 3)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(0, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
        if (score < 4)
        {
            score++;
            GameObject.Find("karakter").transform.position = new Vector3(0, 1.5f, zKonum - 2.4f * score);
            scoreUpdate();
        }
    }

    public void scoreUpdate()
    {
        GameObject.Find("score").GetComponent<Text>().text = score.ToString();

    }


    // Update is called once per frame
    void Update()
    {

        //sola basilirsa
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject.Find("karakter").transform.Translate(new Vector3(-1.43f, 0, -2.4f));
        }

        //saga basilirsa 
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject.Find("karakter").transform.Translate(new Vector3(1.43f, 0, -2.4f));
        }

        //asagi basilirsa
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject.Find("karakter").transform.Translate(new Vector3(0, 0, -2.4f));
        }
    }
}
