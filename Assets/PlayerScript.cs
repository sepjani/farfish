using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

	public float MaxSpeed = 3;

	private Rigidbody2D character;
    



	// Use this for initialization
	void Start ()
	{
		character = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (character.velocity.y > MaxSpeed) {
			Vector2 ve = character.velocity;
			ve.y = MaxSpeed;
			character.velocity = ve;
		}
	}

	void FixedUpdate ()
	{
//		character.AddForce (transform.up * 30);
	}

	public void UpAction ()
	{
		Vector3 v3 = transform.position;
        
//		transform.position.x = 1;


		//ve.y = 0;
        
		//character.velocity = ve;


//		todo character.AddForce (new Vector2 (0, 90), ForceMode2D.Impulse);
		Mathf.Lerp (0, -20, Time.deltaTime);
		//transform.position = Vector3.Lerp(transform.position, v3, 2);
		// transform.position = new Vector3(v3.x, v3.y + 1.5f, v3.z) ;
	}
}
