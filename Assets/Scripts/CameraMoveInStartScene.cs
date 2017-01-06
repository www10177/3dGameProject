using UnityEngine;
using System.Collections;

public class CameraMoveInStartScene : MonoBehaviour {
    public float speed = 4f;
    public float[] Bound = { 49.53f, 50.81f };
    bool ToLeft = true;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = transform.position.x;
  
        if (x >= Bound[1])
            ToLeft = true;
        else if (x <= Bound[0])
            ToLeft = false;
        if(ToLeft)
            transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
        else
            transform.Translate(new Vector3(1 * speed * Time.deltaTime, 0, 0));
    }
}
