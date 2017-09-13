using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour {

    public GameObject karakterComp;
    private karakterController kcs;
    public float astDonusHiz;
    public float astMoveSpeed;
    private float baslangicMesafesi;

	// Use this for initialization
	void Start () {
        kcs = karakterComp.GetComponent<karakterController>();
        baslangicMesafesi = (transform.position - karakterComp.transform.position).magnitude;
    }

	//astDonuzHzini zorlukla carp
    //astMoveSpeedi zorlukla carp
	void Update () {
        moveAstroid();
    }


    void moveAstroid()
    {
        if (kcs.isGameRunning && kcs != null)
        {
            transform.Rotate(new Vector3(astDonusHiz * Time.deltaTime, 0, 0));
            transform.Translate(new Vector3(0, 0, (-astMoveSpeed * returnKatsayi(distance())) * Time.deltaTime), Space.World);
        }
    }

    //meteor yaklastikca hizlanir uzaklastica yavaslar
    float returnKatsayi (float distance) { 
        return ((distance + (baslangicMesafesi / 2)) / baslangicMesafesi);        
    }
    
    //Karakter ve astroid arasindaki mesafe
    float distance() {
        return (transform.position - karakterComp.transform.position).magnitude;
    }

}
