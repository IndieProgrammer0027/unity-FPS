using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
	private float vertical;
	private float horizontal;
	private bool isRunning;
	private float mouseX;
	private float mouseY;
	private bool jump;
	
	
	public float walkSpeed;
	public float runSpeed;
	private float movementSpeed;
	public float rotationSpeed;
	
	public float gravityForce;
	public float jumpHeight;
	private float jumpGravity;
	
	public CharacterController cc;
	public GameObject cameraObject;
	
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		isRunning = Input.GetButton("Fire3");
		mouseX += Input.GetAxis("Mouse X");
		mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
		
		mouseY = Mathf.Clamp(mouseY, -50f, 50f);
		
		jump = Input.GetButton("Jump");
		
		Move();
		Rotate();
		JumpAndApplyGravity();
    }
	
	void Move()
	{
		if(isRunning)
		{
			movementSpeed = runSpeed;
		}
		else
		{
			movementSpeed = walkSpeed;
		}
		
		Vector3 forwardBackward = transform.forward * vertical;
		Vector3 rightLeft = transform.right * horizontal;
		Vector3 upDown = transform.up * jumpGravity;
		
		Vector3 move = (forwardBackward + rightLeft) * movementSpeed + upDown;
		
		cc.Move(move * Time.deltaTime);
	}
	
	void Rotate()
	{
		transform.eulerAngles = Vector3.up * rotationSpeed * mouseX;
		
		cameraObject.transform.localEulerAngles = Vector3.right * mouseY;
	}
	
	void JumpAndApplyGravity()
	{
		if(cc.isGrounded)
		{
			if(jump)
			{
				float initialVelocity = Mathf.Sqrt(-2 * gravityForce * jumpHeight);
				jumpGravity = initialVelocity;
			}
			else
			{
				jumpGravity = 0;
			}
		}
		else
		{
			jumpGravity += gravityForce * Time.deltaTime;
		}
	}
}
