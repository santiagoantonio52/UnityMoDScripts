using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {

	public AudioSource sounds;
	public AudioClip cutSound;
	private float distance;
    private Transform player;
	public bool couldCut;
	public Texture icon;
	public GameObject item;

	void Start()
	{
	  player = FindObjectOfType<CharacterController>().transform;
	  sounds = GetComponent<AudioSource>();
	}
	void addItem()
	{
		GetComponent<AudioSource> ().PlayOneShot (cutSound);
		GameObject obj = Instantiate(item,transform.position,transform.rotation) as GameObject;
		Player._inventoryPlayer.AddItem(obj);
    }

	void Update () 
	{
		distance = Vector3.Distance(transform.position,player.transform.position);
		if(distance <= 3)
		if (Input.GetMouseButtonDown(0))
                addItem ();
	   }
	}