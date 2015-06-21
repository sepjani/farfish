using UnityEngine;
using System.Collections;

public class RopeLine : MonoBehaviour
{
    
	private DistanceJoint2D joint;
	Rigidbody2D rb2;

	LineRenderer lineRenderer;
	void Start ()
	{
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.material = new Material (Shader.Find ("Particles/Additive"));
		lineRenderer.SetColors (Color.white, Color.white);        
		lineRenderer.SetWidth (.02f, .04f);
		joint = GetComponent<DistanceJoint2D> ();
		rb2 = GetComponent<Rigidbody2D> ();
	}
	void Update ()
	{        
		Vector3 hand = rb2.transform.position;  
		hand.z = 1;
		Vector3 hook = joint.connectedBody.position;
		hook.z = 1;
		 
		// Debug.Log(hand);
		//Debug.Log(hook);

		//vv3.x += 0.8f;
		lineRenderer.SetPosition (0, hook);
		lineRenderer.SetPosition (1, hand);
        
        
		//lineRenderer.material = new Material(Shader.Find(“Particles / Additive”));
        
	}

}
