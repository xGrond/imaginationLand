using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyBoxMove : MonoBehaviour {

    public float skyboxDonmeKatsayisi;

	// Update is called once per frame
	void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * skyboxDonmeKatsayisi);
	}
}
