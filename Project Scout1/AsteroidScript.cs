using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
	public float HpMax;
	public float HpCurrent = .1f;
	public Sprite MidHp;
	public Sprite LowHp;

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 10);
		HpCurrent = HpMax;
	}

	void Update ()
	{
		//Destroy the object if it is outside the camera
		if (!RendererExtensions.IsVisibleFrom (GetComponent<Renderer> (), Camera.main))
			Destroy (gameObject);
		if (HpCurrent <= (HpMax / 2))
			GetComponent<SpriteRenderer> ().sprite = MidHp;
		if (HpCurrent <= (HpMax / 3))
			GetComponent<SpriteRenderer> ().sprite = LowHp;
		if (HpCurrent <= 0)
			Die ();
	}

	void OnCollisionEnter2D (Collision2D otherCollider)
	{
		switch (otherCollider.gameObject.tag) {
		case "Player":
			otherCollider.gameObject.GetComponent<PlayerScript> ().CurrentHp -= HpCurrent;
			Destroy (gameObject);
			break;
		}
	}

	void Die ()
	{
		// Upon destruction recources are gained
		Object.FindObjectOfType<ResourceScript> ().RRocks += (HpMax * (.80f * 1000));
		Object.FindObjectOfType<ResourceScript> ().RMetals += (HpMax * (.16f * 1000));
		Object.FindObjectOfType<ResourceScript> ().RGases += (HpMax * (.03f * 1000));
		Object.FindObjectOfType<ResourceScript> ().ROrganic += (HpMax * (.01f * 1000));
		Destroy (gameObject);
	}
}
