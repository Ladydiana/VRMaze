using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

	private static int count;
	public Text countText;

	// Use this for initialization
	void Start () {
		count = 0;
	}
	
	public static void plusOne () {
		count++;
	}

	public int getCount() {
		return count;
	}

	void SetCountText() {
		countText.text = "Coins: " + getCount ().ToString ();
	}

	void Update()
	{
		SetCountText ();
	}
}
