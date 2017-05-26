using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour {

    public GameObject Karakter;
    private karakterController karakterController;

    private void Start()
    {
       karakterController = Karakter.GetComponent<karakterController>();
    }

    //Karekter girerse oyunu bitir
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "oyuncu") {
            karakterController.gameOver();
        }
    }


    //Çöpleri yok et
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "oyuncu")
        {
            Destroy(other.gameObject);
        }

    }
}
