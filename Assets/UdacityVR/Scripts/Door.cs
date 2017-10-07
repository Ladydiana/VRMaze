using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 

	bool locked = true;
	bool opening = false;
	bool onlyOneClickAllowed = false;
	public AudioSource doorLocked;
	public AudioSource doorUnlocked;
	public GameObject doorLeft;
	public GameObject doorRight;
	private float speed = 10.0f;
	private float leftRotationZ;
	private float rightRotationZ;
	private int frame = 0;


    void Update() {
        // If the door is opening and it is not fully raised
            // Animate the door raising up

		if (locked == false && opening==true) {
			//Debug.Log ("Trying to rotate");
			doorLeft.transform.Rotate (0, 0,  -speed*Time.deltaTime, Space.Self);
			doorRight.transform.Rotate (0, 0,  speed*Time.deltaTime, Space.Self);
			frame++;
			//leftRotationZ = doorLeft.transform.rotation.eulerAngles.z;
			//rightRotationZ = doorRight.transform.rotation.eulerAngles.z;
			//Debug.Log (leftRotationZ + " " + rightRotationZ);
			// if fully opened stop
			//if (Mathf.Round (leftRotationZ) == 90 || Mathf.Round (rightRotationZ) == 90) {
			//	Debug.Log (leftRotationZ + " " + rightRotationZ);
			if(frame==400) {
				opening = false;
				//GetComponent<Collider> ().isTrigger = false;
				//enabled = false;
				gameObject.SetActive (false);
				//transform.collider
			}

		}
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
            // Set the "opening" boolean to true
		// (optionally) Else
		// Play a sound to indicate the door is locked

		if (locked == true) {
			//Debug.Log ("Door clicked locked.");
			doorLocked.Play ();
		} else if (locked == false && onlyOneClickAllowed == false) {
			//Debug.Log ("Door clicked unlocked.");
			doorUnlocked.Play ();
			opening = true;
			onlyOneClickAllowed = true;
			//enabled = false;
		}
		// don't do it twice
		else if (onlyOneClickAllowed == true) {
			//opening = false;
		}
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
		locked = false;
    }
}
