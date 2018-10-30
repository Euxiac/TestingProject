using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControl3 : MonoBehaviour 
{
	public string xInput= "Horizontal";
	public string zInput= "Vertical";

	public float xSpeed = 60f;
	public float zSpeed = 10f;
   
   public float turnSpeed = 5f;
   public bool moving = false;
 
   private CharacterController _cc;
   private Transform myTransform;
 
   void Start() {
	if (GetComponent<CharacterController>())
        {
            _cc = GetComponent<CharacterController>();
        }
        else
        {
            Debug.LogError ("No CharacterController on Character");
        }
		myTransform = transform;
		moving = false;
	}
 
	void LateUpdate()
	{

	}
   void Update ()
   {
     //Make floats to store the value of the x and z * speed for rate
     float x = Input.GetAxis(xInput) * xSpeed;
     float z = Input.GetAxis(zInput) * zSpeed;
	 //Make new V3 to store value
     Vector3 moveValue = new Vector3(x, 0, z);
 
     // If the new movement value isnt 000
     if(moveValue != (new Vector3(0, 0, 0))) {
       //Rotate the player to the direction is facing. looks at the movement value
       Quaternion newRotation = Quaternion.LookRotation(moveValue);
       myTransform.rotation = Quaternion.Slerp(myTransform.rotation, newRotation, turnSpeed * Time.deltaTime);
 
       // CharacterController.Move to move the player in target direction
       _cc.Move(moveValue * Time.deltaTime);
     }

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
 
}
 
