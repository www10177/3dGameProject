using UnityEngine;
using System.Collections;

public class MoveToolMan : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	//壓著按鍵可連續移動
	//移動速度先設0.1，以後需要再調整
	void Update () {
/*		print (this.transform.rotation.eulerAngles);
		if (Input.GetKey (KeyCode.W)) {	//按住W鍵往前(z軸正軸)移動
			this.transform.Translate (new Vector3(Mathf.Sin(this.transform.eulerAngles.y),0,Mathf.Cos(this.transform.eulerAngles.y))
				*Time.deltaTime*Speed);
		} else if (Input.GetKey (KeyCode.S)) {	//按住S鍵往後(z軸負軸)移動
			this.transform.Translate (new Vector3(-Mathf.Sin(this.transform.eulerAngles.y),0,-Mathf.Cos(this.transform.eulerAngles.y))
				*Time.deltaTime*Speed);
		} else if (Input.GetKey (KeyCode.A)) {	//按住A鍵往左(x軸負軸)移動
			this.transform.Translate (-Vector3.left*Time.deltaTime*Speed,Space.Self);
		} else if (Input.GetKey (KeyCode.D)) {	//按住D鍵往右(x軸正軸)移動
			this.transform.Translate (Vector3.right*Time.deltaTime*Speed,Space.Self);
		}*/

	}
}
