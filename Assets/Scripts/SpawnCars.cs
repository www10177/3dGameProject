using UnityEngine;
using System.Collections;

public class SpawnCars : MonoBehaviour {
    /*Parameters*/
    private int[] TimeRange =  { 50,100 };

/*Global Variables*/

    int CarSpawnTime ;// Every "CarSpawnTime" frame will spawn one car
	public GameObject Cars;
     public float MaximumDistance; // Maximum Distance that car spawned can move

	// Use this for initialization
	void Start () {
        MaximumDistance = this.transform.parent.GetComponent<Renderer>().bounds.size.x;
        /*Set CarDestiny Seed*/
        CarSpawnTime = Random.Range(TimeRange[0], TimeRange[1]);

    }

    // Update is called once per frame
    void Update()
    {
		
        if (Time.frameCount % CarSpawnTime == 1)
        {
			CreateCar ();	
        }
    }
	void  CreateCar()
	{
		
		GameObject NewCar = Instantiate (Cars, transform.position  , transform.rotation) as GameObject;
		NewCar.transform.parent = transform;
	}
   }
