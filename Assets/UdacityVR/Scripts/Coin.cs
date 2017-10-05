using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour 
{
    //Create a reference to the CoinPoofPrefab

	public GameObject poof;
	[SerializeField]
	private State  		_state					= State.Idle;
	public AudioSource _audio_source			= null;

	private enum State
	{
		Idle,
		Focused,
		Clicked,
		Approaching,
		Moving,
		Collect,
		Collected,
		Occupied,
		Open,
		Hidden
	}

	public void Enter()
	{
		_state = _state == State.Idle ? State.Focused : _state;
	}


	public void Exit()
	{
		_state = State.Idle;
	}


    private void OnCoinClicked() {
        // Instantiate the CoinPoof Prefab where this coin is located
        // Make sure the poof animates vertically
        // Destroy this coin. Check the Unity documentation on how to use Destroy
		Object.Instantiate(poof, transform.position, Quaternion.Euler(-90, 0, 0));
		Counter.plusOne ();
		Destroy(this.gameObject);

	}

	void Start ()
	{
	}

	void Update () 
	{	
		//Rotate
		transform.Rotate (Vector3.up* 60 * Time.deltaTime, Space.World);

		// Check state
		switch(_state)
		{
		case State.Focused:
			Focus();
			break;

		case State.Clicked:
			Clicked();
			break;

		default:
			break;
		} 
	}


	public void Focus()
	{
		
	}


	public void Clicked()
	{
		//Debug.Log ("Coin clicked");
		_audio_source.Play();
		OnCoinClicked ();
	}


}
