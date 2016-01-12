using UnityEngine;

public class BulletScript : MonoBehaviour
{
	#region Public Variables
	public UpgradeScript Upgrader;
	public float BulletSpeed = 8000;
	public float Damage;
	#endregion
	// Use this for initialization
	void Start ()
	{
		Upgrader = Object.FindObjectOfType<UpgradeScript> ();
		Damage = .75f + (Upgrader.CannonDmgLvl * 0.25f);
	}

	// Update is called once per frame
	void Update ()
	{
		//Destroy the object if it is outside the camera
		if (!RendererExtensions.IsVisibleFrom (GetComponent<Renderer> (), Camera.main))
			Destroy (gameObject);
	}
	//Propel the bullet
	void FixedUpdate ()
	{
		transform.GetComponent<Rigidbody2D> ().velocity = transform.right * (BulletSpeed * Time.deltaTime);
	}

	//Damage an object hit and destroy the bullet
	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		if (otherCollider.transform.GetComponent<AsteroidScript> () == true) {
			otherCollider.transform.GetComponent<AsteroidScript> ().HpCurrent -= Damage;
			Destroy (gameObject);
		}
	}
}
