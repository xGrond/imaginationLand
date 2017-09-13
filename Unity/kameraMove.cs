using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraMove : MonoBehaviour {

    public float sabitHiz;
    public float speed;
    private Vector3 targetPos;
    public GameObject followTarget;

	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        if (followTarget != null) {
            followCharacter();
        }
	}

    void followCharacter() {
        targetPos = new Vector3(transform.position.x, transform.position.y, followTarget.transform.position.z - 18.2f);
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
