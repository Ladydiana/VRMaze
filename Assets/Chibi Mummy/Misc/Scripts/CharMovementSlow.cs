using UnityEngine;
using System.Collections;

public class CharMovementSlow : MonoBehaviour 
{

	public float jumpSpeed = 600.0f;
	public bool grounded = false;
	public bool doubleJump = false;
	public Transform groundCheck;
	public float groundRadius = 0.001f;
	public LayerMask whatIsGround;
	private Animator anim;
	public Rigidbody rb;
	public float vSpeed;


	private Vector3 originalPosition;
	private Quaternion originalRotation;
	public float movementSpeed = 3.0f;
	public float turnAroundX;
	public float turnAroundStartX;
	public float turnAroundZ;
	private Vector3 lastPos;


	void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		rb = GetComponent<Rigidbody>();
		anim.SetBool("crippled", true);
	}
	void Start ()
	{

	}
	void FixedUpdate () 
	{
		grounded = Physics.CheckSphere(groundCheck.position, groundRadius, whatIsGround);
		vSpeed = rb.velocity.y;
		anim.SetFloat ("vSpeed", vSpeed);
	}
	void Update () 
	{
		if (turnAroundX != 0 
			&& Mathf.Round(transform.position.x) != turnAroundX 
			&& Mathf.Round(turnAroundStartX) != Mathf.Round(transform.position.x) 
			)

		{
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
			//Debug.Log ("Moving forward.");
		} 
		else if (turnAroundX != 0 
				&& Mathf.Round(transform.position.x) == turnAroundX ) 
		{
			//lastPos = transform.position;
			transform.Rotate (0, 90, 0,  Space.Self);
			//transform.RotateAround(Vector3.zero, Vector3.up, 90);
			//transform.position = lastPos;
			transform.position += transform.forward * Time.deltaTime * movementSpeed;
			//Debug.Log ("Rotating other side");
		}

		else if (turnAroundX != 0 
				&& Mathf.Round(turnAroundStartX) == Mathf.Round(transform.position.x))
		{
			
			//lastPos = transform.position;
			//transform.RotateAround(Vector3.zero, Vector3.up, -90);
			transform.Rotate (0, -90, 0,  Space.Self);

			//transform.position = lastPos;

			transform.position += transform.forward * Time.deltaTime * movementSpeed;
			//Debug.Log("Rotating start");


		}
			
	}


		

	void OnDrawGizmos ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
	}

}
