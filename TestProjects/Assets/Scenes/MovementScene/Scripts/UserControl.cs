using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl : MonoBehaviour {
	public string xAxis= "Horizontal";
	public string zAxis= "Vertical";
	public float moveSpeed=3.0f;
	public float rotateSpeed=100f;
	public bool moving = false;
	// Use this for initialization
	Rigidbody _rb;
	void Start () 
	{
		_rb = GetComponent<Rigidbody>();
		moving = false;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		
	}

	void Update () 
	{
		//Set Axis inputs
		float x = Input.GetAxis(xAxis);
		float z = Input.GetAxis(zAxis);

		Debug.Log("x= " + x + "| z= " + z);
		//_rb.AddForce(new Vector3(x, 0, z),ForceMode.Force);

		//change position
		transform.position += transform.forward * moveSpeed * z * Time.deltaTime;
		transform.position += transform.right * moveSpeed * x * Time.deltaTime;

		//Check if moving
		if (x == 0 && z == 0)
		{
			moving = false;
		}
		else if (x != 0 || z != 0)
		{
			moving = true;
		}
	}

	void Run ()
	{
		
	}

	void Turn ()
	{

	}

	
}
