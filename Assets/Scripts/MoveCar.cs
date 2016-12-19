using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {
    public float Speed = 0.2f;
    float MaximumDistance ; // Max Distance the Car Can Move ( == the Length of the Road ) 
    float OriginalX; //Original point( == CarSpawner)
	private GameObject CarSpawner ;
	// Use this for initialization
	void Start () {
		CarSpawner = transform.parent.gameObject;
		OriginalX = CarSpawner.transform.position.x;
		MaximumDistance = CarSpawner.GetComponent<SpawnCars>().MaximumDistance;

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Speed, 0, 0));
		float MoveDis = Mathf.Abs(transform.position.x - OriginalX);//the distance car moved
		if (MoveDis >= MaximumDistance  )
			Destroy(this.gameObject);

	}
}
