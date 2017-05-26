using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karakterController : MonoBehaviour {

    private float lerpSuresi = 0.5f;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool action;
    private float lerpBitis;
    private Animator anim;
    public bool isGameRunning;
    public int score;
    public GameObject scoreObject;
    public charTuzakEtkilesim tuzakScript;
    private float overTime;
    private bool canFinish;
    public static int tuzakSpawnZorlugu = 1;
    public int ikinciAsama;
    public int ucuncuAsama;
    
    int exPosition = 1;

    //Haraket değerleri
    private const float sol = -3.37f;
    private const float orta = 0f;
    private const float sag = 3.37f;
    private const float uzaklik = 5f;

    void Start()
    {
        ikinciAsama = firstDifPoint();
        tuzakScript = GetComponent<charTuzakEtkilesim>();
        anim = GetComponent<Animator>();
        action = false;
        endPos = transform.position;
        isGameRunning = false;
    }

    //Karakter sag buttona basarsa
    public void sagZipla() {
        if (exPosition == 0)
        {
            lerpSuresi = 0.6f;
            hareket(sag, 0.5f, transform.position.z - uzaklik);
        }
        else
        {
            lerpSuresi = 0.5f;
            hareket(sag, 0.5f, transform.position.z - uzaklik);
        }
        exPosition = 2;
    }
    public void solZipla() {
        if (exPosition == 2)
        {
            lerpSuresi = 0.6f;
            hareket(sol, 0.5f, transform.position.z - uzaklik);
        }
        else
        {
            lerpSuresi = 0.5f;
            hareket(sol, 0.5f, transform.position.z - uzaklik);
        }
        exPosition = 0;
    }

    public void duzZipla() {
        lerpSuresi = 0.5f;
        hareket(orta, 0.5f, transform.position.z - uzaklik);
        exPosition = 1;
    }

    //Karakteri haraket ettir
    //Animasyonu besle
    //Score u guncelle
    void hareket(float x ,float y, float z) {
        if (!action && !canFinish)
        {
            score++;
            gameScoreUpdate(score);
            isGameRunning = true;
            startPos = transform.position;
            endPos = new Vector3(x, y, z);
            anim.SetBool("isJumping", true);
            action = true;
            lerpBitis = Time.time + lerpSuresi;
        }
    }
    
    void Update()
    {
        if (score == ikinciAsama && isGameRunning)
        {
            tuzakSpawnZorlugu = 2;
            ucuncuAsama = secondDifPoint();
        }
        else if (score == ucuncuAsama && isGameRunning)
        {
            tuzakSpawnZorlugu = 3;
        }

        gameEndCounter(overTime);
        karakterMove(endPos, action);
    }

    //karakteri haraket ettir
    public void karakterMove(Vector3 finish, bool tetik)
    {
        
        //eger karakter yerde ise ve drop animasyonu yoksa
        if (tetik) {
            if (Time.time > lerpBitis) {
                action = false;
                anim.SetBool("isJumping", false);
                anim.SetFloat("Blend", 0);
            }
            float t = 1f - (lerpBitis - Time.time) / lerpSuresi;
            anim.SetFloat("Blend", t);
            //t = Mathf.Sin(t * Mathf.PI * 0.5f);
            transform.position = Vector3.Lerp(startPos, finish, t);
            float y = 1 * Mathf.Sin(Mathf.PI * t) + 0.55f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        else
        {
            //anim.SetFloat("Blend", 0.0f);
        }
    }

    public void gameScoreUpdate(float gameScore) {
        scoreObject.GetComponent<Text>().text = gameScore.ToString();
    }

    //ilk asama nerde gerceklescek
    int firstDifPoint() {
       return Random.Range(35, 51);
    }

    //ikinci asama nerde gerceklescek
    int secondDifPoint() {
        return Random.Range(100, 121);
    }



    //Karakterin yok olmasina karar verirsen asagidaki kodlari tasi
    //Karakter olurse gameEndCounter() tetikle
    public void gameOver() {
        tuzakSpawnZorlugu = 1;
        canFinish = true;
        isGameRunning = false;
        overTime = Time.time + 2f;
    }
    //x Saniye sonra oyunu bitir
    void gameEndCounter(float bitisSuresi) {
        if (bitisSuresi < Time.time && canFinish) {
            tuzakScript.hitTuzak();
            canFinish = false;
        }
    }
}
