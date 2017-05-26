using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidController : MonoBehaviour {

    public GameObject karakterComp;
    private karakterController kcs;
    public float astDonusHiz;
    public float astMoveSpeed;
    public float distance;
    private float baslangicMesafesi;
    private float katsayi;
	// Use this for initialization
	void Start () {
        kcs = karakterComp.GetComponent<karakterController>();
        baslangicMesafesi = (transform.position - karakterComp.transform.position).magnitude;
    }
	


	//astDonuzHzini zorlukla carp
    //astMoveSpeedi zorlukla carp
	void Update () {

        distance = (transform.position - karakterComp.transform.position).magnitude;
        katsayi = ((distance + (baslangicMesafesi / 2))  / baslangicMesafesi);

        if (kcs.isGameRunning)
        {
            transform.Rotate(new Vector3(astDonusHiz * Time.deltaTime, 0, 0));
            transform.Translate(new Vector3(0, 0, (-astMoveSpeed * katsayi ) * Time.deltaTime), Space.World);
        }



        //transform.Translate(new Vector3(0, 0, -astMoveSpeed * Time.deltaTime), Space.World);

    }
}
