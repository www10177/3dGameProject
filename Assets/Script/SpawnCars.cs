using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour {
    float CarRangeZ=25.71f/2; // Range of spawn cars
    float CarOffsetY = 1.28f;//Distanve between car center and the plane
    int CarDestiny = 60;// Every "CarDestiny" frame will spawn one car
    public GameObject Cars;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % CarDestiny == 1) 
            Instantiate(Cars, transform.position + new Vector3(0, CarOffsetY, Random.Range((int)(-1 * CarRangeZ), (int)CarRangeZ)), transform.rotation);
    }
}
