using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{

	public string editorname;

	Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("I am Alive, " + editorname);
		// myComponent = GetComponent<Rigidbody2D>;
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//myComponent.transform.position.y -= - 1;
		//hand.transform.Translate(new Vector2(0,1) * Time.deltaTime);
	}

	void LateUpdate ()
	{
		//Camera.main.transform.LookAt(target.transform);
	}

//    void OnCollisionEnter2D(Collision2D otherObj)
//    {
//
//        Debug.Log("Collide");
//        rb2d.AddForce(new Vector3(55,-55,55));
//        
//    }
}

