using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {

	public Light flashLight;


	// Use this for initialization
	void Start (){
	flashLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L))
			flashLight.enabled = !flashLight.enabled;


	}
}
