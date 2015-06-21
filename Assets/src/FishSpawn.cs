using UnityEngine;
using System.Collections;

public class FishSpawn : MonoBehaviour
{
	public iTweenPath path;
	public GameObject fishPrefab;
	public GameObject waypointsGroup;
	public int SpawnTime = 5;
	public Sprite[] fishes;

	void Start ()
	{
//		Spawn ();
		InvokeRepeating ("Spawn", SpawnTime, SpawnTime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void Spawn ()
	{
		Vector3 fishPos = transform.position;
		fishPos.z = 1;
		 

		GameObject fish = Instantiate (fishPrefab, fishPos, Quaternion.identity) as GameObject;
		SpriteRenderer sr = fish.gameObject.GetComponentInChildren<SpriteRenderer> ();
//		Sprite[] fishes = Resources.LoadAll <Sprite> ("Sprites/Fishes");
		Sprite fishSprite = fishes [Random.Range (0, fishes.Length)];
		sr.sprite = fishSprite;
		var script = fish.GetComponent<Waypoints> ();
		script.setWaypoint (waypointsGroup);
		script.path = path;
		fish.transform.parent = transform;
	}
}
