using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Player player;
	public float delay = 0.25f;
	private List<Sample> playerHistory = new List<Sample>();
	private class Sample {
		public Vector3 position;
		public float time;
	}
	
	private void StoreSample() {
		Vector3 playerXZ = player.transform.position;
		playerXZ.y = 0.0f;
		playerHistory.Add(
			new Sample(){
				position = playerXZ,
				time = Time.time
			}	
		);
		var earliestSample = Time.time - delay;
		while(playerHistory.Count != 0 && playerHistory[0].time < earliestSample){
			playerHistory.RemoveAt(0);
		}
	}
	private Vector3 GetViewTarget(){
		Vector3 sum = Vector3.zero;
		for(int i = 0; i < playerHistory.Count; ++i){
			sum += playerHistory[i].position;
		}
		return sum / (float)playerHistory.Count;
	}
	
	
	// Update is called once per frame
	void LateUpdate () {
		StoreSample();
		Vector3 viewTarget = GetViewTarget();
		Vector3 cameraPos = transform.position;
		cameraPos.x = viewTarget.x;
		cameraPos.y = viewTarget.y;
		transform.position = cameraPos;
	}
	
}
