using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour
{

//	public GameObject waypointsGroup;
	public iTweenPath path;
	public float patrolSpeed = 0.1f;       // The walking speed between Waypoints
	public bool loop = true;       // Do you want to keep repeating the Waypoints
	public float dampingLook = 6.0f;          // How slowly to turn
	public float pauseDuration = 0;   // How long to pause at a Waypoint

	private float curTime;
	private int currentWaypoint = 1;
	private CharacterController character; 
	private Vector3 currentTarget;
	private List<Vector3> waypoint;        // The amount of Waypoint you want

	private float startOffset;

	void Start ()
	{
		// waypoint = waypointsGroup.GetComponentsInChildren<Transform> ();
		// character = GetComponent<CharacterController> ();
//		currentTarget = waypoint [1].position;
		waypoint = path.nodes;
		startOffset = Time.time;
	}

	void Update ()
	{
		iTween.PutOnPath (gameObject, waypoint.ToArray (), ((Time.time - startOffset) * patrolSpeed) % 1f);
	}

//	void Update ()
//	{
//
//		if (currentWaypoint < waypoint.Length) {            
//			patrol ();
////			Debug.Log ("patrol");
//		} else {             
//			if (loop) {
//				currentWaypoint = 1;
//				//dir *= -1;
//			}
//		}
//	}
//
//	void patrol ()
//	{
//		Vector3 target =  waypoint [currentWaypoint].position;
//		Vector3 moveDirection = target - transform.position;
//		iTween.MoveBy(gameObject, iTween.Hash("x", 2, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
////
////		if (moveDirection.magnitude < 0.3f) {
////			if (curTime == 0)
////				curTime = Time.time; // Pause over the Waypoint
////			if ((Time.time - curTime) >= pauseDuration) {
////				currentTarget = waypoint [currentWaypoint].position;
////				currentTarget.x += Random.Range (-0.4F, 0.0F);
////				currentTarget.y += Random.Range (-0.4F, 0.4F);
////				currentWaypoint ++;
////
////				curTime = 0;
////			}
////		} else {
////			var rotation = Quaternion.LookRotation (target - transform.position);
////			rotation.y = 0;
////			rotation.x = 0;
////			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * dampingLook);
////			character.Move (moveDirection.normalized * patrolSpeed * Time.deltaTime);
////		}
//	}

	public void setWaypoint (GameObject waypointsGroup)
	{
//		this.waypointsGroup = waypointsGroup;

	}
}