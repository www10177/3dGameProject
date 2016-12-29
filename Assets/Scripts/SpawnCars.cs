using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour {
    /*Parameters*/
	private int[] TimeRange =  { 1666,2500 }; // Spawn new car between TIMERANGE(ms)
    public int CarCount = 3;
	private

/*Global Variables*/

    int CarSpawnTime ;// Every "CarSpawnTime" frame will spawn one car
	public GameObject[] Cars;
    public float MaximumDistance; // Maximum Distance that car spawned can move
	private float Timer;

	// Use this for initialization
	void Start () {
        Vector3 Size = transform.parent.GetComponent<Renderer>().bounds.size;
        MaximumDistance = Mathf.Max(Size.x, Size.z);

        /*Set CarDestiny Seed*/
        CarSpawnTime = Random.Range(TimeRange[0], TimeRange[1]);
        Cars = new GameObject[CarCount];
        for (int i = 0; i < CarCount; i++)
        {
            Cars[i] = Resources.Load("Cars/Car" + (i + 1)) as GameObject;   
        }
		Timer = Time.time + CarSpawnTime / 1000;
       
    }

    // Update is called once per frame
    void Update()
    {
		
        if (Time.time > Timer)
        {
            CreateCar();
			Timer = Time.time + CarSpawnTime / 1000;
        }
    }
	void  CreateCar()
	{
		
		GameObject NewCar = Instantiate (Cars[Random.Range(0,CarCount)], transform.position  , transform.rotation) as GameObject;
		NewCar.transform.parent = transform;
	}
   }
