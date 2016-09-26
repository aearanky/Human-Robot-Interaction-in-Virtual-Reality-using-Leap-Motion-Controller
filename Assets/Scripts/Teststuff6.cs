using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Teststuff6 : MonoBehaviour {

	LeapProvider provider;

	float l_GrabAngle;
	float l_strength;
	Vector3 l_palmPos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 l_pickup_pos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 l_pickup_release_pos = new Vector3(0.0f,0.0f,0.0f);
	bool l_ObjectDetected;
	bool l_ObjectHeld = false;
	GameObject l_pickup;
	string l_pickup_tag_name;
	float l_curr_strength = 30;

	float r_GrabAngle;
	float r_strength;
	Vector3 r_palmPos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 r_pickup_pos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 r_pickup_release_pos = new Vector3(0.0f,0.0f,0.0f);
	bool r_ObjectDetected;
	bool r_ObjectHeld = false;
	GameObject r_pickup;
	string r_pick_up_tag_name;
	float r_curr_strength = 30;

	void Start () {
		provider = FindObjectOfType<LeapProvider> ();
	}

	void Update ()
	{
		Frame frame = provider.CurrentFrame;
		List<Hand> hands = frame.Hands;
		HandModel hml = FindObjectOfType<HandModel> ();

		//if (hands.Count == 1){
				Hand hand = hands [0];
				
				//Start of Right hand
				//if (hand.IsRight) {	
					r_strength = hand.GrabStrength;	
					r_palmPos = hml.GetPalmPosition ();

					//Apply Raycast only if object not held
					if (!r_ObjectHeld) {	
						r_ObjectDetected = false;
						RaycastHit r_hit;			
						if (Physics.Raycast (r_palmPos, hml.GetPalmNormal (), out r_hit, 20)) {
							r_pickup = r_hit.transform.gameObject;
							r_ObjectDetected = true;
						}
						// ATTACH TO HAND
						if ((r_ObjectDetected) && (r_strength > r_curr_strength / 100)) {
							r_ObjectHeld = true;
							r_pickup_pos = r_hit.transform.position;
							//Debug.Log ("Right Pick Up"+r_pickup_pos);
							//Debug.Log ("Right Pick Up tag"+	r_pickup.tag);
						}
					}

					//KEEP IN Hand
					if (r_ObjectHeld && r_strength > r_curr_strength / 100)
						r_pickup.transform.position = r_palmPos + (hml.GetPalmNormal ()) / 8;
					else if (r_strength < r_curr_strength / 100) {
						if (r_ObjectHeld) {
							r_pickup_release_pos = r_palmPos;
							//Debug.Log ("Right Release" + r_pickup_release_pos);
						}

						r_ObjectHeld = false;
					}
				//}//End of right hand

		//	}//End of for loop

		//}//end of if

	}//End of update

}//End of Class









