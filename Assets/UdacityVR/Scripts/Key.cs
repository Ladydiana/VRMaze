﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
	public GameObject poof;
	public AudioSource keySound;
	public Door door;


	void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)

		transform.Rotate (Vector3.up* 60 * Time.deltaTime, Space.World);
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy

		keySound.Play ();
		Object.Instantiate(poof, transform.position, Quaternion.Euler(-90, 0, 0));
		door.Unlock ();
		Destroy(this.gameObject);

    }

}
