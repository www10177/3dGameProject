using UnityEngine;
using System.Collections;

public class MoveCar : MonoBehaviour {
    float Speed = 0.2f;
    float MaximumXLocation = 48f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(Speed, 0, 0));
        print(transform.position.x);
        if (transform.position.x > MaximumXLocation)
            Destroy(this.gameObject);

	}
}
