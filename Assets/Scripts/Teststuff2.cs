﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class Teststuff2 : MonoBehaviour {
	LeapProvider provider;

	float l_GrabAngle;
	float l_strength;
	Vector3 l_palmPos = new Vector3(0.0f,0.0f,0.0f);
	bool l_ObjectDetected;
	bool l_ObjectHeld = false;
	GameObject l_pickup;
	float l_curr_strength = 30;

	float r_GrabAngle;
	float r_strength;
	Vector3 r_palmPos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 r_pickup_pos = new Vector3(0.0f,0.0f,0.0f);
	Vector3 r_pickup_release_pos = new Vector3(0.0f,0.0f,0.0f);
	bool r_ObjectDetected;
	bool r_ObjectHeld = false;
	GameObject r_pickup;
	float r_curr_strength = 30;

	void Start () {
		provider = FindObjectOfType<LeapProvider> ();
	}

	void Update ()
	{
		Frame frame = provider.CurrentFrame;
		List<Hand> hands = frame.Hands;
		HandModel hml = FindObjectOfType<HandModel> ();

		if (hands.Count == 1){
		for (int h = 0; h < hands.Count; h++) {
			Hand hand = hands [h];
			//---------------------------------------------------------------------------------------------
			if (hand.IsLeft) {	
				l_strength = hand.GrabStrength;	
				l_palmPos = hml.GetPalmPosition ();

				//Raycast
				if (!l_ObjectHeld) {	
					l_ObjectDetected = false;
					RaycastHit l_hit;			
					if (Physics.Raycast (l_palmPos, hml.GetPalmNormal (), out l_hit, 20)) {
						l_pickup = l_hit.transform.gameObject;
						l_ObjectDetected = true;
					}

					// ATTACH TO HAND
					if ((l_ObjectDetected) && (l_strength > l_curr_strength / 100)) {
						l_ObjectHeld = true;
					}
				}

				//KEEP TO Hand
				if (l_ObjectHeld && l_strength > l_curr_strength / 100)
					l_pickup.transform.position = l_palmPos+ (hml.GetPalmNormal ()) / 8;
				else if (l_strength < l_curr_strength / 100)
					l_ObjectHeld = false;			
			}
			//--------------------------------------------------------------------------------------
			else if (hand.IsRight) {	
				r_strength = hand.GrabStrength;	
				r_palmPos = hml.GetPalmPosition ();
				//Raycast
				if (!r_ObjectHeld) {	
					r_ObjectDetected = false;
					RaycastHit r_hit;			
					if (Physics.Raycast (r_palmPos, hml.GetPalmNormal (), out r_hit, 20)) {
						r_pickup = r_hit.transform.gameObject;
						r_ObjectDetected = true;
						r_pickup_pos = r_hit.transform.position;
						Debug.Log (r_pickup_pos);
					}
					// ATTACH TO HAND
					if ((r_ObjectDetected) && (r_strength > r_curr_strength / 100)) {
						r_ObjectHeld = true;
					}
				}
				//KEEP TO Hand
				if (r_ObjectHeld && r_strength > r_curr_strength / 100)
					r_pickup.transform.position = r_palmPos+ (hml.GetPalmNormal ()) / 8;
				else if (r_strength < r_curr_strength / 100)
					r_ObjectHeld = false;
				r_pickup_release_pos = r_palmPos;
				Debug.Log (r_pickup_release_pos);
			}
			//----------------------------------------------------------------------------------------
		}

	}//end of if

 }
}


