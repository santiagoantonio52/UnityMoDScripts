using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleAIManager : MonoBehaviour {

    private WhaleMovementController whaleMovementController;

	// Use this for initialization
	void Start () {
        whaleMovementController = GetComponent<WhaleMovementController>();		
	}
	
	// Update is called once per frame
	void Update () {

        whaleMovementController.Move();
		
	}
}
