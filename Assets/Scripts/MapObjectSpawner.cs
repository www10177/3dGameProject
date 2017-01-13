using UnityEngine;
using System.Collections;

public class MapObjectSpawner : MonoBehaviour {
	public static int CoinCount=0;
	public int CoinSize=30;
	public int MaximumCoinCount=100;
	public GameObject CoinPrefab;
	//public GameObject PhoneObject;
	// Use this for initialization
	float x,y,z;
	Vector3 Size;
	void Start () {
		Size = transform.GetComponent<Renderer>().bounds.size;
		//Coin Initialization
		for(int i=0;i<CoinSize;i++)
		{
			x = Random.Range (-0.5f*Size.x,0.5f*Size.x);
			y = 1f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			GameObject Coin = Instantiate (CoinPrefab);
			CoinCount += 1;
			Coin.transform.position=new Vector3(x+transform.position.x,y,z+transform.position.z);
			Coin.transform.parent = GameObject.Find ("MapObject").transform;
			Coin.GetComponent<Collider> ().isTrigger = true;
		}
		//Phone Initialization 出現在地圖某處
		/*if (PhoneController.PhoneObtained == false) {
			x = Random.Range (-0.5f * Size.x, 0.5f * Size.x);
			y = 0.6f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			GameObject Phone = Instantiate (PhoneObject);
			Phone.transform.position = new Vector3 (x, y, z);
		}*/
		InvokeRepeating ("SpawnCoins", 60f, 60f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SpawnCoins(){
		int Case=Mathf.Min(30,MaximumCoinCount-CoinCount);
		print ("Spawn " + Case + " Coins!");
		for(int i=0;i<Case;i++)
		{
			x = Random.Range (-0.5f*Size.x,0.5f*Size.x);
			y = 1f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			GameObject Coin = Instantiate (CoinPrefab);
			CoinCount += 1;
			Coin.transform.position=new Vector3(x+transform.position.x,y,z+transform.position.z);
			Coin.transform.parent = GameObject.Find ("MapObject").transform;
			Coin.GetComponent<Collider> ().isTrigger = true;
		}
	}
}
