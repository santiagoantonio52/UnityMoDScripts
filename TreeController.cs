using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

	private float treeHealthMax = 100;
	private float treeHealthCurrent;
	public GameObject woodModel;
	public GameObject spawnWood;
	public GameObject tree;
	private float counter;
	private float counterS;
	public AudioSource sounds;
	public AudioClip cutSound;
	private float distance;
    private Transform player;
	public bool couldCut;

	// Use this for initialization
	void Start () 
	{ 
      treeHealthCurrent = treeHealthMax;
	  player = FindObjectOfType<CharacterController>().transform;
	  sounds = GetComponent<AudioSource>();
	}
	
	public void Drop()
	{
		Destroy(tree);
Instantiate(woodModel,spawnWood.transform.position,transform.rotation);

	}
		void Attack()
	{
	    GetComponent<AudioSource> ().PlayOneShot (cutSound);
        treeHealthCurrent -= 50;
	}

	// Update is called once per frame
	void Update () 
	{
		if (couldCut== false) {
       }
       else {
		   	if (treeHealthCurrent >= treeHealthMax) {
			treeHealthCurrent = treeHealthMax;
		} else if (treeHealthCurrent <= 0) {
		counterS += Time.deltaTime;
        if(counterS >= 1.2f)
		Drop ();
		}
		distance = Vector3.Distance(transform.position,player.transform.position);
		if(distance <= 3)
		if (Input.GetMouseButtonDown(0))
		Attack ();
       }
	}
}
