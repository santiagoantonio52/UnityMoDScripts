using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 7f;
	public float runSpeed = 12f;
	public float gravity = -9.8f;
	public float speed = 6.0f;
	private float verticalVelocity;
	public float jumpForce = 10f;
	public float gravityJump = 25f;
	public float minScale = 1, maxScale = 2;
	private CharacterController ColliderPlayer;
	private CharacterController _charCont;

	// Use this for initialization
	void Start () {
		_charCont = GetComponent<CharacterController> ();
		ColliderPlayer = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterController> ();
		ColliderPlayer.height = 2f; 

	} 
	void  Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			walkSpeed = runSpeed;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			walkSpeed = 7f;
		}
		float deltaX = Input.GetAxis ("Horizontal") * walkSpeed;
		float deltaZ = Input.GetAxis ("Vertical") * walkSpeed;
		Vector3 movement = new Vector3 (deltaX, 0, deltaZ);
		movement = Vector3.ClampMagnitude (movement, walkSpeed); 


		movement *= Time.deltaTime;		
		movement = transform.TransformDirection (movement);
		_charCont.Move (movement);

		if (_charCont.isGrounded) {
			verticalVelocity = -gravityJump * Time.deltaTime;
			if (Input.GetKeyDown (KeyCode.Space)) {
				verticalVelocity = jumpForce;
			}
		} else {
			verticalVelocity -= gravityJump * Time.deltaTime;
		}

		Vector3 jumpVector = new Vector3 (0, verticalVelocity, 0);
		_charCont.Move (jumpVector * Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.LeftControl)) { 
			ColliderPlayer.height = 1.3f;
			transform.localScale = new Vector3(minScale, 1, maxScale); 
	       }
	   if (Input.GetKeyUp(KeyCode.LeftControl)) { 
			ColliderPlayer.height = 2;
			transform.localScale = new Vector3(minScale, 2,maxScale);
	 }
   }
}