using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
	private float mouseX;
	private float mouseY;
	
	public float swayAmount;
	private Vector3 swayPosition;
	
	private Vector3 startingPosition;
	
	private Vector3 smoothnessVelocity;
	
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = -Input.GetAxis("Mouse X") * swayAmount * Time.deltaTime;
		mouseY = -Input.GetAxis("Mouse Y") * swayAmount * Time.deltaTime;
		swayPosition = new Vector3(mouseX,mouseY,0);
		transform.localPosition = Vector3.SmoothDamp(transform.localPosition, swayPosition + startingPosition, ref smoothnessVelocity, 5 * Time.deltaTime);
    }
}
