using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl2 : MonoBehaviour {
	public string xAxis= "Horizontal";
	public string zAxis= "Vertical";
	public float moveSpeed=3.0f;
	public float turnSpeed=100f;
	public bool moving = false;
	// Use this for initialization

    Quaternion targetRotation;
	Rigidbody _rb;
    float forwardInput, turnInput;

    public Quaternion TargetRotation
    {
        get {return targetRotation;}
    }
	void Start () 
	{
        if (GetComponent<Rigidbody>())
        {
            _rb = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError ("No Rigibody on Character");
        }
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
		//transform.position += transform.right * moveSpeed * x * Time.deltaTime;
        transform.Rotate(transform.up * x * turnSpeed * Time.deltaTime); 

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
