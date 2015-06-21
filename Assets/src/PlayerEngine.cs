using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerEngine : MonoBehaviour
{
	public bool isUpMove = false;
	public delegate void OnDirChange ();

	public delegate void OnJump ();

	public OnDirChange onDirChange;
	public OnJump onJump;
	public float power = 15;
	public float speed = 5;
	public float xSmooth = 2;
	public float ySmooth = 2;
	float targetSpeed;
	float targetPower;
	bool moveRight = false;
	[HideInInspector] 
	public CustomInput
		direction;
	bool isLocked = false;
	Rigidbody2D playerRigidbody;
	private PlayerManager manager;

	void Start ()
	{
	
		direction = gameObject.AddComponent<CustomInput> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		manager = GetComponent<PlayerManager> ();
	 
	}
	
	void FixedUpdate ()
	{
		if (!isLocked) {
			playerRigidbody.AddForce (direction.input, ForceMode2D.Impulse);
			direction.input.x = Mathf.Lerp (direction.input.x, targetSpeed, Time.fixedDeltaTime * xSmooth);
			direction.input.y = Mathf.Lerp (direction.input.y, 0, Time.fixedDeltaTime * ySmooth);
		}
	}

	public void SetLock (bool value)
	{
		isLocked = value;
	}

	public void Stop ()
	{
		if (playerRigidbody != null) {

			playerRigidbody.velocity = new Vector2 (0, 0);
			playerRigidbody.angularVelocity = 0;
		}
	}

	public void right ()
	{
		if (!isLocked) {
			if (moveRight)
				jump ();
			else
				switchDirection ();
			targetSpeed = speed * Time.timeScale;
			moveRight = true;
		}
	}

	public void left ()
	{
		if (!isLocked) {
			if (!moveRight)
				jump ();
			else
				switchDirection ();
			targetSpeed = -speed * Time.timeScale;
			moveRight = false;
		}
	}

	public void jump ()
	{
		direction.input.y += power * Time.timeScale;
		playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0);
		manager.onClickJump ();
		if (onJump != null) {
			onJump ();
		}  
	}

	void switchDirection ()
	{
		direction.input.x *= -1;
		if (onDirChange != null)
			onDirChange ();
	}



//	void OnCollisionEnter2D (Collision2D  bodyOther)
//	{
//		Debug.Log ("collide " + bodyOther.gameObject.name);
//
//		if (bodyOther.gameObject.name == "Fish") {
//			Debug.Log ("fish collide");
//			Destroy (bodyOther.gameObject, .5f);
//		}
//	}
//
//	void OnTriggerEnter2D (Collider2D other)
//	{
//		Debug.Log ("trigger collide " + other.gameObject.name);
//	}
}
