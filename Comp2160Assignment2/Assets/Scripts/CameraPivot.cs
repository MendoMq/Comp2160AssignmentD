using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour {

	public Transform target;


	// Use this for initialization
	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		transform.position = target.position;
		transform.eulerAngles = new Vector3(0,target.eulerAngles.y,0);
	}
}
