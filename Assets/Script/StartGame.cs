using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When Start button be clicked,
	//the scene changed from start scene to main scene
	public void StartButtonClick(){
		Application.LoadLevel ("MainScene");
	}
}
