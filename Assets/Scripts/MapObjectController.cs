using UnityEngine;
using System.Collections;

public class MapObjectController : MonoBehaviour {
	public int CoinCount=30;
	public GameObject CoinPrefab;
	public GameObject PhoneObject;
	// Use this for initialization
	void Start () {
		float x, y, z;
		Vector3 Size = transform.GetComponent<Renderer>().bounds.size;
		//Coin Initialization
		for(int i=0;i<CoinCount;i++)
		{
			x = Random.Range (-0.5f*Size.x,0.5f*Size.x);
			y = 0.3f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			GameObject Coin = Instantiate (CoinPrefab);
			Coin.transform.position=new Vector3(x,y,z);
		}
		//Phone Initialization 出現在地圖某處
		if (PhoneController.PhoneObtained == false) {
			x = Random.Range (-0.5f * Size.x, 0.5f * Size.x);
			y = 0.6f;
			z = Random.Range (-0.5f * Size.z, 0.5f * Size.z);
			GameObject Phone = Instantiate (PhoneObject);
			Phone.transform.position = new Vector3 (x, y, z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
