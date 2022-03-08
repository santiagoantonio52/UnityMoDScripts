using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	public Transform[] aiPoint;

	private int aiPointHere;
	private float speed = 1.5f;
	void Update() {
		if(aiPointHere < aiPoint.Length){
			Vector3 target = aiPoint[aiPointHere].position;
			transform.LookAt(target);
			transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.deltaTime);
			if(transform.position == target){
			aiPointHere = Random.Range (0,aiPoint.Length);   
			}
		}
	}
}