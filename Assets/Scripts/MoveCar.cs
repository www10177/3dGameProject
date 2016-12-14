using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {
    float Speed = 0.2f;
    float MaximumDistance ; // Max Distance the Car Can Move ( == the Length of the Road ) 
    float OriginalX; //Original point( == CarSpawner)
	// Use this for initialization
	void Start () {
        OriginalX = GameObject.Find("RoadL/CarSpawner").transform.position.x;
        MaximumDistance = GameObject.Find("RoadL").GetComponent<Renderer>().bounds.size.x+ GameObject.Find("Body").GetComponent<Renderer>().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Speed, 0, 0));
        float MoveDis = transform.position.x - OriginalX;//the distance car moved
        if (MoveDis >= MaximumDistance || MoveDis <= 0)
           Destroy(this.gameObject);

	}
}
