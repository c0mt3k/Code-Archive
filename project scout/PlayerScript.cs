using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

	public float HpMax;
	public float CurrentHp;
	public UpgradeScript Upgrader;
	public Vector2 MoveSpeed;

	//Store movement
	Vector2 movement;

	// Use this for initialization
	void Start ()
	{
		Upgrader = Object.FindObjectOfType<UpgradeScript> ();
		HpMax = 9 + GameObject.Find ("GameController").GetComponent<UpgradeScript> ().PlayerMhpLvl;
		CurrentHp = HpMax;
	}

	// Update is called once per frame
	void Update ()
	{
		MoveSpeed = new Vector2 (30 + (Upgrader.PlayerMoveSpeedLevel * 10), 0);
		//Get the Axis Information
		float inputX;
		inputX = Input.GetAxis ("Horizontal");
		float inputY;
		inputY = Input.GetAxis ("Vertical");

		//movement in a direction
		movement = new Vector2 (
            MoveSpeed.x * inputX,
            MoveSpeed.y * inputY);
		//Destroy the player if hp reaches zero
		if (CurrentHp <= 0) {
			CurrentHp = 0;
			Destroy (gameObject);
		}
		//Make sure we are not outside the camera bounds
		float dist;
		dist = (transform.position - Camera.main.transform.position).z;

		float leftBorder;
		leftBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).x;

		float rightBorder;
		rightBorder = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, dist)).x;

		float topBorder;
		topBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, dist)).y;

		float bottomBorder;
		bottomBorder = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, dist)).y;

		transform.position = new Vector3 (
            Mathf.Clamp (transform.position.x, leftBorder, rightBorder),
            Mathf.Clamp (transform.position.y, topBorder, bottomBorder),
            transform.position.z
		);
	}

	void FixedUpdate ()
	{
		//move the player rigidbody
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
