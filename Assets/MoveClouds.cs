using UnityEngine;
using System.Collections;

public class MoveClouds : MonoBehaviour
{
	[Range(0.1f, 2f)]
	public float
		speed = 1f;

	private GameObject cloud1;
	private GameObject cloud2;

	private Queue queue;
	private float width;
	private float leftBorder;
	void Start ()
	{ 
		cloud1 = transform.Find ("clouds1").gameObject;
		cloud2 = transform.Find ("clouds2").gameObject;
		Vector3 size = cloud1.GetComponent<Renderer> ().bounds.size;
		width = size.x;// - 0.04f;
 
		queue = new Queue ();	
		queue.Enqueue (cloud1);
		queue.Enqueue (cloud2);
		leftBorder = cloud1.transform.position.x - width;
		Vector3 firstPos = cloud1.transform.position;
		cloud2.transform.position = new Vector3 (firstPos.x + width, firstPos.y, firstPos.z);
	}
	 
	void Update ()
	{
		MoveObject (cloud1);
		MoveObject (cloud2);
	}

	private void MoveObject (GameObject obj)
	{
		if (obj.transform.position.x < leftBorder) {
			queue.Dequeue ();
			queue.Enqueue (obj);
			GameObject first = queue.Peek () as GameObject;
			leftBorder = first.transform.position.x - width;
			//obj.transform.position = first.transform.position;
			Vector3 firstPos = first.transform.position;
			obj.transform.position = new Vector3 (firstPos.x + width, firstPos.y, firstPos.z);
		}
		obj.transform.Translate (Vector3.left * Time.deltaTime / speed);
	}

	private void revertSequence ()
	{

	}
}
