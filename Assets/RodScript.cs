using UnityEngine;
using System.Collections;

public class RodScript : MonoBehaviour
{
	PlayerManager manager;

	// Use this for initialization
	void Start ()
	{
		manager = transform.parent.GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name.Contains ("body")) {
			manager.makeCatched (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name.Contains ("body")) {
			manager.makeCatched (null);
		}
	}
}
