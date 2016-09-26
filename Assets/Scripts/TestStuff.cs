using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class TestStuff : MonoBehaviour {
	LeapProvider provider;
	float GrabAngle;
	float strength;
	Vector3 palmPos = new Vector3(0.0f,0.0f,0.0f);
	bool ObjectDetected;
	bool ObjectHeld = false;
	GameObject pickup;
	float curr_strength = 30;

	void Start () {
		provider = FindObjectOfType<LeapProvider> ();
	}
	
	void Update () 
	{
		Frame frame = provider.CurrentFrame;
		List<Hand> hands = frame.Hands;
		HandModel hml = FindObjectOfType<HandModel> ();
		Debug.Log (hands.Count);

		for (int h = 0; h < hands.Count; h++)
		{
			Hand hand = hands[h];
		    strength = hand.GrabStrength;	
		    palmPos = hml.GetPalmPosition ();

			//Raycast
			if (!ObjectHeld) 
			{	
				ObjectDetected = false;
				RaycastHit hit;			
				if (Physics.Raycast (palmPos, hml.GetPalmNormal (), out hit, 20)) {
					pickup = hit.transform.gameObject;
					ObjectDetected = true;
					Debug.Log ("Yes");
				}

				// ATTACH TO HAND
				if ((ObjectDetected) && (strength > curr_strength / 100)) {
					ObjectHeld = true;
					Debug.Log ("ObjectHeld");
				}
			}

			//KEEP TO Hand
			if (ObjectHeld && strength > curr_strength / 100) 
				pickup.transform.position = palmPos + hml.GetPalmNormal ()/8;	
			
			else if(strength < curr_strength / 100)
				ObjectHeld = false;			

		}
	}
}
		

