using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject fruit;
    public GameObject fruit2;
    public GameObject fruit3;
    public GameObject doubleP;
    public GameObject location;
    public GameObject kutuk;
    bool checkStatus;

	// Use this for initialization
	void Start () {
        checkStatus = true;
        setSpawnDelay();
    }

    float jumpTime = 0;
    void Update() {
        isSpawnable();
        if (Time.time >= jumpTime && checkStatus == true)
        {
            spawnFruit();           
        }
    }

    GameObject selectFruit() {
        if (specialSpawn() == 1) {
            return doubleP;
        }
        else
        {
            int rnd = Random.Range(1, 4);
            switch (rnd)
            {
                case 1:
                    return fruit;
                case 2:
                    return fruit2;
                case 3:
                    return fruit3;
            }
        }
        return null;
    }

    // Update is called once per frame
    void spawnFruit() {
        GameObject obj = Instantiate(selectFruit(), location.transform.position, Quaternion.identity);
        obj.transform.parent = kutuk.transform;
        jumpTime = Time.time + 1f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "fruit" || other.gameObject.tag == "knife")
        {
            setSpawnDelay();
        }
        else return;
    }

    void setSpawnDelay() {
        spawnDelay = 0.1f;
    }

    float spawnDelay;
    void isSpawnable() {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay < 0)
            checkStatus = true;

        else checkStatus = false;
        }

     int specialSpawn() {
        int rnd = Random.Range(1, 15);
        if (rnd == 1) 
            return 1;
            else return 0;
        }
        
    }