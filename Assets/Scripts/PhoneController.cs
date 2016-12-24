using UnityEngine;
using System.Collections;

public class PhoneController : MonoBehaviour {
	public Canvas CanvasObject;
	public static bool PhoneObtained=false;
	void Start () {
		CanvasObject.GetComponent<Canvas> ().enabled = false;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.C)&& PhoneObtained == true) {
			if (CanvasObject.GetComponent<Canvas> ().enabled == true) {
				CanvasObject.GetComponent<Canvas> ().enabled = false;
			} else {
				CanvasObject.GetComponent<Canvas> ().enabled = true;
			}
		}
	}
	void OnTriggerEnter(Collider collision){
		if (collision.gameObject.tag == "Cellphone") {
			PhoneObtained = true;
			Destroy (collision.gameObject);
			CanvasObject.GetComponent<Canvas> ().enabled = true;
		}
	}
}
