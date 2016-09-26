using UnityEngine;
using System.Collections;

public class BasketTriggerScript : MonoBehaviour {

	//public GameObject cube1;
	//public GameObject cube2;

	private string basket_tag; 
	private string obj_tag;

	void OnCollisionEnter(Collision other)
	{
			other.gameObject.SetActive (false);
			basket_tag = this.tag;
			obj_tag = other.gameObject.tag;
			GameObject GO = GameObject.Find ("ScriptHolder");
			HelpingHand Helper = GO.GetComponent<HelpingHand> ();

			//Add to the structure
			Helper.add_to_struct (obj_tag, basket_tag);
	}
}
