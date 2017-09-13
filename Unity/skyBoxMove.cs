using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxMove : MonoBehaviour {

    [SerializeField]
    GameObject skyboxCamera;

    public float hiz;

	// Update is called once per frame
	void Update () {
        skyboxCamera.transform.Rotate(-1.5f * Time.deltaTime,-3.5f * Time.deltaTime, 0f);
	}
}
