using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;

    //それぞれのオブジェクト(Leeson6課題)
    private GameObject Coinprefab;
    private GameObject CarPrefab;
    private GameObject TrafficConePrefab;

    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        //Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);

        //コインオブジェクトを配列で取得(Leeson6課題)
        GameObject[] Coinprefab = GameObject.FindGameObjectsWithTag("CoinTag");
        for (int i = 0; i < Coinprefab.Length; i++)
        {
            if (Coinprefab[i].transform.position.z < this.transform.position.z)
            {
                Destroy(Coinprefab[i]);
            }
        }

        GameObject[] CarPrefab = GameObject.FindGameObjectsWithTag("CarTag");
        for (int i = 0; i < CarPrefab.Length; i++)
        {
            if (CarPrefab[i].transform.position.z < this.transform.position.z)
            {
                Destroy(CarPrefab[i]);
            }
        }

        GameObject[] TrafficConePrefab = GameObject.FindGameObjectsWithTag("TrafficConeTag");
        for (int i = 0; i < TrafficConePrefab.Length; i++)
        {
            if (TrafficConePrefab[i].transform.position.z < this.transform.position.z)
            {
                Destroy(TrafficConePrefab[i]);
            }
        }
    }

    
}