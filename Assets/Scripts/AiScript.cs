using UnityEngine;
using System.Collections;

//Animator parameter : Turn : ( 0 = walk then R ; 1 = turn right; 2 = walk then L; 3 = turn left)
public class AiScript : MonoBehaviour
{
	Animator animator;
	public float walkTime = 10f;
	private float startTime = 0;
	// Use this for initialization
	void Start ()
	{
		animator = this.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		Debug.Log (startTime);
		startTime += Time.deltaTime;
		if (startTime >= walkTime) {
			startTime -= walkTime;
			int state = animator.GetInteger ("Turn");
			if (state == 0) {
				animator.SetInteger ("Turn", 1);
			} else if (state == 2) {
				animator.SetInteger ("Turn", 3);
			}
				
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsTag ("TurnR")) {
			animator.SetInteger ("Turn", 2);
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsTag ("TurnL")) {
			animator.SetInteger ("Turn", 0);
		}



	}

}
