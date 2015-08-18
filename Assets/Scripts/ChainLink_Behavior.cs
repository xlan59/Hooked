using UnityEngine;
using System.Collections;

public class ChainLink_Behavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetButton("Shoot"))
		   Destroy(gameObject);
	}
}
