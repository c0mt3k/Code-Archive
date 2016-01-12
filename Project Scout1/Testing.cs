using UnityEngine;

public class Testing : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	public void FixPlayer ()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ().CurrentHp = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerScript> ().HpMax;
	}
}
