using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {
    private float Speed = 40f;
    float MaximumDistance ; // Max Distance the Car Can Move ( == the Length of the Road ) 
    Vector3 Original; //Original point( == CarSpawner)
	private GameObject CarSpawner ;
	// Use this for initialization
	void Start () {
		CarSpawner = transform.parent.gameObject;
		Original = CarSpawner.transform.position;
		MaximumDistance = CarSpawner.GetComponent<SpawnCars>().MaximumDistance;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Speed*Time.deltaTime, 0, 0));
		float MoveDis = Vector3.Distance(Original, transform.position);//the distance car moved
     //   Debug.Log("Position: " + transform.position.x);
      //  Debug.Log("Distance : " + MoveDis + " Max : " + MaximumDistance);
		if (MoveDis >= MaximumDistance  )
			Destroy(this.gameObject);

	}
}
