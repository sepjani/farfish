using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{

	private GameObject fishOnRod;
	private GameObject bodyParent;
	private Animator playerAnimator;
	PlayerEngine engine;
	 
	void Start ()
	{	
		bodyParent = transform.Find ("BodyParent").gameObject;
		engine = GetComponent<PlayerEngine> ();
		playerAnimator = bodyParent.GetComponent<Animator> ();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Jump")) {
			engine.jump ();
		}

		if (Input.GetButtonDown ("Fire1")) {
			onClickCatch ();
		}

	}

	public void onClickJump ()
	{
		playerAnimator.SetTrigger ("moveUpTrigger");
	}
	
	public void onClickCatch ()
	{	

		playerAnimator.SetTrigger ("catchTrigger");
		if (fishOnRod != null) {
			Vector3 pos = fishOnRod.transform.position;
			pos.y = -10;
			fishOnRod.transform.position = pos;
			Animator fishAnimator = fishOnRod.GetComponentInParent<Animator> ();
			fishAnimator.SetTrigger ("dieTrigger");
		}
	}

	public void makeCatched (GameObject fish)
	{
		fishOnRod = fish;
	}

//	public void die ()
//	{
//		playerAnimator.SetTrigger ("deathTrigger");
//		Debug.Log ("DIE DIE DIE");
//	}
}
