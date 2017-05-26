using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splashScreenController : MonoBehaviour {


    Animator anim;
    // Use this for initialization
    IEnumerator Start() {
        anim = GetComponent<Animator>();
        anim.Play("LogoAnim");
        yield return new WaitForSeconds(4.250f);
        SceneManager.LoadScene("MainMenu");

    }


	
}
