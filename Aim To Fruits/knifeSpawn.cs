using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class knifeSpawn : MonoBehaviour {

    public GameObject knifePrefap;

    float throwDelay;
    bool canThrow;

    void Start() {
        setThrowDelay();
        canThrow = true;
    }

    void Update() {
        throwDelay -= Time.deltaTime;
        if (throwDelay < 0) {
            canThrow = true;
        }
    }

    // Use this for initialization
    public void throwKnife() {
        if (canThrow)
        {
            Instantiate(knifePrefap, transform.position, Quaternion.identity);
        }
        canThrow = false;
        if (throwDelay < 0)
        {
            setThrowDelay();
        }
    }

    void setThrowDelay()
    {
        throwDelay = 0.3f;
    }

}
