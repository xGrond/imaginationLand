using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {
        rotateWood();
	}

    void rotateWood() {
        transform.Rotate(0, 0, speed * Time.deltaTime * -30);
    }
}
