using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour {


    public deathController death;

    private void Start()
    {
        death = death.GetComponent<deathController>();
    }

    //Karekter girerse oyunu bitir
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "oyuncu")
        {
            death.gameOver();
        }
        else return;
    }


    //Çöpleri yok et
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "oyuncu")
        {
            Destroy(other.gameObject);
        }
        else return;
    }
}
