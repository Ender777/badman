using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 10.0f;
	public float range = 3.0f;

	private float traveled = 0.0f;
	
	// Update is called once per frame
	void Update () {
		var h = Input.GetAxis("Horizontal");
		traveled += Time.deltaTime * speed * h;
		
		transform.position = 
			(Vector3.up * Mathf.Sin(Time.time * speed) * range) + // vertical
			(Vector3.right * traveled);

	}
}
