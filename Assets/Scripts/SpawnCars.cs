using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour {
    /*Parameters*/
    int[] TimeRange = new int[]{ 150, 230 };

/*Global Variables*/
float CarOffsetY;//Distanve between car center and the plane
    int CarSpawnTime ;// Every "CarSpawnTime" frame will spawn one car
	Vector3 CarSize;
    public GameObject Cars;

	// Use this for initialization
	void Start () {
		CarSize =Cars.transform.Find("Body").GetComponent<Renderer>().bounds.size;
       // print ("Car Size: " + CarSize);
        CarOffsetY = -1 * CarSize.y / 2 + 2.5f;/*Should Fixed: Manual Fix Offset*/
        /*Set CarDestiny Seed*/
        CarSpawnTime = Random.Range(TimeRange[0], TimeRange[1]);
    }

    // Update is called once per frame
    void Update() {
        if (Time.frameCount % CarSpawnTime == 1) {
        //Instantiate(Cars, transform.position + new Vector3(0, CarOffsetY, Random.Range((int)(-1 * RoadSize.z / 2), (int)RoadSize.z / 2)), transform.rotation);// Random Version
            Instantiate(Cars, transform.position + new Vector3(0, CarOffsetY,  0), transform.rotation);
            //print("position" +transform.position);
        }
    }
}
