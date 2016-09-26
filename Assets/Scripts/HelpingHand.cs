using UnityEngine;
using System.Collections;

public class HelpingHand : MonoBehaviour {

	private int index = 0;
	//bool Train=0;

	public struct moves_struct
	{
		public string cube_tag;
		public string basket_tag;
	}

	public moves_struct[] moves_list;
		
	void Start()
	{
		moves_list = new moves_struct[3];
		for (int i = 0; i < 3; i++) {
			moves_list[i].cube_tag="" ;
			moves_list[i].basket_tag="" ;
		}
		for (int i = 0; i < 3; i++) {
			Debug.Log ("CubeTag =" + moves_list[i].cube_tag + "BasketTag =" + moves_list[i].basket_tag);
		}

	}

	void Update()
	{
		//Check for Train / Execute

	}

	public void add_to_struct(string str1, string str2)
	{	
		//Debug.Log ("ADD TO STRUCT CALLED");
		moves_list[index].cube_tag = str1;
		moves_list[index].basket_tag = str2;

		Debug.Log ("Stored " + moves_list[index].cube_tag + " in " + moves_list[index].basket_tag);
		index++;

		//Pass to robot condition
		if (index == 2) {			
			for (int i = 0; i < 2; i++) {
				Debug.Log ("Showing that " + moves_list[i].cube_tag + " is stored in " +moves_list[i].basket_tag);
			}
			//CAll THE ROBOT's function

		}
	}
}
