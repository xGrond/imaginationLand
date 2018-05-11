using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour {


    GameObject wood;
    GameObject canvas;
    gameUI gameui;
    NewBehaviourScript woodScript;
    bool hitWood;
    bool hitFruit;
    bool drop;
    bool isGameOver;
    float deathTime;

    // Use this for initialization
    void Start () {
        drop = false;
        hitWood = false;
        hitFruit = false;
        wood = GameObject.Find("kutuk");
        woodScript = wood.GetComponent<NewBehaviourScript>();
        canvas = GameObject.Find("Canvas");
        gameui = canvas.GetComponent<gameUI>();
        setDeathTime();
        isGameOver = false;
	}

    void setDeathTime() {
        deathTime = Random.Range(2, 6);
    }

    float lifeTime;
    // Update is called once per frame
    void Update () {
        lifeTime += Time.deltaTime;
        if (lifeTime > 15) Destroy(this.gameObject);

        if (!hitWood)
        {
            KnifeMove();
        }
        if (drop) {
            knifeRotate();
        }

        deathTime -= Time.deltaTime;
        if (deathTime < 0)
        {
            dropAnimation();
        }
    }

    void dropAnimation() {
        PolygonCollider2D col = GetComponent<PolygonCollider2D>();
        col.isTrigger = false;
        col.enabled = false;
        Rigidbody2D rgb = GetComponent<Rigidbody2D>();
        rgb.bodyType = RigidbodyType2D.Dynamic;
        drop = true;
        transform.parent = null;
    }

    void KnifeMove() {
        transform.Translate(0, 25    * Time.deltaTime, 0);
    }

    void knifeRotate() {
        transform.Rotate(0, 0, -60 * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wood")
        {
            transform.parent = wood.transform;
            hitWood = true;
        }

        if (other.gameObject.tag == "fruit")
        {
            if (!isGameOver)
            {
                gameui.increaseScore();
                Destroy(other.gameObject);
                hitFruit = true;
                speedIncrease();
            }
        }

        if(other.gameObject.tag == "2x")
        {
            if (!isGameOver)
            {
                Destroy(other.gameObject);
                hitFruit = true;
                gameui.activateDoublePoint();
            }
        }
        checkIfGameOver(hitWood,hitFruit);
    }

    void checkIfGameOver(bool wood, bool fruit) {
        if (wood && !fruit) {
            isGameOver = true;
            gameui.gameOver();
        }
    }

    void speedIncrease() {
        float speed = woodScript.speed + 0.05f;
        woodScript.speed = speed;
    }


}
