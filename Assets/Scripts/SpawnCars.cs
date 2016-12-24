using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour {
    /*Parameters*/
    private int[] TimeRange =  { 100,150 };
    public int CarCount = 3;

/*Global Variables*/

    int CarSpawnTime ;// Every "CarSpawnTime" frame will spawn one car
	public GameObject[] Cars;
    public float MaximumDistance; // Maximum Distance that car spawned can move

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
       
    }

    // Update is called once per frame
    void Update()
    {
		
        if (Time.frameCount % CarSpawnTime == 1)
        {
            CreateCar();
        }
    }
	void  CreateCar()
	{
		
		GameObject NewCar = Instantiate (Cars[Random.Range(0,CarCount)], transform.position  , transform.rotation) as GameObject;
		NewCar.transform.parent = transform;
	}
   }
