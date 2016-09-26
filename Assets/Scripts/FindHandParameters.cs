using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Leap.Unity;
using Leap;
using System.Collections.Generic;

public class FindHandParameters : MonoBehaviour {

	/*
	public Text text1;
	private Vector3 PalmPos;
	*/
	 Controller controller;

	public GameObject cube;
	public GameObject sphere;

	// Use this for initialization
	void Start () {
//		controller = new Controller ();
//		controller.EnableGesture (Gesture, GestureType.TYPESWIPE);
//		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 200.0f);
//		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 750f);
//		controller.Config.Save ();

		/*if (frame.Hands.Count > 0) {
			List<Hand> hands = frame.Hands;
			Hand firstHand = hands [0];
			Debug.Log ("Found");
		}*/
	}

	// Update is called once per frame
	void Update () {
		//	Frame frame = controller.Frame ();
		//text1.text = "abcdefghijklm";
		//PalmPos = HandModel.GetPalmPosition ();
	}
}
