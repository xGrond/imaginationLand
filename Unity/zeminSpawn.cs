using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zeminSpawn : MonoBehaviour {


    //spawmlancak tuzak
    public GameObject zemin1;
    public GameObject zemin2;
    public GameObject zemin3;
    public GameObject zemin4;

    public GameObject mesafeOlc;
    public GameObject cam;
    private float mesafe = 0;
    private float pozisyonZ = 0;

    //kac tane bos zemin olcak
    private float bosZemin;

    //tuzaklar nerde buluncak
    //1 = sol, 2 = orta, 3 = sag
    private float tuzakKonum;
    private float tuzakKonum2;

    [SerializeField]
    private GameObject tuzakPrefap;

    //spawn pointlerin x cinsinden konumu
    //x1 en sol x3 en sag
    private const float x1 = -1.43f;
    private const float x2 = 0;
    private const float x3 = 1.43f;

    //spawn pointlerin y cinsinden degeri (yukseklik)
    private float y = 0.5f;

    public void ucluSpawn() {
        var spawnPoint = (GameObject)Instantiate(
        spawmlancakPrefab(),
        transform.position = new Vector3(0, 0, pozisyonZ),
        transform.rotation
        );
        pozisyonZ -= 5f;
        int zorluk = karakterController.tuzakSpawnZorlugu;
        switch (zorluk) {
            case 1:
                tzkKonumBelirle(2, 4);
                break;
            case 2:
                tzkKonumBelirle(1, 3);
                break;
            case 3:
                tzkKonumBelirle(1, 2);
                break;
        }


        if (bosZemin == 3) {
            //tuzak spawnlama
        }

        else if (bosZemin == 2)
        {
            if (tuzakKonum == 1)
            {
                tekTuzakSpawn(x1);
            }
            else if (tuzakKonum == 2)
            {
                tekTuzakSpawn(x2);
            }
            else if (tuzakKonum == 3)
            {
                tekTuzakSpawn(x3);
            }
        }
        else if (bosZemin == 1)
        {
            if (tuzakKonum == 1)
            {
                tekTuzakSpawn(x1);
                if (tuzakKonum2 == 2)
                {
                    tekTuzakSpawn(x2);
                }
                else if (tuzakKonum2 == 3)
                {
                    tekTuzakSpawn(x3);
                }
            }
            else if (tuzakKonum == 2)
            {
                tekTuzakSpawn(x2);
                if (tuzakKonum2 == 1)
                {
                    tekTuzakSpawn(x1);
                }
                else if (tuzakKonum2 == 3)
                {
                    tekTuzakSpawn(x3);
                }
            }
            else if (tuzakKonum == 3)
            {
                tekTuzakSpawn(x3);
                if (tuzakKonum2 == 1)
                {
                    tekTuzakSpawn(x1);
                }
                else if (tuzakKonum2 == 2)
                {
                    tekTuzakSpawn(x2);
                }
            }
        }
    }

    GameObject spawmlancakPrefab() {
        int rndNumber = Random.Range(1, 5);

        switch (rndNumber)
        {
            case 1:
                return zemin1;
            case 2:
                return zemin2;
            case 3:
                return zemin3;
            case 4:
                return zemin4;
        }
        return null;
    }

    public void tzkKonumBelirle(int minBosZemin,int maxBosZemin) {
        //Kac tane tuzak olmuyacak
        bosZemin = Random.Range(minBosZemin, maxBosZemin);

        tuzakKonum = Random.Range(1, 4);
        //eger zeminlerden biri bossa 2 tane ayni olmayan konum bul 1 2 veya 3
        if (bosZemin == 1)
        {
            tuzakKonum2 = Random.Range(1, 4);
            while (tuzakKonum == tuzakKonum2)
            {
                tuzakKonum2 = Random.Range(1, 4);
            }
        }
        //zeminlerin ikisi bossa ikinci tuzak yok
        else tuzakKonum2 = 0;
    }

    public void tekTuzakSpawn(float pozX) {
        Instantiate(tuzakPrefap, new Vector3(pozX, y, pozisyonZ), Quaternion.identity);
    }

    void Update()
    {
        //Eger kamera ve cisim arasindaki mesefe bir birimden fazla ise yemin spawnla ve cismi tasi
        mesafe = mesafeOlc.transform.position.z- cam.transform.position.z;
        if (mesafe >= 2f)
        {
            ucluSpawn();
            mesafe = 0;
            mesafeOlc.transform.position = cam.transform.position;
        }
    }
}
