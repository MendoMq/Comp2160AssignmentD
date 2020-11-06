using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	Rigidbody rb;
	public float thrust;
	public float turn;
	public bool isGrounded;
	public bool isRayGrounded;

	RaycastHit hit;
	public LayerMask rayLayermask;

	Health health;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		health = GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!health.PlayerDied)
		{
			if(Input.GetAxis("Vertical")!=0)
			{
				if(isGrounded)
				{
					rb.velocity = (transform.forward *Input.GetAxis("Vertical") *thrust);
				}
			}

			if(Input.GetAxis("Horizontal")!=0)
			{
				if(isGrounded 
					&& Input.GetAxis("Vertical")!=0)
				{
					transform.Rotate(new Vector3(0,Input.GetAxis("Horizontal") * Input.GetAxis("Vertical") * turn,0));
				}
			}
		}

		Debug.DrawRay(transform.position,-transform.up,Color.red);

		if (Physics.Raycast(transform.position,-transform.up,0.5f,rayLayermask))
		{
				isRayGrounded=true;

		}
		else
		{
			isRayGrounded=false;
		}
	}

	void OnCollisionStay(Collision collision)
	{
		if (collision.gameObject.layer == 8 && isRayGrounded){
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.layer == 8){
			isGrounded = false;
		}
	}
}
