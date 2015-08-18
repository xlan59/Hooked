using UnityEngine;
using System.Collections;

public class Player_Behav : MonoBehaviour {
    
	/*private Vector3 movementVector;
	private CharacterController characterController;
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;*/
	private double AxisX;
	private double AxisY;

	//Mode- 0=no chain
	//		1=chain firing
	//		2=chain attached
	private int mode;

	GameObject ChainLink;
	GameObject SpawnedLink;
	// Use this for initialization
	void Start () 
	{
		AxisX = Input.GetAxis ("AimX");
		AxisY = Input.GetAxis ("AimY");
		print(Input.GetAxis ("AimY"));
		mode = 2;
//		Instantiate(Resources.Load("ChainLink")) as GameObject;
		ChainLink = Resources.Load ("ChainLink", typeof(GameObject)) as GameObject;

		//Instantiate (Resources.Load ("Cube"));//,Vector3(0,0,0), transform.rotation);
//		Instantiate (ChainLink);
//		Instantiate(Resources.Load<GameObject>("ChainLink"));
	}
	
	// Update is called once per frame
	void Update () 
	{
		float linkSpawnLocation = 0;

		if (Input.GetButtonDown ("Shoot"))
			mode = 1;




		if (mode == 0) {
			//Point in the direction as the Right Control Stick.
			transform.localEulerAngles = new Vector3 (0, 0, (Mathf.Atan2 (Input.GetAxis ("AimY"), Input.GetAxis ("AimX")) * (float)(-360 / 2 / Mathf.PI)));
			//print(Mathf.Atan(Input.GetAxis ("AimY") / Input.GetAxis ("AimX"))*(float)(-360/Mathf.PI));
			print (Mathf.Atan (Input.GetAxis ("AimX")));

		} /*else if (mode == 1) {

			Instantiate(ChainLink,transform.position,transform.rotation);

			SpawnedLink = GameObject.Find ("ChainLink(Clone)");
			SpawnedLink.transform.SetParent(gameObject.transform);
			//SpawnedLink.transform.position.y = transform.position.y + (double)0.75;

			linkSpawnLocation = (float)(transform.position.y + (double)0.75);
			SpawnedLink.transform.position= new Vector3(transform.position.x,linkSpawnLocation,transform.position.z);
			mode = 0;

		} */else if (mode == 2) {
			//Go Left
			if (Mathf.Atan (Input.GetAxis ("Movement")) > .3) {
				GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x + (float)0.4, GetComponent<Rigidbody> ().velocity.y - (float)0.1, GetComponent<Rigidbody> ().velocity.z);

			}

			//Go right
			if (Mathf.Atan (Input.GetAxis ("Movement")) < -.3) {	
				GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x - (float)0.4, GetComponent<Rigidbody> ().velocity.y - (float)0.1, GetComponent<Rigidbody> ().velocity.z);
			}
		}


		//AxisX = Input.GetAxis ("AimX");
		//AxisY = Input.GetAxis ("AimY");
		//print(Input.GetAxis ("AimY"));
	}
}
