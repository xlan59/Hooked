using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public static float prevX;// = GameObject.Find("Player").transform.position.x;
	public static float prevZ;// = transform.position.z;
	public float currX;// = GameObject.Find("Player").transform.position.x;
	public float currZ;// = GameObject.Find("Player").transform.position.z;
	public float diffX;
	public float diffZ;
	public static int indexX;

	public Transform[] stuff;
	public Transform Floorpiece;

	// Use this for initialization
	void Start () {
	
		indexX = 0;
		prevX = GameObject.Find("Player").transform.position.x;
		prevZ = GameObject.Find("Player").transform.position.z;
		currX = GameObject.Find("Player").transform.position.x;
		currZ = GameObject.Find("Player").transform.position.z;
		//var rocketClone : Rigidbody = Instantiate(floorpiece, transform.position, transform.rotation);
		//Rigidbody rocketClone = (Rigidbody) Instantiate(floorpiece, transform.position, transform.rotation);

		/*Instantiate(Floorpiece, new Vector3(1, 3, 0), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(2, 3, 0), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(3, 3, 0), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(4, 3, 0), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(5, 3, 0), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(2, 3, 1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(2, 3, -1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(4, 3, 1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(4, 3, -1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(3, 3, 1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(3, 3, -1), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(3, 3, 2), Quaternion.identity);
		Instantiate(Floorpiece, new Vector3(3, 3, -2), Quaternion.identity);
*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W)){
		    //print("space key was pressed");
			GetComponent<Rigidbody>().velocity = new Vector3(5, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
		}
		if (Input.GetKey(KeyCode.S)){
			//print("space key was pressed");
			GetComponent<Rigidbody>().velocity = new Vector3(-5, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
		}
		if (Input.GetKey(KeyCode.A)){
			//print("space key was pressed");
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, 5);
		}if (Input.GetKey(KeyCode.D)){
			//print("space key was pressed");
			GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y  , -5);
			//print("hi");
		}

		currX = transform.position.x;
		currZ = transform.position.z;
		//print(currX);

		//Check x and z for one full movement
		if (currX - prevX >= 1)
		{
			prevX = Mathf.Round(currX);
			createEdgeX(1, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		}
		else if (currX - prevX <= -1) 
		{
			prevX = Mathf.Round(currX);
			createEdgeX(-1, Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
		}
		if (currZ - prevZ >= 1)
		{
			prevZ = Mathf.Round(currZ);
			createEdgeZ(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 1);
		}
		else if (currZ - prevZ <= -1) 
		{
			prevZ = Mathf.Round(currZ);
			createEdgeZ(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), -1);
		}

		
	}

	void createEdgeX(int x, float y, float z)
	{
		Instantiate(stuff[indexX], new Vector3(Mathf.Round(transform.position.x) + 1*x, y - 1.41f, z +2), Quaternion.identity);
		Instantiate(stuff[indexX+1], new Vector3(Mathf.Round(transform.position.x) + 1*x, y - 1.41f, z -2), Quaternion.identity);
		Instantiate(stuff[indexX+2], new Vector3(Mathf.Round(transform.position.x) + 2*x, y - 1.41f, z +1), Quaternion.identity);
		Instantiate(stuff[indexX+3], new Vector3(Mathf.Round(transform.position.x )+ 2*x, y - 1.41f, z-1), Quaternion.identity);
		Instantiate(stuff[indexX+4], new Vector3(Mathf.Round(transform.position.x) +3*x, y - 1.41f, z), Quaternion.identity);
		Instantiate(stuff[indexX+5], new Vector3(Mathf.Round(transform.position.x), y - 1.41f, z), Quaternion.identity);
		Instantiate(stuff[indexX+6], new Vector3(Mathf.Round(transform.position.x) +2*x, y - 1.41f, z), Quaternion.identity);
		Instantiate(stuff[indexX+7], new Vector3(Mathf.Round(transform.position.x) +1*x, y - 1.41f, z+1), Quaternion.identity);
		Instantiate(stuff[indexX+8], new Vector3(Mathf.Round(transform.position.x) +1*x, y - 1.41f, z-1), Quaternion.identity);

		indexX = indexX + 9;
		
		int indexY = indexX;
		
		if (indexY >= 12)
		{
			indexX = 0;
		}
	}

	void createEdgeZ(float x, float y, int z)
	{
		Instantiate(stuff[indexX], new Vector3(x + 2, y - 1.41f, Mathf.Round(transform.position.z + 1 * z)), Quaternion.identity);
		Instantiate(stuff[indexX+1], new Vector3(x - 2, y - 1.41f, Mathf.Round(transform.position.z + 1 * z)), Quaternion.identity);
		Instantiate(stuff[indexX+2], new Vector3(x + 1, y - 1.41f, Mathf.Round(transform.position.z + 2 * z)), Quaternion.identity);
		Instantiate(stuff[indexX+3], new Vector3(x - 1, y - 1.41f, Mathf.Round(transform.position.z + 2 * z)), Quaternion.identity);
		Instantiate(stuff[indexX+4], new Vector3(x , y - 1.41f, Mathf.Round(transform.position.z + 3 * z)), Quaternion.identity);
		Instantiate(stuff[indexX+5], new Vector3(x , y - 1.41f, Mathf.Round(transform.position.z )), Quaternion.identity);
		Instantiate(stuff[indexX+6], new Vector3(x , y - 1.41f, Mathf.Round(transform.position.z +2*z )), Quaternion.identity);
		Instantiate(stuff[indexX+7], new Vector3(x+1 , y - 1.41f, Mathf.Round(transform.position.z + 1*z)), Quaternion.identity);
		Instantiate(stuff[indexX+8], new Vector3(x-1 , y - 1.41f, Mathf.Round(transform.position.z + 1*z)), Quaternion.identity);

		indexX = indexX + 9;

		int indexY = indexX;

		if (indexY >= 12)
			indexX = 0;

	}

}
